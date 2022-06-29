using UnityEngine;

public class PackingReseter : MonoBehaviour
{
    [SerializeField] private BoxFillerPlacer _boxFillerPlacer;
    [SerializeField] private BoxModelChanger _boxRandomizer;
    [SerializeField] private BowPlacer _bowPlacer;
    [SerializeField] private Toy _toy;

    public void ResetParameters()
    {
        _boxRandomizer.CurrentBox.Mesh.enabled = false;
        _boxRandomizer.CurrentBox.BoxFolderer.ResetConstraintWeights();
        _boxRandomizer.TakeNextBox();
        _bowPlacer.TakeDefaultParameters();
        _toy.MeshChanger.TakeNextMesh();
    }
}
