using UnityEngine;
using System.Collections.Generic;

public class WeaponSelector : MonoBehaviour
{
    public GameObject[] Weapons;
    public uint WeaponIndex = 1;

    private bool[] _coroutineState = new bool[3] { false, false, false };

    void Update() {
        switch(WeaponIndex) {
            case 0:
                if(!_coroutineState[0]) {
                    _coroutineState[0] = true;
                    StartCoroutine(ShotTriden());
                }
                break;
            case 1:
                if(!_coroutineState[1]) {
                    _coroutineState[1] = true;
                    StartCoroutine(ShotWind());
                }
                break;
        }
    }

    IEnumerator<WaitForSeconds> ShotTriden() {
        while(true) {
            if(WeaponIndex!=0) {
                _coroutineState[0] = false;
                yield break;
            }

            GameObject t = Instantiate(Weapons[0], transform.position, Quaternion.identity);
            
            Vector2 direction = gameObject.GetComponent<Rigidbody2D>().linearVelocity;
            if(direction == Vector2.zero) {
                direction = new Vector2(1, 0);
                if(gameObject.GetComponent<SpriteRenderer>().flipX) {
                    direction *= -1;
                }
            } else {
                direction.Normalize();
            }
            Debug.Log(direction);
            t.GetComponent<Triden>().Shot(transform.position, direction);
            
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator<WaitForSeconds> ShotWind() {
        while(true) {
            if(WeaponIndex!=1) {
                _coroutineState[1] = false;
                yield break;
            }

            if(Enemy.Spawned.Count != 0) {
                Debug.Log("add");
                Instantiate(Weapons[1], transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(3);
        }
    }
}
