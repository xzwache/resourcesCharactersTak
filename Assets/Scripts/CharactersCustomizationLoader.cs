using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersCustomizationLoader : MonoBehaviour
{
    [SerializeField] private CharacterButton baseButton;
    [SerializeField] private ColorPanel _colorPanel;
    [SerializeField] private ClothesPanel _clothesPanel;

    public void Initialize(Character _character, List<Texture2D> textures) {

        _clothesPanel.Initialize(_character.ItemSets[2].renderer, textures);
        
        baseButton.Setup(_character.ItemSets[0].name, name => {
            _colorPanel.Reset();
            _colorPanel.Initialize(_character.ItemSets[0]);
        });
        
        for (int i = 1; i < _character.ItemSets.Length; i++) {
            var btn = Instantiate(baseButton, baseButton.transform.parent);
            
            var index = i;
            btn.Setup(_character.ItemSets[i].name, nam => {
                _colorPanel.Reset();
                _colorPanel.Initialize(_character.ItemSets[index]);
            });
        }
    }
}

