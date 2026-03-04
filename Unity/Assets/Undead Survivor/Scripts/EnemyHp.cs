using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    private const float MaxHp = 100f;
    private float _currentHp = MaxHp;

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log("적 체력: " + _currentHp);
        if (_currentHp <= 0f) Destroy(gameObject);
    }
}