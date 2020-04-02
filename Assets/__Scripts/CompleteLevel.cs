using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CompleteLevel : MonoBehaviour
{
    public GameObject player;
    public GameObject cameramain;
    private CameraMovement _cam;
    public Vector2 camChange;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main.GetComponent<CameraMovement>();
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
            _cam.minPosition += camChange;
            _cam.maxPosition += camChange;
            Stats.myInstance.GainXP(XPManager.CalculateXP(this as CompleteLevel));//ZACH ADDED THIS
            Completed = true;
            Debug.Log("LEVEL COMPLETED!");
            player.transform.position=new Vector3(60,11.4f,0);
            cameramain.transform.position = new Vector3(60, 11.4f, -10);


        }
    }
   
}
