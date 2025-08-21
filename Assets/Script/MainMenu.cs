using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject howToPlayPanel; // 설명창 패널'

    void Start()
    {
        // 시작 시 설명창은 꺼져 있음
       // howToPlayPanel.SetActive(false);

    }

    // 게임 시작 버튼 눌렀을 때
    public void OnStartGameClicked()
    {
        Debug.Log("게임 시작 버튼 클릭됨!");
        SceneManager.LoadScene(1); // 게임 씬으로 이동
    }

    // 설명 보기 버튼 눌렀을 때
    public void OnHowToPlayClicked()
    {
        howToPlayPanel.SetActive(true); // 설명창 열기
    }

    public void OnExitGameClicked()
    {
        Debug.Log("게임 종료 버튼 클릭됨!");
        Application.Quit(); // 게임 종료
    }

    // 설명창에서 뒤로 버튼 눌렀을 때
    public void OnBackClicked()
    {
        howToPlayPanel.SetActive(false); // 설명창 닫기
    }
}