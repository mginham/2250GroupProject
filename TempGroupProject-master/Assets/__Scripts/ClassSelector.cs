using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown classDrop;
    public GameObject[] classItems;
    static int classnum;
    public GameObject player1;

    public void Dropdown_Index(int index)
    {
        if (index == 0)
        {
            classItems[1].SetActive(false);
            classItems[2].SetActive(false);
            classItems[index].SetActive(true);
            classnum = 0;

        }
        if (index == 1)
        {
            classItems[0].SetActive(false);
            classItems[2].SetActive(false);
            classItems[index].SetActive(true);
            classnum = 1;
        }
        if (index == 2)
        {
            classItems[0].SetActive(false);
            classItems[1].SetActive(false);
            classItems[index].SetActive(true);
            classnum = 2;
        }

    }

    void Start()
    {
        classItems[0].SetActive(true);

        
    }


    // Update is called once per frame
   
    void Update()//This is where all the powerups are, simply press V with the respective class
    {
        if ((classnum == 0) && (Input.GetKeyDown(KeyCode.V)))//if the user selected the Crusador class and presses V then it makes the player grow and then shrink back to normal size
        {
            player1.transform.localScale+=new Vector3(1, 1, 1);
            print("Super Strength Activated!");
            Invoke("Shrink", 5f);
        }
        if ((classnum == 1) && (Input.GetKeyDown(KeyCode.V)))//if the user selected the Mage class and presses V then it makes the user invisible for a few seconds
        {

            player1.transform.Rotate(0f, 90f, 0f);
            print("Invisibility Cloak Activated!");
            Invoke("UnCloak", 5f);
        }
        if ((classnum == 2) && (Input.GetKeyDown(KeyCode.V)))//if the user selected the Archer class and presses V then the user swiftly side steps enemies
        {
            player1.transform.Translate(3,0,0);
            print("Side Stepped!");
            Invoke("SideStep", 0.2f);
        }
    }
    void UnCloak()//uncloaks the invisible player
    {
        player1.transform.Rotate(0f, 270f, 0f);
        print("Invisibility Cloak has worn off!");
    }
    void Shrink()//shrinks the grown player
    {
        player1.transform.localScale -= new Vector3(1, 1, 1);
        print("Super Strength Deactivated!");
    }
    void SideStep()//preforms the sidestep in the opposite direction
    {
        player1.transform.Translate(-3, 0, 0);
    }
}

