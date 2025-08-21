using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isEnd = false;
    public int Score = 0;
    public GameObject Death;
    public TextMeshProUGUI ScoreText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Death.SetActive(false);
    }

    public void EndGame()
    {
        isEnd = true;
        Death.SetActive(true);
    }

    private void Update()
    {
        ScoreText.text = "SCORE : " + Score;
    }

    public void ReTry()
    {
        SceneManager.LoadScene(1);

    }

}