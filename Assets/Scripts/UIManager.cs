using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] public GameObject youWinScene;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void YouWin()
    {
        youWinScene.SetActive(true);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}