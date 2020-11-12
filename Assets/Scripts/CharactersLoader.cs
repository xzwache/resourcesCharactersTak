using UnityEngine;

public class CharactersLoader : MonoBehaviour
{
    [SerializeField] private CharacterButton baseButton;
    [SerializeField] private CharactersCustomizationLoader _customizationLoader;

    [SerializeField] private TexturesLoader _texturesLoader;
    private CharactersConfig config;
  
    private void Start()
    {
        config = Resources.Load<CharactersConfig>("CharactersConfig");
        var names = config.Characters;
        
        baseButton.Setup(names[0], OnCharacterButton);
        
        for (int i = 1; i < names.Length; i++)
        {
            var btn = Instantiate(baseButton, baseButton.transform.parent);
            btn.Setup(names[i], OnCharacterButton);
        }
    }
    private void OnCharacterButton(string id)
    {
        this.gameObject.SetActive(false);
           
        
        var asset = config.GetCharacter(id);
        var character = Instantiate(asset, Vector3.zero, Quaternion.identity);
        
        _customizationLoader.Initialize(character, _texturesLoader.LoadTextures(id));
    }
}