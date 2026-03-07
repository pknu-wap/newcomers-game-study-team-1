using UnityEngine;

public class TileGenerator: MonoBehaviour
{
    public GameObject Player;

    public GameObject GrassTile0;
    public GameObject GrassTile1;
    public GameObject GrassTile2;
    public GameObject StoneTile;

    public uint XRange;
    public uint YRange;

    void Awake() {
        if(XRange % 2 == 0) XRange++;
        if(YRange % 2 == 0) YRange++;

        Vector3 playerPos = Player.transform.position;
        int i, j;
        int originX = (int) playerPos.x, originY = (int) playerPos.y;
        for(i=0; i<YRange; i++) {
            for(j=0; j<XRange; j++) {
                Instantiate(GrassTile1, new Vector2(originX-(XRange/2)+j, originY-(YRange/2)+i), Quaternion.identity);
            }
        }
    }

    void Update() {
        
    }
}
