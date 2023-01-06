using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    public int _currentHealth { get; private set; }

    [SerializeField] UnityEvent OnDie;

    public event Action OnLifeChange;

    #region Init
    void Reset()
    {
        _currentHealth = 100;
    }

    void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            _maxHealth = 100;
        }
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        OnLifeChange?.Invoke();
    }

    #endregion

    [Button("TakeDamage")]
    void TAKEDAMAGE() => TakeDamage(20, _currentHealth);

    void TakeDamage(int damage, int life)
    {
        if(damage <= 0)
        {
            return;
        }
        _currentHealth -= damage;
        if (life <= 0)
        {
            OnDie.Invoke();
            return;
        }
        OnLifeChange?.Invoke();
    }

    void GainLife(int gain, int life)
    {
        if (gain <= 0)
        {
            return;
        }
        
        _currentHealth += gain;

        if (life >= 100)
        {
            _currentHealth = _maxHealth;
            return;
        }
        OnLifeChange?.Invoke();
    }
}
