using System;
using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    [SerializeField] internal References references;
    [Serializable]
    internal class References
    {
        public MeshRenderer[] meshRenderers;
    }

    public void ChangeColor(Image source) 
    {
        foreach (var renderer in references.meshRenderers)
            renderer.material.SetColor("_BaseColor", source.color);
    }

}
