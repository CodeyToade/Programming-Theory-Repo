using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainManager : LoadGameRankScript
{
    public bool isGameOver;

    public TextMeshProUGUI currentPlayerName;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI BestPlayerNameAndScore;

    public GameObject gameOverMenu;

    private float lives;
    private float score;

    private void Awake()
    {
        LoadGameRank();
    }

    void Start()
    {
        isGameOver = false;
        lives = 3;
        currentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        lifeText.text = "Life: " + lives;
        scoreText.text = "Score: " + score;

        SetBestPlayer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameOver();
        }
    }

    //Game Completion
    #region
    public void GameOver()
    {
            isGameOver = true;
            gameOverMenu.gameObject.SetActive(true);
            CheckBestPlayer();
    }

    private void CheckBestPlayer()
    {
        int CurrentScore = PlayerDataHandle.Instance.Score;

        if (CurrentScore > bestScore)
        {
            bestPlayer = PlayerDataHandle.Instance.PlayerName;
            bestScore = CurrentScore;

            bestPlayerName.text = $"Best Score - {bestPlayer}: {bestScore}";
        }
    }

    public void SaveGameRank(string bestPlayerName, int bestPlayerScore)
    {
        SaveData data = new SaveData();

        data.TheBestPlayer = bestPlayerName;
        data.HighestScore = bestPlayerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
