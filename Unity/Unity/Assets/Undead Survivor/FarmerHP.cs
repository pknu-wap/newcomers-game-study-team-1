using UnityEngine;

public class FarmerHp : MonoBehaviour
{
    private const float MaxHp = 100f;
    private float _currentHp = MaxHp;

    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        Debug.Log("농부 체력: " + _currentHp);
    }
}