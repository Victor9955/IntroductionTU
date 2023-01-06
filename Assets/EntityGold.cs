using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;
using System;

public class EntityGold : MonoBehaviour
{
    [SerializeField] int _startGoldAmount;
    public event Action _goldEvent;
    public int _goldAmount { get; private set; }

    private void Start()
    {
        SetStartGold(_startGoldAmount);
        _goldEvent.Invoke();
    }

    void OnValidate()
    {
        if (_startGoldAmount < 0)
        {
            _startGoldAmount = 0;
        }
    }

    private void SetStartGold(int amount)
    {
        if(amount < 0) { return; }
        _goldAmount = amount;
    }

    public void AddGold(int amount)
    {
        if (amount <= 0) { return; }
        _goldAmount += amount;
        _goldEvent?.Invoke();
    }

    [Button("Add 100 Gold")]
    private void Add100Gold() { AddGold(100); }
}
