using System.Collections.Generic;
using UnityEngine;

public class BoxFillerPlacer : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private int _count;
    [SerializeField] private ColorRandomizer _colorRandomizer;
    [SerializeField] private BoxCollider _colliderForBallRandomPosition;
    [SerializeField] private float _gravityScale = 100;

    private List<GameObject> _balls;
    private MeshRenderer _mesh;
    private Vector3 _defaultGravity;

    public enum ColorMode
    {
        Standart,
        Random
    }

    private void Start()
    {
        _defaultGravity = Physics.gravity;
        _mesh = GetComponent<MeshRenderer>();
        _mesh.enabled = false;
        _balls = new List<GameObject>();

        for (int i = 0; i < _count; i++)
        {
            GameObject ball = Instantiate(_ballPrefab, transform);
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.GetComponent<MeshRenderer>().enabled = false;
            _balls.Add(ball);
            ball.transform.position = GetRandomPointInsideCollider(_colliderForBallRandomPosition);
        }
    }

    public void EnableFiller(ColorMode colorMode)
    {
        _mesh.enabled = true;

        foreach (var ball in _balls)
        {
            MeshRenderer ballMeshRenderer = ball.GetComponent<MeshRenderer>();
            ballMeshRenderer.enabled = true;
            float shadowOffset = 25f / 255f;
            float specularOffset = 6f / 255f;

            if (colorMode == ColorMode.Random)
            {
                ballMeshRenderer.material.color = _colorRandomizer.GetRandomColor();
                ballMeshRenderer.material.SetColor("_ColorDim", GetColorShaded(shadowOffset, ballMeshRenderer));
                ballMeshRenderer.material.SetColor("_FlatSpecularColor", GetSpecularColor(specularOffset, ballMeshRenderer));
            }
            else
            {
                ballMeshRenderer.material.color = _colorRandomizer.StandartColor;
                ballMeshRenderer.material.SetColor("_ColorDim", GetColorShaded(shadowOffset, ballMeshRenderer));
                ballMeshRenderer.material.SetColor("_FlatSpecularColor", GetSpecularColor(specularOffset, ballMeshRenderer));
            }
        }

        Color GetColorShaded(float delta, MeshRenderer meshRenderer)
        {
            Color currentColor = meshRenderer.material.color;
            Color shadedColor = new Color(currentColor.r - delta, currentColor.g - delta, currentColor.b - delta);
            return shadedColor;
        }

        Color GetSpecularColor(float delta, MeshRenderer meshRenderer)
        {
            Color currentColor = meshRenderer.material.color;
            Color shadedColor = new Color(currentColor.r + delta, currentColor.g + delta, currentColor.b + delta);
            return shadedColor;
        }
    }

    public void Fill()
    {
        Physics.gravity = Vector3.down * _gravityScale;

        foreach (var ball in _balls)
        {
            ball.transform.SetParent(null);
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void ResetFiller()
    {
        foreach (var ball in _balls)
        {
            ball.GetComponent<MeshRenderer>().enabled = false;
            ball.transform.SetParent(transform);
            ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.position = GetRandomPointInsideCollider(_colliderForBallRandomPosition);
        }

        _mesh.enabled = false;
        Physics.gravity = _defaultGravity;
    }

    private Vector3 GetRandomPointInsideCollider(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        ) + boxCollider.center;
        return boxCollider.transform.TransformPoint(point);
    }
}
