using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool Completed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag=="Player")&&(Completed==false)) 
        {
            Stats.myInstance.GainXP(XPManager.CalculateXP(this as CompleteLevel));//ZACH ADDED THIS
            Completed = true;
            Debug.Log("LEVEL COMPLETED!");
        }
    }
}
