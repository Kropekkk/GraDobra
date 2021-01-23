using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class testowystacha : MonoBehaviour
{
    public MeshRenderer wyglad;
    void Start()
    {
        wyglad.material.color = new Color(1f, 0f, 0f);
        PrefabUtility.SaveAsPrefabAsset(gameObject, "Assets/Resources/Stacha.prefab");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
