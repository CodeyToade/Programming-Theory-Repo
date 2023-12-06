using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    #region Variables

    public bool isGameOver;

    public TextMeshProUGUI currentPlayerName;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI bestPlayerNameAndTime;

    public GameObject gameOverMenu;

    private Timer timer;

    private float lives;

    private static int bestTime;
    private static string bestPlayerName;

    #endregion

    private void Awake()
    {
        LoadGameRank();
    }

    void Start()
    {
        isGameOver = false;
        currentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        timer = GameObject.Find("Time Text").GetComponent<Timer>();
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
        CheckBestPlayer();
        gameOverMenu.gameObject.SetActive(true);
    }

    private void CheckBestPlayer()
    {
        int CurrentTime = (int)timer.timeToDisplay;

        if (CurrentTime > bestTime)
        {
            bestPlayerName = PlayerDataHandle.Instance.PlayerName;
            bestTime = CurrentTime;

            bestPlayerNameAndTime.text = $"Best Time - {bestPlayerName}: {bestTime}";

            SaveGameRank(bestPlayerName, bestTime);
        }
    }

    
    private void SetBestPlayer()
    {
        if (bestPlayerName == null && bestTime == 0)
        {
            bestPlayerNameAndTime.text = "";
        }
        else
        {
            bestPlayerNameAndTime.text = $"Best Score - {bestPlayerName}: {bestTime}";
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

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayerName = data.TheBestPlayer;
            bestTime = data.MostTime;
            SetBestPlayer();
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    [System.Serializable]
    protected class SaveData
    {
        public int MostTime;
        public string TheBestPlayer;
    }
}
