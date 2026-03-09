using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private const float Damage = 0.5f;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) other.GetComponent<FarmerHp>().TakeDamage(Damage);
    }
}