using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxPlacer : MonoBehaviour
{
    [SerializeField] private List<Box> _boxes;
    [SerializeField] private BoxStateBehaviour _stateSwitcher;

    private Box _currentBox;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _stateSwitcher.Switch<StartPackingBoxState>();
    }

    public void PLace()
    {
        _currentBox.MeshRenderer.enabled = false;
        _currentBox = _boxes[Random.Range(0, _boxes.Count)];
        _currentBox.MeshRenderer.enabled = true;
    }

    [System.Serializable]
    private class Box
    {
        [SerializeField] public SkinnedMeshRenderer MeshRenderer;
        [Range(0, 1)] public float TargetBottomSideWeight;
        [Range(0, 1)] public float TargetUpSideWeight;
    }
}
