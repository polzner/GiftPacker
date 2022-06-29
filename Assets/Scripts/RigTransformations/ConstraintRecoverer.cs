using UnityEngine;

[System.Serializable]
public class ConstraintRecoverer
{
    [SerializeField] private Constraint _constraint;
    [Range(0, 1)][SerializeField] private float _weight;

    public void Recover()
    {
        _constraint.Recover(_weight);
    }

    public void ResetWeight()
    {
        _constraint.ResetWeight();
    }
}
