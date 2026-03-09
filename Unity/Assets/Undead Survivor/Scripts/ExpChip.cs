using UnityEngine;

public class ExpChip : MonoBehaviour
{
    public float Exp = 10f;

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            other.GetComponent<FarmerLevel>().AddExp(Exp);
            Destroy(gameObject);
        }
    }
}
