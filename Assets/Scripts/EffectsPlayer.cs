using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField] private Animator _congragularionAnimator;
    [SerializeField] private ParticleSystem _starEffect;

    public void PlayStar()
    {
        _starEffect.Play();
    }

    public void Congragulations()
    {
        _congragularionAnimator.SetTrigger("Congragulations");
    }
}
