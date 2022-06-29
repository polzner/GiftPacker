using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharactersPool : MonoBehaviour
{
    [SerializeField] private Character _prefab;
    [SerializeField] private int _count;

    private List<Character> _characters = new List<Character>();

    private void Awake()
    {
        for (int i = 0; i < _count; i++)
        {
            Character character = Instantiate(_prefab, transform);
            _characters.Add(character);
        }
    }

    public bool TryGetCharacter(out Character result)
    {
        result = _characters.FirstOrDefault(character => character.gameObject.activeSelf == false);
        return result != null;
    }
}
