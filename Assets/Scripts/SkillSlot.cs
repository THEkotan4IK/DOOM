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

    [SerializeField] SkillType skillType;
    private Skills skills;

    void Start()
    {
        skills = GameObject.FindGameObjectWithTag("SkillSystem").GetComponent<Skills>();
        XPsystem = GameObject.FindGameObjectWithTag("XPSystem").GetComponent<XPSystem>();
        fillerImages = fillerFrame.GetComponentsInChildren<Image>();
        LoadSkills();
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
        ApplySkill();
    }

    private void ApplySkill()
    {
        switch (skillType)
        {
            case SkillType.Health:
                skills.ChangeHealthSkill(skillValue);
                break;
            case SkillType.Damage:
                skills.ChangeDamageSkill(skillValue);
                break;
            case SkillType.Dexterity:
                skills.ChangeDexteritySkill(skillValue);
                break;
            default:
                break;
        }
    }

    private void LoadSkills()
    {
        switch (skillType)
        {
            case SkillType.Health:
                skillValue = skills.healthSkillValue;
                break;
            case SkillType.Damage:
                skillValue = skills.damageSkillValue;
                break;
            case SkillType.Dexterity:
                skillValue = skills.dexteritySkillValue;
                break;
            default:
                break;
        }
    }
}
