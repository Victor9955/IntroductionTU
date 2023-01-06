using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GoldUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goldUI;
    [SerializeField] EntityGold _gold;

    private void Start()
    {
        _gold._goldEvent += UpdateGold;
    }

    public void UpdateGold()
    {
        _goldUI.text = "Gold:" + _gold._goldAmount;
    }

    private void OnDestroy()
    {
        _gold._goldEvent -= UpdateGold;
    }
}
