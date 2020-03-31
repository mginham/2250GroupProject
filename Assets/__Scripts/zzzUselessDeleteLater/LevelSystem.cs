using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public event EventHandler OnExperienceChange;
    public event EventHandler OnLevelChange;

    private int level;
    private int experience;
    private int NextLevelExperience;
    public LevelSystem()
    {
        level = 1;
        experience = 0;
        NextLevelExperience = 10;
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= NextLevelExperience)//if the player has gained enough experience to level up
        {
            level++;
            experience -= NextLevelExperience;
            NextLevelExperience += 10;

            if (OnLevelChange != null) OnLevelChange(this, EventArgs.Empty);

        }
        if (OnExperienceChange != null) OnExperienceChange(this, EventArgs.Empty);
        
    }
    public int GetLevelNum()
    {
        return level;
    }
    public float GetExperienceNormal()
    {
        return (float)experience / NextLevelExperience;
    }
}
