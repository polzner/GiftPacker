using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerPhysicsActivator : MonoBehaviour
{
    [SerializeField] private BoxFillerPlacer _boxFillerPlacer;

    public void ActivateFiller()
    {
        _boxFillerPlacer.Fill();
    }
}
