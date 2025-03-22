using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private TMP_Text shieldText;
    [SerializeField] private int shieldStrength = 5;
    [SerializeField] private float shieldShatterChance = .25f;
    
    [SerializeField] private TMP_Text XPText;
    [SerializeField] private float requiredXP = 10f;
    [SerializeField] private float XPRequirementGrowth = 1.5f;
    private float currentXP;
    [SerializeField] private GameObject levelUpScreen;
    
    
    public void IncreaseExperience(int value)
    {
        currentXP += value;

        if (currentXP >= requiredXP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        levelUpScreen.SetActive(true);
        currentXP -= requiredXP;
        requiredXP *= XPRequirementGrowth;
    }
    
    public void IncreaseMaxHealth(int value)
    {
        maxHealth += value;
        health = maxHealth;
        FinishLevelUp();
    }

    public void IncreaseStrength(int value)
    {
        strength += value;
        FinishLevelUp();
    }

    private void FinishLevelUp()
    {
        levelUpScreen.SetActive(false);
        UpdateCharacterText();
    }

    protected override void UpdateCharacterText()
    {
        base.UpdateCharacterText();

        shieldText.text = $"Shield value: {shieldStrength}\nChance to shatter: {shieldShatterChance}";
        XPText.text = $"{currentXP:N0}/{requiredXP:N0}"; // :N0 means it's displayed as an integer. shorthand for .ToString("N0")
    }
    
    protected override void Die()
    {
        GameManager.Instance.GameOver();
    }
}
