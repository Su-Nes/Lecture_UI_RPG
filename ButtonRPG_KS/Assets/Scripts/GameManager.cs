using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy[] enemies;
    private Enemy currentEnemy;
    
    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText;
    
    private void Start()
    {
        playerNameText.text = player.CharName;
        playerHealthText.text = "Health: " + player.Health;
        
        InitialiseEnemy();
    }

    private void InitialiseEnemy()
    {
        currentEnemy = enemies[Random.Range(0, enemies.Length)];
        
        enemyNameText.text = currentEnemy.CharName;
        enemyHealthText.text = "Health: " + currentEnemy.Health;
    }
    
    public void DoRound()
    {
        int playerDamage = player.Attack();
        currentEnemy.GetHit(playerDamage);
        int enemyDamage = currentEnemy.Attack();
        player.GetHit(enemyDamage);
        
        UpdateText();
    }

    private void UpdateText()
    {
        playerHealthText.text = "Health: " + player.Health;
        enemyHealthText.text = "Health: " + currentEnemy.Health;
    }
}
