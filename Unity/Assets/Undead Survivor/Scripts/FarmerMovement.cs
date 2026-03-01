using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerMovement : MonoBehaviour
{
    private const float SPEED = 5;
    private Vector2 _moveDirection;

    // Update is called once per frame
    void Update() {
        transform.Translate(Time.deltaTime * SPEED * _moveDirection);
    }

    private void OnMove(InputValue inputValue) {
        _moveDirection = inputValue.Get<Vector2>();
    }
}
