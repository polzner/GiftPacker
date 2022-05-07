using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private BezierMover _startMover;
    [SerializeField] private BezierMover _endMover;

    public BezierMover StartMover => _startMover;
    public BezierMover EndMover  => _endMover;

    private void Start()
    {
        MoveToPackingPoint();
    }

    public void MoveToPackingPoint()
    {
        _startMover.Move();
    }

    public void MoveToEndPoint()
    {

    }
}
