using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] protected int experienceReward = 10;

    protected override void Die()
    {
        FindObjectOfType<Player>().IncreaseExperience(experienceReward);

        CombatLog.Instance.AddLog($"{charName} has been slain!");
        GameManager.Instance.InitialiseEnemy();
    }
}
