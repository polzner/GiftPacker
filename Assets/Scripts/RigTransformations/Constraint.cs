using UnityEngine;
using System;

[Serializable]
public class Constraint
{
    [SerializeField] private ConstraintRecoverer _recoverer;
    [Range(0,1)] [SerializeField] private float _weight;

    public void Recover()
    {
        _recoverer.Recover(_weight);
    }

    public void Reset()
    {
        _recoverer.ResetWeight();
    }
}
