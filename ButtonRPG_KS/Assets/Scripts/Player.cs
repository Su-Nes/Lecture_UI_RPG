using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [SerializeField] private TMP_Text shieldButtonText;
    [SerializeField] private int shieldStrength = 5;
    public int ShieldStrength { get => shieldStrength; }
    [SerializeField] private int shieldShatterChance = 7;
    public int ShieldShatterChance { get => shieldShatterChance; }
    private bool shieldActive, shieldBroken;

    private int playerLevel = 1;
    public int PlayerLevel { get => playerLevel; }
    [SerializeField] private float requiredXP = 10f;
    public float RequiredXP { get => requiredXP; }
    [SerializeField] private float XPRequirementGrowth = 1.5f;
    public float currentXP { get; private set; } // auto property
    [SerializeField] private GameObject levelUpScreen;
    
    
    public override void GetHit(int damage, string hitCulprit = "Character")
    {
        CombatLog.Instance.AddLog($"{hitCulprit} tries to hit {charName}!");

        int defenseValue = shieldActive ? armorClass + shieldStrength : armorClass; // if shield active, add shield armor value to armorClass
        
        if (GameManager.RollD20(hitCulprit) >= defenseValue) // roll for the attack hitting like it's DnD
        {
            health -= damage;
            CombatLog.Instance.AddLog($"{charName} got hit for {damage} damage!");
        }
        else
        {
            if (shieldActive)
            {
                if (GameManager.RollD20(charName) <= shieldShatterChance)
                {
                    ToggleShield();
                    shieldBroken = true;
                    CombatLog.Instance.AddLog($"{charName}'s shield broke!");
                }
                else
                {
                    CombatLog.Instance.AddLog($"{charName}'s shield survives the hit!");
                }
            }
            else
            {
                print($"{hitCulprit}'s attack misses!");
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }
    
    public override void GetHit(int damage, Enemy hitCulprit)
    {
        CombatLog.Instance.AddLog($"{hitCulprit.CharName} tries to hit {charName}!");
        
        if (GameManager.RollD20(hitCulprit.CharName) >= armorClass) // roll for the attack hitting like it's DnD
        {
            health -= damage;
            CombatLog.Instance.AddLog($"{charName} got hit for {damage} damage!");
        }
        else
        {
            if (shieldActive)
            {
                if (GameManager.RollD20(charName) <= shieldShatterChance)
                {
                    ToggleShield();
                    shieldBroken = true;
                    CombatLog.Instance.AddLog($"{charName}'s shield broke!");
                }
                else
                {
                    CombatLog.Instance.AddLog($"{charName}'s shield survives the hit!");
                }
            }
            else
            {
                print($"{hitCulprit.CharName}'s attack misses!");
            }
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void ToggleShield()
    {
        if (shieldBroken)
        {
            CombatLog.Instance.AddLog("Your shield needs repairs!");
            return;
        }
        
        shieldActive = !shieldActive;
        
        if (shieldActive)
        {
            shieldButtonText.text = "Lower shield";
            armorClass += shieldStrength;
        }
        else
        {
            shieldButtonText.text = "Raise shield";
            armorClass -= shieldStrength;
        }
        
        GameManager.Instance.UpdateCharacterText();
    }
    
    public void IncreaseExperience(int value)
    {
        currentXP += value;

        if (currentXP >= requiredXP)
        {
            LevelUp();
            return;
        }

        GameManager.Instance.UpdateCharacterText();
    }

    private void LevelUp()
    {
        playerLevel++;
        
        levelUpScreen.SetActive(true);
        currentXP -= requiredXP;
        requiredXP *= XPRequirementGrowth;
        
        CombatLog.Instance.AddLog($"{charName} has leveled up!");
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

    public void IncreaseShieldLevel()
    {
        shieldBroken = false;
        
        shieldStrength++;
        shieldShatterChance--;
        if (shieldShatterChance < 0)
            shieldShatterChance = 0;
        FinishLevelUp();
    }

    private void FinishLevelUp()
    {
        levelUpScreen.SetActive(false);
        GameManager.Instance.UpdateCharacterText();
    }
    
    protected override void Die()
    {
        GameManager.Instance.GameOver();
    }
}
