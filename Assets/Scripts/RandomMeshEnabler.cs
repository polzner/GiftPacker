using System.Collections.Generic;
using UnityEngine;

public class RandomMeshEnabler : MonoBehaviour
{
    [SerializeField] private List<SkinnedMeshRenderer> _meshes;
    private SkinnedMeshRenderer _currentMesh;

    public void EnableRandomMesh()
    {
        _currentMesh = _meshes[Random.Range(0, _meshes.Count)];
        _currentMesh.enabled = true;
    }

    public void DisableCurrrentMesh()
    {
        _currentMesh.enabled=false;
    }
}
