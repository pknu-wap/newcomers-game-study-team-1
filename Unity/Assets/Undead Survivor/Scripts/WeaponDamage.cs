using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private const float Damage = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyHp>().TakeDamage(Damage);
    }
}