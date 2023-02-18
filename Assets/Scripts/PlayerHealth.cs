using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]public int maxHealth;
    [HideInInspector]public int health;
    public Image hpFiller;
    public Text hpText;

    void Start()
    {
        health = maxHealth;
        RenderHP();
    }
    public void ChangeHealth(int value)
    {
        RenderHP();
        health += value;
        if (value > 0)
        {
            print($"Вы получили {value} здоровья");
        }
        else
        {
            print($"Вы получили {value} урона");
        }

        if (health <= 0)
        {
            Die();
        }
    }
    public void RenderHP()
    {
        hpFiller.fillAmount = (float)health / maxHealth;
        hpText.text = health.ToString();
    }

    private void Die()
    {
        RenderHP();
        SceneManager.LoadScene(0);
    }
}
