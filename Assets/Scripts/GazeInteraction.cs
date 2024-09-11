using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.sharedMaterial.color;
    }

    private void OnPointerEnter()
    {
        objectRenderer.material.color = Color.magenta;
    }

    private void OnPointerExit()
    {
        objectRenderer.material.color = originalColor;
    }

}
