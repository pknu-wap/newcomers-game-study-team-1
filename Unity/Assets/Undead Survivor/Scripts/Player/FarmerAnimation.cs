using UnityEngine;

public class FarmerAnimation : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    void Start() {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 v = _rb.linearVelocity;
        if(v.x<0) {
            _sprite.flipX = true;
        } else if(v.x>0){
            _sprite.flipX = false;
        }

        if(v!=Vector2.zero) {
            _animator.SetBool("IsMoving", true);
        } else {
            _animator.SetBool("IsMoving", false);
        }
    }
}
