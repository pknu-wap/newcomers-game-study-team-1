using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    private const float Speed = 50f;

    private void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.back, Speed * Time.deltaTime);
    }
}