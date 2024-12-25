using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ScoreManager.Instance.isPlayerAlive) {
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }
    }
}
