using UnityEngine;

public class EmemySprite : MonoBehaviour
{
    private Transform _playerTransform;
    private SpriteRenderer _enemyRenderer;
    private Vector3 direction;
    //private bool _isRun = false;
    //public Animator anim;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        direction = _playerTransform.position - transform.position;
        // Debug.Log(direction);
        if (direction.x < 0) _enemyRenderer.flipX = true;
        else if (direction.x > 0) _enemyRenderer.flipX = false;
    } 

    /*
    private void OnTriggerEnter2D()
    {
        anim.SetTrigger("Hit");
    }
    */
}
