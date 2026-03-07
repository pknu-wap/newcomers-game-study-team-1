using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private GameObject Player;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x, 
            Player.transform.position.y, 
            -10);
    }
}
