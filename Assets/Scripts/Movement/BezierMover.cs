using System;
using System.Collections;
using UnityEngine;

public class BezierMover : MonoBehaviour
{
    [SerializeField] private Transform _p1;
    [SerializeField] private Transform _p2;
    [SerializeField] private Transform _p3;
    [SerializeField] private Transform _p4;
    [SerializeField] private float _time = 3;
    private Bezier _bezier = new Bezier();

    public Action MoveEnded;

    public void Move()
    {
        StartCoroutine(MoveRoutine(_p1.position, _p2.position, _p3.position, _p4.position, _time));
    }

    public void RotateMove()
    {
        StartCoroutine(RotationRoutine(-_bezier.GetRotation(_p1.position, _p2.position, 
            _p3.position, _p4.position, 0), 0.5f));
    }

    private IEnumerator RotationRoutine(Vector3 targetRotation, float time)
    {
        Quaternion targetQuaternionRotation = Quaternion.LookRotation(targetRotation);
        Quaternion startQuaternionRotation = transform.rotation;
        float currentTime = 0;

        while (currentTime <= time)
        {
            transform.rotation = Quaternion.Lerp(startQuaternionRotation, targetQuaternionRotation, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }

        Move();
    }

    protected IEnumerator MoveRoutine(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4, float time)
    {
        float currentTime = 0;
        

        while (currentTime <= time)
        {
            float normalizedTime = Mathf.Clamp(currentTime / time, 0f, time);

            if (normalizedTime >= 0.97f)
                normalizedTime = 1f;

            transform.position = _bezier.GetPoint(p1, p2, p3, p4, normalizedTime);
            transform.rotation = Quaternion.LookRotation(-_bezier.GetRotation(p1, p2, p3, p4, normalizedTime));
            currentTime += Time.deltaTime;
            yield return null;
        }

        MoveEnded?.Invoke();        
    }

    private void OnDrawGizmos()
    {
        int sigmentsNumber = 20;
        Vector3 preveousePoint = _p1.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = _bezier.GetPoint(_p1.position, _p2.position, _p3.position, _p4.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}
