using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        Exit.OnLevelComplete += TryToLoadNextLevel;
    }

    private void OnDisable()
    {
        Exit.OnLevelComplete -= TryToLoadNextLevel;
    }

    private void TryToLoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
