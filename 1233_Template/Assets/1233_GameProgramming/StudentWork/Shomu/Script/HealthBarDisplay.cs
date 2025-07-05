using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDisplay : MonoBehaviour
{
    [SerializeField] private Image HealthBarFill;
    [SerializeField] private int maxHp = 100;

    private int currentHp;

    void Start()
    {
        currentHp = maxHp;
        if (HealthBarFill == null)
        {

        }
        UpdateHp(1f); 
    }

    public void OnDamageTaken(int damage)
    {
        currentHp -= damage;
        UpdateHp((float)currentHp / maxHp);
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You are dead");
        Destroy(gameObject);
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
