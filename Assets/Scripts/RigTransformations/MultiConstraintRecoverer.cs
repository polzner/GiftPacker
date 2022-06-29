using System.Collections.Generic;
using UnityEngine;

public class MultiConstraintRecoverer
{
    [SerializeField] private List<Constraint> _constraintRecoverers;
    [Range(0, 1)][SerializeField] private float _weight;

    public void Recover()
    {
        _constraintRecoverers.ForEach(recoverer => recoverer.Recover(_weight));
    }

    public void ResetWeight()
    {
        _constraintRecoverers.ForEach(recoverer => recoverer.ResetWeight());
    }
}
