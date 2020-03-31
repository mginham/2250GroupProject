using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;
    private LevelSystem levelSystem;
    public GameObject Level1Enemies;
    //public GameObject Level2Enemies;
    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        experienceBarImage = transform.Find("ExperienceBar").Find("Bar").GetComponent<Image>();


        //transform.Find("Log").GetComponent<GameObject>().EnemyDefeated=() =>levelSystem.AddExperience(5);
        //SetLevelNumber(1);
        //SetExperienceSize(0f);



    }
    private void Update()
    {
        if (Level1Enemies.activeSelf == false)
        {
            EnemyDefeated1();
        }

        //Save this for when Enemy 2 is created
        /*if (Level2Enemies.activeSelf == false)
        {
            EnemyDefeated2();
        }*/
    }
    private void EnemyDefeated2()
    {
        levelSystem.AddExperience(5);
    }
    private void EnemyDefeated1()
    {
        levelSystem.AddExperience(2);
        
    }
    private void SetExperienceSize(float experienceNormal)
    {
        experienceBarImage.fillAmount = experienceNormal;
    }
    private void SetLevelNumber(int levelNum)
    {
        levelText.text = ""+levelNum;
    }
    public void SetLevelSystem(LevelSystem levelSystem)//Set LevelSystem Object
    {
        this.levelSystem = levelSystem;

        //Update the starting values
        SetLevelNumber(levelSystem.GetLevelNum());
        SetExperienceSize(levelSystem.GetExperienceNormal());

        //Subscribe to the changed events
        levelSystem.OnExperienceChange += LevelSystem_OnExperienceChange;
        levelSystem.OnLevelChange += LevelSystem_OnLevelChange;
    }

    private void LevelSystem_OnExperienceChange(object sender,System.EventArgs e)//Experience change, update bar
    {
        SetExperienceSize(levelSystem.GetExperienceNormal());
    }
    private void LevelSystem_OnLevelChange(object sender, System.EventArgs e)//Level Change, change text
    {
        SetLevelNumber(levelSystem.GetLevelNum());
    }

}
