using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimatorBinding : MonoBehaviour
{
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _attack;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _move.action.performed += MoveAnim;
        _move.action.canceled += StopMoveAnim;
        _attack.action.performed += AttackAnim;
    }

    private void StopMoveAnim(InputAction.CallbackContext obj)
    {
        animator.SetBool("Walking", false);
    }

    private void MoveAnim(InputAction.CallbackContext obj)
    {
        Vector2 JoystickDirection = obj.ReadValue<Vector2>();
        animator.SetBool("Walking", true);
        transform.LookAt(new Vector3(transform.position.x + JoystickDirection.x, transform.position.y, transform.position.z + JoystickDirection.y));
    }

    private void OnDestroy()
    {
        _move.action.performed -= MoveAnim;
        _move.action.canceled -= StopMoveAnim;
    }

    private void AttackAnim(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("Attack");
    }
}
