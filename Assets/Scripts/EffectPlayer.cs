using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void PlayEffect()
    {
        _effect.Play();
    }
}
