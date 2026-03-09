using UnityEngine;
using System.Collections.Generic;

public class Enemy: MonoBehaviour
{
    public static Dictionary<Enemy, GameObject> Spawned = new();

    private float _health = 20f;
    [SerializeField] private GameObject _expChip0;

    private Transform _playerTransform;
    private float _speed = 4f;
    private float _damage = 1f;

    private SpriteRenderer _sprite;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            other.GetComponent<FarmerHealth>().TakeDamage(_damage);
        }
    }

    void Awake() {
        _sprite = GetComponent<SpriteRenderer>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Spawned.Add(this, gameObject);
    }

    // Update is called once per frame
    void FixedUpdate() {
        Vector2 length = _playerTransform.position - transform.position;
        length.Normalize();

        transform.Translate(Time.deltaTime * _speed * length);

        if(length.x<0) {
            _sprite.flipX = true;
        } else {
            _sprite.flipX = false;
        }
    }

    public void TakeDamage(float damage) {
        _health -= damage;
        if(_health <= 0) {
            Instantiate(_expChip0, transform.position, transform.rotation);
            Spawned.Remove(this);
            Destroy(gameObject);
        }
    }
}
