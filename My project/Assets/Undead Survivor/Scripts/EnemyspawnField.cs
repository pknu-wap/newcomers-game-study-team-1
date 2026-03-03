using UnityEngine;

public class EnemyspawnField : MonoBehaviour
{

    private float randomNum;
    private float PositionX;
    private float PositionY;
    public float _currntTime;
    private Transform _playerTransform;
    [SerializeField] private GameObject Enemy;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        _currntTime += Time.deltaTime;
        if (_currntTime > 0.5)
        {
            randomNum = Random.Range(-6.0f, 6.0f);
            PositionX = _playerTransform.transform.position.x + randomNum;
            if (Random.Range(0,2) == 1)
            {
                PositionY = Mathf.Pow(36 - Mathf.Pow(randomNum, 2), 0.5f);
                Instantiate(Enemy, new Vector3(PositionX, PositionY, 0), transform.rotation);        
                _currntTime = 0;
                Debug.Log("x: " + PositionX + "y: " + PositionY + ", " + _currntTime + "초 잔여");
            }
                else
            {
                PositionY = -Mathf.Pow(36 - Mathf.Pow(randomNum, 2), 0.5f);
                Instantiate(Enemy, new Vector3(PositionX, PositionY, 0), transform.rotation);        
                _currntTime = 0;
                Debug.Log("x: " + PositionX + "y: " + PositionY + ", " + _currntTime + "초 잔여");
            }
        }
        
    }
}
