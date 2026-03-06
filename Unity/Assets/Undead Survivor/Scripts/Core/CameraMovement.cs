using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject player;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 dist = player.transform.position - transform.position;
        transform.position += (Vector3) dist;
    }
}
