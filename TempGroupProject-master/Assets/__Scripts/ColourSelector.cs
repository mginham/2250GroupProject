using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown colourDrop;
    public SpriteRenderer m_SpriteRenderer;
    static Color newColour = Color.white;
    public GameObject Player;

    public void Dropdown_Index(int index)
    {
        if (index == 0)
        {
            newColour = Color.white;
            Player.GetComponent<SpriteRenderer>().material.color = newColour;
        }
        if (index == 1)
        {
            newColour = Color.yellow;
            Player.GetComponent<SpriteRenderer>().material.color = newColour;
        }
        if (index == 2)
        {
            newColour = Color.red;
            Player.GetComponent<SpriteRenderer>().material.color = newColour;
        }
        if(index==3)
        {
            newColour = Color.blue;
            Player.GetComponent<SpriteRenderer>().material.color = newColour;

        }
    }

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = newColour;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
