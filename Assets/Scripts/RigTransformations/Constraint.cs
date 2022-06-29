using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(MultiRotationConstraint))]
public class Constraint : MonoBehaviour
{
    [SerializeField] private float _time;
    private MultiRotationConstraint _constraint;

    private void Awake()
    {
        _constraint = GetComponent<MultiRotationConstraint>();
    }

    public void ResetWeight()
    {
        _constraint.weight = 0;
    }

    public void Recover(float targetWeight)
    {
        StartCoroutine(RecoverRoutine(_constraint, targetWeight, _time));
    }

    private IEnumerator RecoverRoutine(MultiRotationConstraint constraint, float targetWeight, float time)
    {
        float currentTime = 0;
        float startWeight = constraint.weight;

        while (constraint.weight != targetWeight)
        {
            constraint.weight = Mathf.Lerp(startWeight, targetWeight, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
