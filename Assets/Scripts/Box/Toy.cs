using System;
using System.Collections.Generic;
using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _toyMeshes;
    private MeshRenderer _currentMesh;

    public Action Placed;

    public MeshRenderer CurrentMesh => _currentMesh;

    private void Awake()
    {
        _currentMesh = _toyMeshes[UnityEngine.Random.Range(0, _toyMeshes.Count)];
    }

    public void RandomizeMesh()
    {
        _currentMesh.enabled = false;
        _currentMesh = _toyMeshes[UnityEngine.Random.Range(0, _toyMeshes.Count)];
        _currentMesh.enabled = true;
    }

    public void ToyPlaced()
    {
        Placed?.Invoke();
    }
}
