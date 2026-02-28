using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerMovement : MonoBehaviour
{
    private const float Speed = 10f;
    private Vector3 _moveDirection;

    private void Update()
    {
        transform.Translate(Time.deltaTime * Speed * _moveDirection);
    }

    private void OnMove(InputValue value)
    {
        _moveDirection = value.Get<Vector2>();
        _moveDirection.Normalize();
    }
}