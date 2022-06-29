using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private RandomMeshEnabler _meshEnabler;
    [SerializeField] private CharacterMover _mover;

    private void OnEnable()
    {
        _mover.MoveEnded += OnMoveEnded;
    }

    private void OnDisable()
    {
        _mover.MoveEnded -= OnMoveEnded;
    }

    public void Move()
    {
        _meshEnabler.EnableRandomMesh();
        _mover.Move();
    }

    private void OnMoveEnded()
    {
        _meshEnabler.DisableCurrrentMesh();
    }
}
