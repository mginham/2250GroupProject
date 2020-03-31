using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : MonoBehaviour
{
    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private PlayerLevelSystem player;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        levelWindow.SetLevelSystem(levelSystem);
        
        player.SetLevelSystem(levelSystem);
        
        
    }
}
