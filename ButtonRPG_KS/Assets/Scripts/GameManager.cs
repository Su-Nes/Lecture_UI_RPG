using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject[] enemies;
    private Enemy currentEnemy;
    
    [SerializeField] private TMP_Text playerNameText, playerHealthText, playerStrengthText, playerArmorClassText, shieldText, XPText, enemyNameText, enemyHealthText, enemyStrengthText, enemyArmorClassText;
    [SerializeField] private GameObject gameOverScreen;
    
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
    
    private void Start()
    {
        playerNameText.text = player.CharName;
        
        InitialiseEnemy();
    }

    public void InitialiseEnemy()
    {
        currentEnemy = enemies[Random.Range(0, enemies.Length)].GetComponent<Enemy>();
        currentEnemy.Awake();
        
        CombatLog.Instance.AddLog($"A new challenger approaches! It's {currentEnemy.CharName}!");
        
        enemyNameText.text = currentEnemy.CharName;
        
        UpdateCharacterText();
    }
    
    public void DoRound()
    {
        CombatLog.Instance.ClearLogs();
        
        int playerDamage = player.Attack();
        currentEnemy.GetHit(playerDamage, player.CharName);
        int enemyDamage = currentEnemy.Attack();
        player.GetHit(enemyDamage, currentEnemy);
        
        UpdateCharacterText();
    }
    
    public void UpdateCharacterText()
    {
        playerHealthText.text = $"Health: {player.Health}";
        playerStrengthText.text = $"Strength: {player.Strength}";
        playerArmorClassText.text = $"Armor class: {player.ArmorClass}";
        shieldText.text = $"Shield value: {player.ShieldStrength}\nShatter chance: {player.ShieldShatterChance}";
        XPText.text = $"Level: {player.PlayerLevel}\nXP: {player.currentXP:N0}/{player.RequiredXP:N0}"; // :N0 means it's displayed as an integer. shorthand for .ToString("N0")

        enemyHealthText.text = $"Health: {currentEnemy.Health}";
        enemyStrengthText.text = $"Strength: {currentEnemy.Strength}";
        enemyArmorClassText.text = $"Armor class: {currentEnemy.ArmorClass}";
    }

    public void GameOver()
    {
        CombatLog.Instance.AddLog($"{player.CharName} perishes in battle..."); 
        gameOverScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public static int RollD20(string characterWhoRolled)
    {
        int rollResult = Random.Range(1, 21);
        CombatLog.Instance.AddLog($"{characterWhoRolled} rolls {rollResult}.");
        return rollResult;
    }
}
