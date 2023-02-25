using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

public class Skills : MonoBehaviour
{
    public int healthSkillValue = 0;
    public int damageSkillValue = 0;
    public int dexteritySkillValue = 0;

    private PlayerHealth playerHealth;
    private FirstPersonController fps;

    void Start()
    {
        fps = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Load();
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

    private void Save()
    {
        SaveData saveData = new SaveData(healthSkillValue, damageSkillValue, dexteritySkillValue);

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/savedata.dat");
            
        bf.Serialize(file, saveData);
    }
    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedata.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedata.dat", FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            healthSkillValue = saveData.healthSkillValue;
            damageSkillValue = saveData.damageSkillValue;
            dexteritySkillValue = saveData.dexteritySkillValue;
        }
        else
        {
            healthSkillValue = 0;
            damageSkillValue = 0;
            dexteritySkillValue = 0;
        }
    }

    private void OnDestroy()
    {
        Save();
    }
}
