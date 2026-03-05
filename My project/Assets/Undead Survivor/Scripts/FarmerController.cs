using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerController : MonoBehaviour
{
    private Vector3 _Direction;
    private bool _isRun = false;

    public Animator anim;

    private void OnMove(InputValue value)
    {
        _Direction = value.Get<Vector2>();
    }

    void Update()
    {
        if (_Direction.x == 0 && _Direction.y == 0)
        {
            _isRun = true;
        }
        else _isRun = false;
        anim.SetBool("Run", _isRun);
    }

}
