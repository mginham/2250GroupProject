using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SCCTYPE {XP}

public class ExperienceTextManager : MonoBehaviour
{
    private static ExperienceTextManager instance;

    public static ExperienceTextManager myInstance
    {
        get
        {
            if (instance = null)
            {
                instance = FindObjectOfType<ExperienceTextManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject XPtextPrefab;

    public void CreateText(Vector2 position, string text,SCCTYPE type)
    {
        Text sct=Instantiate(XPtextPrefab,transform).GetComponent<Text>();
        sct.transform.position = position;
        string before = string.Empty;
        string after = string.Empty;

        switch (type)
        {
            case SCCTYPE.XP:
                before = "+";
                after = "EXP";
                sct.color = Color.magenta;
                break;

        }

        sct.text = before + text + after;
        
    }
}
