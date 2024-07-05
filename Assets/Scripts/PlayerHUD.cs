using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

// Purpose is to manipulate HUD UI elements
public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        FruitSpawner.OnFruitSpawn += UpdateFruitLeftText;
    }

    private void OnEnable()
    {
        UpdateFruitLeftText(GameObject.FindObjectOfType<FruitSpawner>().NumberOfFruitLeft);
    }
    

    private void UpdateFruitLeftText(int numberOfFruitLeft)
    {
        _textMeshPro.text = $"Cat Left: {numberOfFruitLeft}";
    }
}
