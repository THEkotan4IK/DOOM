using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum SkillType
{
    Health,
    Damage,
    Dexterity
}
public class SkillSlot : MonoBehaviour
{
    [SerializeField]GameObject fillerFrame;
    private Image[] fillerImages;
    [SerializeField] int skillValue = 0;
    [SerializeField] Text priceText;
    private XPSystem XPsystem;

    void Start()
    {
        XPsystem = GameObject.FindGameObjectWithTag("XPSystem").GetComponent<XPSystem>();
        fillerImages = fillerFrame.GetComponentsInChildren<Image>();
        RenderSkill();
    }

    public void PlusButtonClick()
    {
        int spaceIndex = priceText.text.IndexOf(' ');
        int price = int.Parse(priceText.text.Substring(0, spaceIndex));

        if(XPsystem.score >= price)
        {
            if (ChangeSkillValue(1))
            {
                XPsystem.ChangeScore(-price);
            }
        }
    }

    public bool ChangeSkillValue(int value)
    {
        if(skillValue + value > fillerImages.Length)
        {
            skillValue = fillerImages.Length;
            return false;
        }
        skillValue += value;
        RenderSkill();
        return true;
    }

    private void RenderSkill()
    {
        for (int i = 1; i < fillerImages.Length; i++)
        {
            fillerImages[i].enabled = false;
        }

        for (int i = 0; i < skillValue; i++)
        {
            fillerImages[i + 1].enabled = true;
        }
    }

    void Update()
    {

    }

    private void ApplyHealthSkill()
    {

    }

    private void ApplyDamageSkill()
    {
        
    }

    private void ApplyDexteritySkill()
    {

    }
}
