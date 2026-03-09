using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private const float Damage = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHp enemyHp = other.GetComponent<EnemyHp>();
        if (enemyHp != null)
        {
            enemyHp.TakeDamage(Damage);
        }
    }
}