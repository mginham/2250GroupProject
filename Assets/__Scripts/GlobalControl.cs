using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public float XP;
    public float health;
    public static GlobalControl instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayer()
    {
        GlobalControl.instance.health = health;
        GlobalControl.instance.XP = XP;

    }
    // Start is called before the first frame update
    void Start()
    {
        health = GlobalControl.instance.health;
        XP = GlobalControl.instance.XP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
