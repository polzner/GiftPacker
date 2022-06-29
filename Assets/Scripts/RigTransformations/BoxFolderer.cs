using UnityEngine;

public class BoxFolderer : MonoBehaviour
{
    [SerializeField] private DownSideFolderer _downSideFolderer;
    [SerializeField] private DelayedSideFolderer _upSideFolderer;

    public void ResetConstraintWeights()
    {
        _downSideFolderer.ResetWeights();
        _upSideFolderer.ResetWeight();
    }

    public void FoldDownSide(Side side)
    {
        _downSideFolderer.FoldDownSide(side);
    }

    public void FoldUpSide()
    {
        _upSideFolderer.Fold();
    }
}
