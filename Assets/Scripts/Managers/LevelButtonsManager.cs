using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonsManager : MonoBehaviour
{
    [SerializeField] private int levels;
    [SerializeField] private GameObject levelButton;
    [SerializeField] private GameObject gridLayoutGroup;

    private void Awake()
    {
        LevelButton.OnLevelButtonClick += LoadLevel;
    }

    private void OnDisable()
    {
        LevelButton.OnLevelButtonClick -= LoadLevel;
    }

    private void Start()
    {
        for (int i = 0; i < levels; i++)
        {
            LevelButton curlevelbutton = Instantiate(levelButton, gridLayoutGroup.transform).GetComponent<LevelButton>();
            curlevelbutton.levelIndex = i;
        }
    }

    private void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
