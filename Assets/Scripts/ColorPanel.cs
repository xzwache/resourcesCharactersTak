using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ColorPanel : MonoBehaviour {
    
    [SerializeField] private Color[] _colors;
    [SerializeField] private Button baseButton;

    List<Button> _buttons = new List<Button>();
    
    public Color[] Colors => _colors;

    public void Initialize(CharacterItemSet itemSet) {
        _buttons = new List<Button>();
        baseButton.image.color = _colors[0];
        baseButton.onClick.AddListener(() => {
            itemSet.renderer.sharedMaterial.color = _colors[0];
        });
        
        for (int i = 1; i < _colors.Length; i++) {
            var button = Instantiate(baseButton, baseButton.transform.parent);
            _buttons.Add(button);
            
            button.image.color = _colors[i];
            var index = i;
            button.onClick.AddListener(() => {
                itemSet.renderer.sharedMaterial.color = _colors[index];
            });
        }
    }

    public void Reset() {
        if (_buttons.Count != 0) {
            foreach (var button in _buttons) {
                Destroy(button.gameObject);
            }
            _buttons.Clear();
        }
    }
}
