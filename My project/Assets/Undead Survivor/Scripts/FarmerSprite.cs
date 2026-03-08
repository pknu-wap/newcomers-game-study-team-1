using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerSprite : MonoBehaviour
{
    private SpriteRenderer FarmerRenderer;
    private Vector3 FarmermoveDirection;

    void Start()
    {
        FarmerRenderer = GetComponent<SpriteRenderer>();
    }
    /*
    private void Update()
    { 
        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            FarmerRenderer.flipX = true;
            Debug.Log("좌로!");
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            Debug.Log("우로!");
            FarmerRenderer.flipX = false;
        }
    }
    */

    private void OnMove(InputValue value)
    {
        FarmermoveDirection = value.Get<Vector2>();
    }
    private void Update()
    {
        Debug.Log(FarmermoveDirection);
        if (FarmermoveDirection.x < 0)
        {
            FarmerRenderer.flipX = true;
        }
        else if (FarmermoveDirection.x > 0)
        {
            FarmerRenderer.flipX = false;
        }
    } 



}
