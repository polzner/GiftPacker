using UnityEngine;
using System;

[Serializable]
public class Box
{
    [SerializeField] private SkinnedMeshRenderer _mesh;
    [SerializeField] private BoxFolderer _boxFolderer;
    [SerializeField] private bool _flipable;

    public SkinnedMeshRenderer Mesh => _mesh;
    public BoxFolderer BoxFolderer => _boxFolderer;
    public bool Flipable => _flipable;
}
