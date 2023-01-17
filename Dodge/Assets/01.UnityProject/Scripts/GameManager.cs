using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText = default;
    public TMP_Text timeText = default;
    public TMP_Text recordText = default;
    private float surviveTime = default;

    private const string SCENE_NAME = "SampleScene";
    private const string BEST_TIME_RECORD = "BestTime";

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SCENE_NAME);
            } // if : R키를 이용해 리스타트

            if(Input.GetKeyDown(KeyCode.Q))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif

            }

        } // if : 게임 오버인 경우
        

        // 게임오버가 아닌 경우
        // 생존 시간 갱신
        surviveTime += Time.deltaTime;
        // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
        timeText.text = $"Time : {Mathf.FloorToInt(surviveTime)}";
    }

    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);
        gameoverText.transform.localScale = Vector3.one;

        // BestTime 키로 저장된 이전까지의 최고 기록 가져오기
        float bestTime = PlayerPrefs.GetFloat(BEST_TIME_RECORD);
        // 이전까지의 최고 기록보다 현재 생존 시간이 더 긴 경우
        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat(BEST_TIME_RECORD, bestTime);
        } // 현재 surviveTime이 bestTime보다 큰 경우

        // 최고 기록을 텍스트에 갱신한다.
        recordText.text = $"Best Time : {Mathf.FloorToInt(bestTime)}";
        recordText.transform.localScale = Vector3.one;
    } // EndGame()
}
