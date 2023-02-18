using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Skills : MonoBehaviour
{
    private int healthSkillValue = 0;
    private int damageSkillValue = 0;
    private int dexteritySkillValue = 0;

    private PlayerHealth playerHealth;
    private FirstPersonController fps;

    void Start()
    {
        fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void ChangeHealthSkill(int newValue)
    {
        healthSkillValue = newValue;
        playerHealth.maxHealth = 100 + 25 * newValue;
        playerHealth.health = 100 + 25 * newValue;
        playerHealth.RenderHP();
    }

    public void ChangeDamageSkill(int newValue)
    {
        damageSkillValue = newValue;
    }

    public void ChangeDexteritySkill(int newValue)
    {
        dexteritySkillValue = newValue;
        fps.MoveSpeed += 0.3f;
        fps.SprintSpeed += 0.3f;
        fps.JumpHeight += 0.1f;

    }
}
