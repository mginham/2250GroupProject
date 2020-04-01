using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPBottlePickUp : MonoBehaviour
{
    [SerializeField]
    private GameObject XPBottle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            XPBottle.SetActive(false);
            Debug.Log("touching");
            Stats.myInstance.GainXP(5);
            Destroy(XPBottle);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
