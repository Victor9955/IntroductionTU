using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    int CachedMaxHealth { get; set; }

    private void Start()
    {
        _playerHealth.OnLifeChange += OnLifeChange;
    }

    private void OnLifeChange()
    {
        UpdateSlider(_playerHealth._currentHealth);
    }

    void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        _text.text = $"{newHealthValue} / {CachedMaxHealth}";
    }

    private void OnDestroy()
    {
        _playerHealth.OnLifeChange -= OnLifeChange;
    }
}
