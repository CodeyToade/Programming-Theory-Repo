using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainManager : LoadGameRankScript
{
    private bool isGameActive;

    public TextMeshProUGUI CurrentPlayerName;
    public TextMeshProUGUI LifeText;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI BestPlayerNameAndScore;

    public GameObject[] rocketPrefabs;
    public GameObject GameOverMenu;

    private float Lives;
    private float Score;

    //private static int BestScore;
    //private static string BestPlayer;

    private void Awake()
    {
        LoadGameRank();
    }

    void Start()
    {
        //isGameActive = true;
        Lives = 3;
        CurrentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        LifeText.text = "Life: " + Lives;
        ScoreText.text = "Score: " + Score;

        //SetBestPlayer();
    }

    public void GameOver()
    {
        //isGameActive = false;
        GameOverMenu.gameObject.SetActive(true);
        CheckBestPlayer();
    }

    private void CheckBestPlayer()
    {
        int CurrentScore = PlayerDataHandle.Instance.Score;

        if (CurrentScore > BestScore)
        {
            BestPlayer = PlayerDataHandle.Instance.PlayerName;
            BestScore = CurrentScore;

            BestPlayerNameAndScore.text = $"Best Score - {BestPlayer}: {BestScore}";
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
}
