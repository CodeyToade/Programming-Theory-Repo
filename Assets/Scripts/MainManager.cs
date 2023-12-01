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
    public TextMeshProUGUI LifetimeText;
    private float Lives;
    private float Time;
    public GameObject GameOverMenu;

    void Start()
    {
        isGameActive = true;
        Lives = 3;
        CurrentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
        LifeText.text = "Life: " + Lives;
        LifetimeText.text = "Lifetime: " + Time;
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
