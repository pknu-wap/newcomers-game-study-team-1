using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float _damage = 1f;
    private bool _isCooltime = false;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            other.GetComponent<FarmerHealth>().TakeDamage(_damage);
        }
    }
}
