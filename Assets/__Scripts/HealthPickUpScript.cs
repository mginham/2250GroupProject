using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpScript : MonoBehaviour
{
    [SerializeField]
    private GameObject healthpickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            healthpickup.SetActive(false);
            Debug.Log("touching");
            HeartManager.myInstance.HealPlayer();
            Destroy(healthpickup);
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
