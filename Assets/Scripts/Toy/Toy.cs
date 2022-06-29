using System;
using UnityEngine;

public class Toy : MonoBehaviour
{
    [SerializeField] private ToyMeshChanger _meshChanger;
    public Action Placed;

    public ToyMeshChanger MeshChanger => _meshChanger;

    public void ToyPlaced()
    {
        Placed?.Invoke();
    }
}
