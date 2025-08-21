using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject howToPlayPanel; // ����â �г�'

    void Start()
    {
        // ���� �� ����â�� ���� ����
       // howToPlayPanel.SetActive(false);

    }

    // ���� ���� ��ư ������ ��
    public void OnStartGameClicked()
    {
        Debug.Log("���� ���� ��ư Ŭ����!");
        SceneManager.LoadScene(1); // ���� ������ �̵�
    }

    // ���� ���� ��ư ������ ��
    public void OnHowToPlayClicked()
    {
        howToPlayPanel.SetActive(true); // ����â ����
    }

    public void OnExitGameClicked()
    {
        Debug.Log("���� ���� ��ư Ŭ����!");
        Application.Quit(); // ���� ����
    }

    // ����â���� �ڷ� ��ư ������ ��
    public void OnBackClicked()
    {
        howToPlayPanel.SetActive(false); // ����â �ݱ�
    }
}