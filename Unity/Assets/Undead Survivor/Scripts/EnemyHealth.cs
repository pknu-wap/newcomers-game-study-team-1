using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float _health = 20f;

    public void TakeDamage(float damage) {
        _health -= damage;
        if(_health <= 0) Destroy(gameObject);
    }
}
