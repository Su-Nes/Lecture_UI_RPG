using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Character player;
    [SerializeField] private Character[] enemies;
    private Character currentEnemy;
    
    [SerializeField] private TMP_Text playerNameText, playerHealthText, enemyNameText, enemyHealthText;
    
    
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
        playerHealthText.text = "Health: " + player.Health;
        
        InitialiseEnemy();
    }

    public void InitialiseEnemy()
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
    }

    public void GameOver()
    {
        print("~GAME OVER~");
    }
}
