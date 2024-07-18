using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] public Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private float healthDecreaseRate = 0.0001f;
    [SerializeField] private float maxTime = 60f;

    private float currentTime;

    private void Start()
    {
        currentTime = maxTime;

        if (playerHealth != null)
        {
            totalHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.StartingHealth;
            currentHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.StartingHealth;
        }
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            playerHealth.DecreaseHealthOverTime(healthDecreaseRate);
            currentHealthBar.fillAmount = playerHealth.currentHealth / playerHealth.StartingHealth;
        }
    }
}