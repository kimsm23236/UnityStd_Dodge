using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<GameObject> BulletList;
    public GameObject bulletPrefab;

    public int bulletMax = 50;

    // Start is called before the first frame update
    void Start()
    {
        BulletList = new List<GameObject>();
        for(int i = 0 ; i < bulletMax; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // bullet.SetActive(false);
            BulletList.Add(bullet);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SetCall()
    {
        GameObject newbullet = default;
        foreach(var bullet in BulletList)
        {
            Bullet bc = bullet.GetComponent<Bullet>();
            if(!bc.isActive)
            {
                newbullet = bullet;
                break;
            }
        }
        return newbullet;
    }
}
