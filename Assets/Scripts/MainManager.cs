using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    private bool isGameActive;
    public TextMeshProUGUI CurrentPlayerName;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI ScoreText;
    private float Lives;
    private float Score;
    public GameObject GameOverMenu;

    void Start()
    {
        isGameActive = true;
        Lives = 3;
        CurrentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        LifeText.text = "Life: " + Lives;
        ScoreText.text = "Score: " + Score;
    }

    public void GameOver()
    {
        isGameActive = false;
        GameOverMenu.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
