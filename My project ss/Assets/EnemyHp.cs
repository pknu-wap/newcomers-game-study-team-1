using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    private const float MaxHp = 100f;
    private float _currentHp = MaxHp;

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log("Àû Ã¼·Â: " + _currentHp);
        if (_currentHp <= 0f) Destroy(gameObject);
    }
}