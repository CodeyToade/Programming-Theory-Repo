using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainManager : MonoBehaviour
{
    public TextMeshProUGUI CurrentPlayerName;

    void Start()
    {
        CurrentPlayerName.text = PlayerDataHandle.Instance.PlayerName;
    }
}
