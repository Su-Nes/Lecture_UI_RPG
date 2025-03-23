using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatLog : MonoBehaviour
{
    private static CombatLog _instance;
    public static CombatLog Instance { get { return _instance; } }

    [SerializeField] private TMP_Text logText;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }

    public void AddLog(string log)
    {
        print(log);
        logText.text += $"{log}\n";
    }

    public void ClearLogs()
    {
        logText.text = "";
    }
}
