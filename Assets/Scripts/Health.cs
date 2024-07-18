using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    public float StartingHealth => startingHealth;
    public Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (dead) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth <= 0 && !dead)
        {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
            dead = true;

            HiddenGem hiddenGem = FindObjectOfType<HiddenGem>();
            if (hiddenGem != null)
            {
                hiddenGem.PlayerDie();
            }
        }
    }

    public void DecreaseHealthOverTime(float amount)
    {
        if (!dead)
        {
            TakeDamage(amount * Time.deltaTime);
        }
    }

    public bool IsDead()
    {
        return dead;
    }
}