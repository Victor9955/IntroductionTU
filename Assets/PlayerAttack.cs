using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] InputActionReference _attack;
    [SerializeField] HitEntity _hitRange;

    private void Start()
    {
        _attack.action.performed += Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        _hitRange.Hit();
    }

    private void OnDestroy()
    {
        _attack.action.performed -= Attack;
    }
}
