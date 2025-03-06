using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Character character;
    
    private void Start()
    {   
        player.Attack();
        enemy.Attack();
        character.Attack();

        print(player.CharName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
