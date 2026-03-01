using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private float _damage = 5f;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<EnemyHealth>().TakeDamage(_damage);
    }
}
