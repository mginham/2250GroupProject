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
    private float Cooldown;
    private float distance;
    private float MaxOut = 11;
    private float tmp;
    public GameObject[] classItems2;
    public GameObject frame;
    private bool wait = true;

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

    void Update()//This is where all the powerups are, simply press B with the respective class
    {
        
        if (classnum == 0)//if the user selected the Crusador class and presses B then it makes the player grow and then shrink back to normal size
        {
            frame.SetActive(true);
            classItems2[0].SetActive(true);
            if (classnum==0&&Input.GetKeyDown(KeyCode.B)&&(wait==true))
            {
                Cooldown = Stats.Cooldown(Cooldown);
                if (Cooldown > 0)
                {
                    wait = false;
                    player1.transform.localScale += new Vector3(1, 1, 1);
                    Debug.Log(Cooldown+2);
                    print("Super Strength Activated!");
                    Invoke("Shrink", Cooldown+2);
                }
                else
                {
                    wait = false;
                    player1.transform.localScale += new Vector3(1, 1, 1);
                    Debug.Log(Cooldown+5);
                    print("Super Strength Activated!");
                    Invoke("Shrink", 5f);
                }
                
               
            }
            
        }
        if (classnum == 1)//if the user selected the Mage class and presses B then it makes the user invisible for a few seconds
        {
            frame.SetActive(true);
            classItems2[1].SetActive(true);

            if ((classnum == 1) && (Input.GetKeyDown(KeyCode.B))&&(wait==true))//if the user selected the Mage class and presses B then it makes the user invisible for a few seconds
            {
                Cooldown = Stats.Cooldown(Cooldown);
                if (Cooldown > 0)
                {
                    wait = false;
                    player1.transform.Rotate(0f, 90f, 0f);
                    Debug.Log(Cooldown + 2);
                    print("Invisibility Cloak Activated!");
                    Invoke("UnCloak", Cooldown+2);
                    
                }
                else
                {
                    wait = false;
                    player1.transform.Rotate(0f, 90f, 0f);
                    Debug.Log(Cooldown + 5);
                    print("Invisibility Cloak Activated!");
                    Invoke("UnCloak", 5f);
                }
            }
        }
        if (classnum == 2)//if the user selected the Archer class and presses B then the user swiftly side steps enemies
        {
            frame.SetActive(true);
            classItems2[2].SetActive(true);

            if ((classnum == 2) && (Input.GetKeyDown(KeyCode.B)) && (wait == true))//if the user selected the Archer class and presses B then the user swiftly side steps enemies
            {
                Cooldown = Stats.Cooldown(Cooldown);
                if (Cooldown == 5)
                {
                    wait = false;
                    tmp = 3;
                    distance = tmp+ (Cooldown - (Cooldown - 1));
                    player1.transform.Translate(distance, 0, 0);
                    Debug.Log(distance);
                    print("Side Stepped!");
                    Invoke("SideStep", 0.2f);
                }
                if (Cooldown == 7)
                {
                    wait = false;
                    tmp = 4;
                    distance = tmp + (Cooldown - (Cooldown - 1));
                    player1.transform.Translate(distance, 0, 0);
                    Debug.Log(distance);
                    print("Side Stepped!");
                    Invoke("SideStep", 0.2f);
                }
                if (Cooldown == 9)
                {
                    wait = false;
                    tmp = 5;
                    distance = tmp + (Cooldown - (Cooldown - 1));
                    player1.transform.Translate(distance, 0, 0);
                    Debug.Log(distance);
                    print("Side Stepped!");
                    Invoke("SideStep", 0.2f);
                }
                if (Cooldown == 11)
                {
                    wait = false;
                    tmp = 6;
                    distance = tmp + (Cooldown - (Cooldown - 1));
                    player1.transform.Translate(distance, 0, 0);
                    Debug.Log(distance);
                    print("Side Stepped!");
                    Invoke("SideStep", 0.2f);
                }
                else if(Cooldown==0)
                {
                    wait = false;
                    distance = 3;
                    player1.transform.Translate(distance, 0, 0);
                    Debug.Log(distance);
                    print("Side Stepped!");
                    Invoke("SideStep", 0.2f);
                }
                else if(Cooldown>11)
                {
                    wait = false;
                    player1.transform.Translate(distance, 0, 0);
                    Debug.Log(distance);
                    print("Side Stepped!");
                    Invoke("SideStep", 0.2f);
                }
            }
            
        }
    }
    void UnCloak()//uncloaks the invisible player
    {
        player1.transform.Rotate(0f, 270f, 0f);
        print("Invisibility Cloak has worn off!");
        wait = true;
    }
    void Shrink()//shrinks the grown player
    {
        player1.transform.localScale -= new Vector3(1, 1, 1);
        print("Super Strength Deactivated!");
        wait = true;

    }
    void SideStep()//preforms the sidestep in the opposite direction
    {
        player1.transform.Translate(-distance, 0, 0);
        wait = true;
    }

}

