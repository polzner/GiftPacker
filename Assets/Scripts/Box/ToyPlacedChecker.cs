using System;
using System.Collections.Generic;
using UnityEngine;

public class ToyPlacedChecker : MonoBehaviour
{
    [SerializeField] private Toy _toy;

    public void ToyPlaced()
    {
        _toy.ToyPlaced();
    }
}
