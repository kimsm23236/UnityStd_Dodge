using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    public Transform targetTransf;
    private float spawnRate = default;
    private float timeAfterSpawn = default;

    // Manager 
    private BulletManager bulletManager = default;

    // Rotate
    public float RotateSpeed;



    // Start is called before the first frame update
    void Start()
    {
        //BulletManager bm = 
        bulletManager = GameObject.FindWithTag("BulletManager").GetComponent<BulletManager>();
        if(bulletManager == null)
        {
            Debug.LogError("BulletManager is Null");
        }
        timeAfterSpawn = 0f;
        // spawnRate = Random.Range(spawnRateMin, spawnRateMax);

    }

    // Update is called once per frame
    void Update()
    {
        OwnerRotate();
        // timeAfterSpawn 갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서부터 누적된 시간이 생성 주기보다 크거나 같다면
        if(timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간을 리셋
            timeAfterSpawn = 0f;

            // bulletPrefab의 복제본을
            // transform.position 위치와 transform.rotation 회전으로 생성
            // GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            ReqSetupBullet();
            // 생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            // bullet.transform.LookAt(targetTransf);
            // 다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    void ReqSetupBullet()
    {
        if(bulletManager == null || bulletManager == default)
        {
            Debug.LogError("BulletManager is Null");
            return;
        }
        GameObject newBullet = bulletManager.SetCall();

        if(newBullet == null || newBullet == default)
        {
            Debug.LogError("newBullet is Null");
            return;
        }
        // newBullet.SetActive(false);

        Bullet bc = newBullet.GetComponent<Bullet>();

        if(bc == null)
        {
            return;
        }

        bc.transform.position = transform.position;
        bc.transform.rotation = transform.rotation;
        bc.SetVelo();
        bc.OnSet();
    }

    public void OwnerRotate()
    {
        transform.Rotate(new Vector3(0f, 5.0f, 0f) * Time.deltaTime * RotateSpeed);
    }   

}
