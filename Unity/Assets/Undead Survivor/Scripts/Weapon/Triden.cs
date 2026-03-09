using UnityEngine;
using System.Collections.Generic;

public class Triden : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Length = 6f;
    private float _damage = 7f;
    
    private Rigidbody2D _rb;

    void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Shot(Vector2 origin, Vector2 direction) {
        direction.Normalize();

        transform.position = origin;
        Vector3 desPos = transform.position + (Vector3)direction * Length;
        _rb.AddForce(direction * Length, ForceMode2D.Impulse);

        StartCoroutine(DestroyAfter(3));
    }

    void OnTriggerEnter2D(Collider2D other) {
        other.GetComponent<Enemy>().TakeDamage(_damage);

        Destroy(gameObject);
    }

    IEnumerator<WaitForSeconds> DestroyAfter(float secs) {
        yield return new WaitForSeconds(secs);
        Destroy(gameObject);
    }
}
