using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public SaveData(int healthValue, int damageValue, int dexterityValue)
    {
        healthSkillValue = healthValue;
        damageSkillValue = damageValue;
        dexteritySkillValue = dexterityValue;
    }

    public int healthSkillValue = 0;
    public int damageSkillValue = 0;
    public int dexteritySkillValue = 0;
}
