using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigRecoverer : MonoBehaviour
{
    [SerializeField] private Rig _rig;
    [SerializeField] private float _time;

    public void Recover(float targetWeight)
    {
        StartCoroutine(RecoverRoutine(_rig, targetWeight, _time));
    }

    private IEnumerator RecoverRoutine(Rig rig, float targetWeight, float time)
    {
        float currentTime = 0;
        float startWeight = rig.weight;

        while (rig.weight != targetWeight)
        {
            rig.weight = Mathf.Lerp(startWeight, targetWeight, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
