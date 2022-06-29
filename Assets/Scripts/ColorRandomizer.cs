using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    [SerializeField] private Color _baseColor;
    [SerializeField] private Gradient _gradient;

    public Color StandartColor => _baseColor;

    public Color GetRandomColor()
    {
        return _gradient.Evaluate(Random.Range(0f,1f));
    }
}
