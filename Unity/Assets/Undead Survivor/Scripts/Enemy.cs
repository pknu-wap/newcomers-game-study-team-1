using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform _playerTransform;
    private float speed = 4f;

    void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 length = _playerTransform.position - transform.position;
        length.Normalize();

        transform.Translate(Time.deltaTime * speed * length);

    }
}
