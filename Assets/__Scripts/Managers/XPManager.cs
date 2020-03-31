using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


static class XPManager
{
    public static int CalculateXP(Enemy e)
    {
        int Enemy1XP = 4;
        int Enemy2XP = 8;
        int totalXP = 0;
        //TODO figure out a way to sense the enemy without using tags as if I create a new tag it will disrupt other scripts DONE
        //TODO also figure out way to add XP for level clearing (maybe the player just reaches a point or something) DONE
        //TODO also make sure I tell group about what I changed
        //TODO maybe make main menu if I have time (just like two buttons saying quit or start new game)
        //TODO maybe make customization menu a little nicer looking SORTA DONE
        if (e.enemyName==("Larry the Log"))
        {
            totalXP += Enemy1XP;
            return totalXP;
        }
        else if(e.enemyName==("enemy2Name"))//this is just a placeholder for when enemy2 is actually creaated
        {
            totalXP += Enemy2XP;
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
