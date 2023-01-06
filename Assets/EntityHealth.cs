using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using System.Security.Cryptography.X509Certificates;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    Rigidbody rb;
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
        rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
        OnLifeChange?.Invoke();
    }

    #endregion

    [Button("TakeDamage")]
    void TAKEDAMAGE() => TakeDamage(20);

    public void TakeDamage(int damage)
    {
        if(damage <= 0)
        {
            return;
        }
        _currentHealth -= damage;
        rb.AddRelativeForce(Vector3.back * 2.5f,ForceMode.Impulse);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            OnDie.Invoke();
            return;
        }
        OnLifeChange?.Invoke();
    }

    void GainLife(int gain)
    {
        if (gain <= 0)
        {
            return;
        }

        if (_currentHealth + gain >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
        {
            _currentHealth += gain;
        }
        OnLifeChange?.Invoke();
    }

    public void Heal(int heal)
    {
        GainLife(heal);
    }

    IEnumerator MaxHealthStart()
    {
        _maxHealth += 50;
        _currentHealth = _maxHealth;
        OnLifeChange?.Invoke();
        yield return new WaitForSeconds(3.0f);
    }
    IEnumerator MaxHealthStop()
    {
        yield return new WaitForSeconds(3.0f);
        _maxHealth -= 50;
        _currentHealth = _maxHealth;
        OnLifeChange?.Invoke();
    }

    public void LifeMax()
    {
        StartCoroutine(MaxHealthStart());
        StartCoroutine(MaxHealthStop());
    }

    public int GetMaxHealth()
    {
        return _maxHealth;
    }
}
