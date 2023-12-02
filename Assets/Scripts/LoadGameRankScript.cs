using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LoadGameRankScript : MonoBehaviour
{
    public TextMeshProUGUI bestPlayerName;

    protected static int bestScore;
    protected static string bestPlayer;

    private void Awake()
    {
        LoadGameRank();
    }

    protected void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Score - {bestPlayer}: {bestScore}";
        }
    }

    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.TheBestPlayer;
            bestScore = data.HighestScore;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    protected class SaveData
    {
        public int HighestScore;
        public string TheBestPlayer;
    }
}