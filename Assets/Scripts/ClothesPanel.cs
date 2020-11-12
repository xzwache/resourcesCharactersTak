using System.Collections.Generic;
using UnityEngine;

public class ClothesPanel : MonoBehaviour {
    [SerializeField] private CharacterButton baseButton;

    public void Initialize(SkinnedMeshRenderer renderer, List<Texture2D> textures) {
        
        baseButton.Setup(0.ToString(), nam => {
            renderer.material.mainTexture = textures[0];
        });
        
        for (int i = 1; i < textures.Count; i++) {

            var button = Instantiate(baseButton, baseButton.transform.parent);
            var index = i;
            button.Setup(i.ToString(), nam => {
                renderer.material.mainTexture = textures[index];
            });
        }
    }
}