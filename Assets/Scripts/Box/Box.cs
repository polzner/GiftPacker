using UnityEngine;
using System;

[Serializable]
public class Box
{
    [SerializeField] private SkinnedMeshRenderer _mesh;
    [SerializeField] private BoxFolderer _boxFolderer;
    [SerializeField] private Transform _bowPositioin;
    [SerializeField] private bool _flipable;

    public SkinnedMeshRenderer Mesh => _mesh;
    public BoxFolderer BoxFolderer => _boxFolderer;
    public Transform BowPositioin => _bowPositioin;
    public bool Flipable => _flipable;
}
