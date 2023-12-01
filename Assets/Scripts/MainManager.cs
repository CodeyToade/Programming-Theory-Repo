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
    public GameObject GameOverMenu;

    void Start()
    {
        isGameActive = true;
        CurrentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
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
