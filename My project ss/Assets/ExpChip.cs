using UnityEngine;

public class ExpChip : MonoBehaviour
{
    private const int Exp = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<FarmerLevel>().AddExp(Exp);
        Destroy(gameObject);
    }
}