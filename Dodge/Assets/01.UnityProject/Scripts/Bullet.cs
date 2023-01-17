using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isActive;
    public float bulletSpeed = 8f;
    private Rigidbody bulletRigidbody = default;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        bulletRigidbody = gameObject.GetComponent<Rigidbody>();
        gameObject.SetActive(false);

        // 수정 가능성 있음
        // bulletRigidbody.velocity = transform.forward * bulletSpeed;

        // 탄알이 3초 뒤에 스스로 파괴되는 코드
        // Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 총알이 무언가와 부딪혔을 때 실행되는 함수
    void OnTriggerEnter(Collider other)
    {
        if(!isActive)
        {
            return;
        }
        // Debug.Log("OnTrigger");
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if(other.tag == "Player")
        {
            // 충돌체로부터 플레이어컨트롤러 컴포넌트 받아오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if(playerController != null)
            {
                playerController.Die();
            }
        }

        if(other.tag == "Wall")
        {
            UnSet();
        }
    }

    public void OnSet()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
    public void UnSet()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    public void SetVelo()
    {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }

}
