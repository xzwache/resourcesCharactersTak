using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "CharactersConfig", menuName = "CharactersConfig", order = 0)]
public class CharactersConfig : ScriptableObject {
    [SerializeField] private string[] characters;

    public string[] Characters => characters;

    public Character GetCharacter(string characterName) {
        var objName = characters.FirstOrDefault(e => e == characterName);
        return string.IsNullOrEmpty(objName) ? null : LoadObject(characterName);
    }
    
    private static Character LoadObject(string characterName) {
        return Resources.Load<Character>($"Characters/{characterName}");
    }

#if UNITY_EDITOR
    private void Reset() {
        var objects = Resources.LoadAll<Character>($"Characters");
        characters = new string[objects.Length];

        for (int i = 0; i < characters.Length; i++) {
            characters[i] = objects[i].name;
        }
    }
#endif
}