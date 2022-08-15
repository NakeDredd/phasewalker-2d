using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI levelText;

    public int levelIndex;

    public delegate void LevelButtonEvents(int leveIndex);
    public static event LevelButtonEvents OnLevelButtonClick;


    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(SendLevelToLoad);
        levelText.text = levelIndex + 1.ToString();
    }

    private void OnDisable()
    {
        this.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void SendLevelToLoad()
    {
        OnLevelButtonClick.Invoke(levelIndex);

    }
}
