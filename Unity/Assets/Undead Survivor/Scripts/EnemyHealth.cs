using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float _health = 20f;
    [SerializeField] private GameObject _expChip0;
    public void TakeDamage(float damage) {
        _health -= damage;
        if(_health <= 0) {
            Instantiate(_expChip0, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
