using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoxTransformationAnimatorParameters
{
    public static class Triggers
    {
        public const string PlaceOnSurface = nameof(PlaceOnSurface);
        public const string Rotate = nameof(Rotate);
        public const string Flip = nameof(Flip);
        public const string WithoutFlip = nameof(WithoutFlip);
        public const string EndPacking = nameof(EndPacking);
        public const string PlaceFiller = nameof(PlaceFiller);
    }
}
