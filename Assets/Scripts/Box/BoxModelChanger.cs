using System.Collections.Generic;
using UnityEngine;

public class BoxModelChanger : MonoBehaviour
{
    [SerializeField] private List<Box> _boxes;
    private Box _currentBox;

    private int _count = 0;

    public Box CurrentBox => _currentBox;

    private void Awake()
    {
        _currentBox = _boxes[_count];
    }

    public void TakeNextBox()
    {
        _currentBox = _boxes[_count];
        _count++;
    }
}
