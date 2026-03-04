using UnityEngine;
using UnityEngine.InputSystem;

public class FarmerSprite : MonoBehaviour
{
    SpriteRenderer FarmerRenderer;
    void Start()
    {
        FarmerRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    { 
    ///철자하나틀려서찾느라1시간날렸네개멍청하다진짜Update는7글자가아니에요선생님
    ///이거하나구현하려고이고생을해야하는거야?완전코딩개못하잖아...
    ///무계획으로구현하고보니까방법이잘못된거같다는나쁜말은ㄴㄴㄴ
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
}