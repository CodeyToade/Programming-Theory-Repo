using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class LoadGameRankScript : MonoBehaviour
{
    public TextMeshProUGUI bestPlayerName;

    protected static int bestTime;
    protected static string bestPlayer;

    private void Awake()
    {
        LoadGameRank();
    }

    public virtual void SetBestPlayer()
    {
        if (bestPlayer == null && bestTime == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Time - {bestPlayer}: {bestTime}";
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
            bestTime = data.MostTime;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    protected class SaveData
    {
        public int MostTime;
        public string TheBestPlayer;
    }
}