using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class FarmerMovement : MonoBehaviour
{
    private const float SPEED = 5f;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        _rb.linearVelocity = _moveDirection * SPEED;
        //transform.Translate(Time.deltaTime * SPEED * _moveDirection);
    }

    private void OnMove(InputValue inputValue) {
        // inputValue is already normalized so it doesnt have to be done again.
        _moveDirection = inputValue.Get<Vector2>();
    }
}
