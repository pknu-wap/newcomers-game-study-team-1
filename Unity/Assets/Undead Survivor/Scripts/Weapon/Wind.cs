using System.Collections.Generic;
using System;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float Speed = 15f;
    private float _damage = 10f;
    private GameObject Player;

    private Rigidbody2D _rb;
    private uint _state = 0;

    private GameObject _near;

    void Awake() {
        Player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody2D>();
        _near = null;
        float dist = Single.MaxValue;
        float playerX = Player.transform.position.x, playerY = Player.transform.position.y;
        float enemyX, enemyY, newDist;
        foreach(KeyValuePair<Enemy,GameObject> kv in Enemy.Spawned) {
            enemyX = kv.Value.transform.position.x;
            enemyY = kv.Value.transform.position.y;
            newDist = (float)(Math.Pow(playerX - enemyX, 2) + Math.Pow(playerY - enemyY, 2));
            if(newDist<dist) {
                dist = newDist;
                _near = kv.Value;
            }
        }
        Debug.Log(_near);
    }

    void Update() {
        Vector3 length;
        switch(_state) {
            case 0:
                length = _near.transform.position - transform.position;
                length.Normalize();
                transform.Translate(Time.deltaTime * Speed * length);
                break;
            case 1:
                length = Player.transform.position - transform.position;
                length.Normalize();
                transform.Translate(Time.deltaTime * Speed * length);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            if(_state==1) {
                Destroy(gameObject);
            }
        } else if(other.CompareTag("Enemy")) {
            other.GetComponent<Enemy>().TakeDamage(_damage);
            _state = 1;
        }
    }
}
