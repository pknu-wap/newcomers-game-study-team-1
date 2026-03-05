using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    private float _speed = 250f;

    void Update() {
        transform.RotateAround(transform.parent.position, Vector3.back, Time.deltaTime * _speed);
        transform.RotateAround(transform.position, Vector3.back, Time.deltaTime * _speed);
    }
}
