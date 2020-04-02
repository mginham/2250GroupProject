using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;

static class XPManager
{
    public static int CalculateXP(Enemy e)
    {
        int Enemy1XP = 4;
        int Enemy2XP = 6;
        int BossXP = 40;
        int totalXP = 0;


        //Based on what the Enemy name is, is how much XP the player gets
        if (e.enemyName==("Larry the Log"))
        {
            totalXP += Enemy1XP;
            return totalXP;
        }
        else if(e.enemyName==("Dracula"))
        {
            totalXP += Enemy2XP;
        }
        else if (e.enemyName == ("Wizard"))
        {
            totalXP += BossXP;
            SceneManager.LoadScene("WinScreen");

        }
        return totalXP;


    }

    public static int CalculateXP(CompleteLevel e)
    {
        int totalXp = 0;
        totalXp += 40;
        return totalXp;
    }
}
