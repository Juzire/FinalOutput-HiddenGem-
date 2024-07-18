using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HiddenGem : MonoBehaviour
{
    [SerializeField] private GameObject youWinScene;
    [SerializeField] private GameObject gameOverScreen;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        youWinScene.SetActive(false);
        gameOverScreen.SetActive(false);
        playerHealth = FindObjectOfType<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowYouWin();
        }
    }

    void ShowYouWin()
    {
        youWinScene.SetActive(true);
    }

    public void PlayerDie()
    {
        ShowGameOver();
    }

    void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
