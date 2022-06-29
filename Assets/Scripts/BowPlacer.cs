using System;
using System.Collections;
using UnityEngine;

public class BowPlacer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Transform _defaultTransform;
    [SerializeField] private Transform _bow;

    public Action BowPlaced;

    public void Place(Transform targetTransform)
    {
        StartCoroutine(PlaceBowRoutine(_bow, _defaultTransform, targetTransform, _time));
    }

    public void TakeDefaultParameters()
    {
        _bow.gameObject.GetComponent<MeshRenderer>().enabled = false;
        _bow.position = _defaultTransform.position;
        _bow.rotation = _defaultTransform.rotation;
    }

    private IEnumerator PlaceBowRoutine(Transform bow, Transform defaultTransform ,Transform targetTransform, float time)
    {
        bow.gameObject.GetComponent<MeshRenderer>().enabled = true;
        Vector3 startPosition = defaultTransform.position;

        Quaternion startRotation = defaultTransform.rotation;
        float currentTime = 0;

        while (targetTransform.position != bow.position)
        {
            bow.position = Vector3.Lerp(startPosition, targetTransform.position, currentTime/time);
            bow.rotation = Quaternion.Lerp(startRotation, targetTransform.rotation, currentTime/time);
            currentTime += Time.deltaTime;
            yield return null;
        }

        BowPlaced.Invoke();
    }
}
