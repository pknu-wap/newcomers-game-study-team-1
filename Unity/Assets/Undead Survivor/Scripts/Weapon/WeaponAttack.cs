using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private float _damage = 10f;

    private void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<Enemy>().TakeDamage(_damage);
    }
}
