using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp:MonoBehaviour
{
    public const int MaxExp = 10;
    public float ExpAmount;
    public float ExpGainAmount;
    public GameObject EnemyPrefab;
    public Exp()
    {
        ExpAmount = 0;
        ExpGainAmount += ExpGainAmount;
    }
    public void Update()
    {
        if (!EnemyPrefab.activeSelf)
        {
            ExpAmount += ExpGainAmount;
        }
    }
    public float GetExpNormal()
    {
        return ExpAmount / MaxExp;
    }
}
