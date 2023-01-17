using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity 할당
        playerRigidbody.velocity = newVelocity;
    }   // Update()
    public void LegacyMove()
    {
        if(Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f,0f,speed);
        }
        if(Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRigidbody.AddForce(0f,0f,-speed);
        }
        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRigidbody.AddForce(speed,0f,0f);
        }
        if(Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRigidbody.AddForce(-speed,0f,0f);
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name}이 죽었음");
        gameObject.SetActive(false);
        gameManager.EndGame();
    }       // Die()
}
