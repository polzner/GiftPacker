using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private CharactersPool _pool;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _minDelay;

    private void Start()
    {
        StartCoroutine(SpawnRoutine(_spawnPoints, _pool, _maxDelay, _minDelay));
    }

    private IEnumerator SpawnRoutine(List<Transform> spawnPoints, CharactersPool pool, float maxDelay, float minDelay)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            if(_pool.TryGetCharacter(out Character character))
            {
                Transform spawnPoint = _spawnPoints[Random.Range(0, spawnPoints.Count)];
                character.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
                character.transform.SetParent(spawnPoint.transform);
                character.gameObject.SetActive(true);
                character.Move();
            }
        }
    }
}
