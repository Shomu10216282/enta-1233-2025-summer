using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] private Image HealthBarFill;
    [SerializeField] private int maxHp = 100;
    public AudioSource DamageSound;

    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
        if (HealthBarFill == null)
        {

        }
        UpdateHp(1f); 
    }

    [Obsolete]
    public void OnDamageTaken(int damage)
    {
        currentHp -= damage;
        UpdateHp((float)currentHp / maxHp);
        if (currentHp <= 0)
        {
            Die();
            Destroy(gameObject);
        }

        DamageSound.Play();
    }

    [Obsolete]
    private void Die()
    {
        Debug.Log("You are dead");

        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
    }

    /// <summary>
    /// Update the health bar UI
    /// </summary>
    /// <param name="hpPercent">Value from 0 to 1</param>
    public void UpdateHp(float hpPercent)
    {
        if (HealthBarFill != null)
        {
            HealthBarFill.fillAmount = Mathf.Clamp(hpPercent, 0, 1);
        }
    }
}
