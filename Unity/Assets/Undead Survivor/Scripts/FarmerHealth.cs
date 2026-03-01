using UnityEngine;

public class FarmerHealth : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _health = 100f;

    public void TakeDamage(float damage) {
        _health -= damage;
        Debug.Log(_health);
    }

    public void Heal(float hp) {
        if(_health + hp < _maxHealth)
            _health += hp;
    }
}
