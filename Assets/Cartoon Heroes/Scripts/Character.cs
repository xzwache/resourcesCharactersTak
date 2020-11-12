using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField] private CharacterItemSet[] _sets;

    public CharacterItemSet[] ItemSets => _sets;    

    public void SetPantsColor(string name, Color color) {
        var set = _sets.FirstOrDefault(s => s.name == name);

        if (set != null)
            set.renderer.material.color = color;
    }
}

[Serializable]
public class CharacterItemSet {
    public SkinnedMeshRenderer renderer;
    public string name;
}