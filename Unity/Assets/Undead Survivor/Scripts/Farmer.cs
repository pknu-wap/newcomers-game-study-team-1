using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Farmer : MonoBehaviour
{
    private const float SPEED = 5;
    private Vector2 _moveDirection;
    private float _maxHealth = 100f;
    private float _health = 100f;

    // Update is called once per frame
    void Update() {
        transform.Translate(Time.deltaTime * SPEED * _moveDirection);
    }

    private void OnMove(InputValue inputValue) {
        _moveDirection = inputValue.Get<Vector2>();
    }

    public void TakeDamage(float damage) {
        _health -= damage;
        Debug.Log(_health);
    }

    public void Heal(float hp) {
        if(_health + hp < _maxHealth)
            _health += hp;
    }
}
