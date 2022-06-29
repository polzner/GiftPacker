using System.Collections.Generic;
using UnityEngine;

public class ToyMeshChanger : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _toyMeshes;
    [SerializeField] private FillerPlaceState fillerPlaceState;

    private MeshRenderer _currentMesh;
    private int _count = 0;

    private void Awake()
    {
        _currentMesh = _toyMeshes[_count];
    }

    public void TakeNextMesh()
    {
        _currentMesh.enabled = false;
        _currentMesh = _toyMeshes[_count];
        _currentMesh.enabled = true;
        _count++;
    }

    public void DisableMesh()
    {
        _currentMesh.enabled = false;
    }
}
