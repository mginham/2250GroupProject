using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSystem : MonoBehaviour
{
    private LevelSystem levelSystem;
    private Material material;
    private Color materialTintColour;


    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChange += LevelSystem_OnLevelChange;
    }
    private void LevelSystem_OnLevelChange(object sender, System.EventArgs e)
    {
        Flash(new Color(1, 1, 1, 1));
    }

    private void Flash(Color flashColour)
    {
        materialTintColour = flashColour;
        material.SetColor("_Tint", materialTintColour);
    }
    private void SpawnParticleEffect()
    {
        //Transform effect = Instantiate(pfEffect, transform);
        //FunctionTimer.Create(() => Destroy(effect.gameObject), 3f);
    }
}
