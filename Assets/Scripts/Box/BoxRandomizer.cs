using System.Collections.Generic;
using UnityEngine;

public class BoxRandomizer : MonoBehaviour
{
    [SerializeField] private List<Box> _boxes;
    private Box _currentBox;

    public Box CurrentBox => _currentBox;

    private void Awake()
    {
        RandomizeBox();
    }

    public void RandomizeBox()
    {
        _currentBox = _boxes[Random.Range(0, _boxes.Count)];
    }
}
