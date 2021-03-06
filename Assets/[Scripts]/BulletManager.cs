using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public Queue<GameObject> bulletPool;
    public int bulletNumber;
    public GameObject bulletPrefab;
    
    private void Start()
    {
        bulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < bulletNumber; i++)
        {
            var temp_bullet = Instantiate(bulletPrefab);
            temp_bullet.SetActive(false);
            temp_bullet.transform.SetParent(transform);
            bulletPool.Enqueue(temp_bullet);
        }
    }

    public GameObject GetBullet(Vector2 position)
    {
        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = position;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void ReturnBullet(GameObject returned_bullet)
    {
        returned_bullet.SetActive(false);
        bulletPool.Enqueue(returned_bullet);
    }
}
