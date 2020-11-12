using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;

public class TexturesLoader : MonoBehaviour {

    public List<Texture2D> LoadTextures(string characterName) {
        var textures = new List<Texture2D>();
        
        var directoryInfo = new DirectoryInfo(Path.Combine(Application.streamingAssetsPath, "Textures", characterName));
        var allFiles = directoryInfo.GetFiles("*.*");
        
        foreach (var file in allFiles) {
            Debug.Log($"File name: {file.Name}");
            if (file.Name.Contains("meta"))
                continue;
            
            var bytes = File.ReadAllBytes(file.FullName);
            var texture = new Texture2D(1,1);

            texture.LoadImage(bytes);
            textures.Add(texture);
        }

        return textures;
    }
    
}