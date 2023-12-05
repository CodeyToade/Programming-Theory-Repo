using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainManager : LoadGameRankScript //Inheritance
{
    #region Variables

    public bool isGameOver;

    public TextMeshProUGUI currentPlayerName;
    public TextMeshProUGUI lifeText;

    public GameObject gameOverMenu;

    private float lives;

    #endregion

    private void Awake()
    {
        LoadGameRank();
    }

    void Start()
    {
        isGameOver = false;
        currentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        SetBestPlayer();
        UpdateLife(3);
        EventManager.OnTimerStart();
    }

    private void Update()
    {
        if (lives <= 0 || Input.GetKeyDown(KeyCode.P))
        {
            GameOver();
        }
    }
    
    public void UpdateLife(int lifeToAdd)
    {
        lives += lifeToAdd;
        lifeText.text = "Life: " + lives;
    }

    #region Game Completion
    public void GameOver()
    {
        EventManager.OnTimerStop();
        isGameOver = true;
        gameOverMenu.gameObject.SetActive(true);
        SetBestPlayer();
    }

    public override void SetBestPlayer() //Polymorphism
    {
        int CurrentScore = PlayerDataHandle.Instance.Score;

        if (CurrentScore > bestTime)
        {
            bestPlayer = PlayerDataHandle.Instance.PlayerName;
            bestTime = CurrentScore;

            bestPlayerName.text = $"Best Score - {bestPlayer}: {bestTime}";
        }
    }

    public void SaveGameRank(string bestPlayerName, int bestPlayerTime)
    {
        SaveData data = new SaveData();

        data.TheBestPlayer = bestPlayerName;
        data.MostTime = bestPlayerTime;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion
}
