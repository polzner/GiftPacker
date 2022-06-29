using System;
using System.Collections;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float _speed;

    public Action MoveEnded;

    public void Move()
    {
        StartCoroutine(MoveRoutine(_time));
    }

    private IEnumerator MoveRoutine(float time)
    {
        gameObject.SetActive(true);
        float currentTime = 0;

        while (currentTime < _time)
        {
            transform.localPosition += Vector3.forward * Time.deltaTime * _speed;
            currentTime += Time.deltaTime;
            yield return null;
        }

        MoveEnded?.Invoke();
        gameObject.SetActive(false);
    }
}
