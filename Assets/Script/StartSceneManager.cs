using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // StartSceneManager Ŭ������ ����ϱ� ����

public class StartSceneManager : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("2. PlayScene"); // ���⵵ �Ȱ��ƾ� ��
    }
}