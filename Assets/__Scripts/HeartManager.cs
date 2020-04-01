using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    private static HeartManager instance;
    public static HeartManager myInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HeartManager>();
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for(int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.runtimeValue / 2; // Half heart = 1 health point

        for(int i = 0; i < heartContainers.runtimeValue; i++)
        {
            // Compare playerCurrentHealth to values in heartContainers
            if(i <= tempHealth-1)
            {
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
            {
                hearts[i].sprite = emptyHeart;
            }
            else
            {
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
    public void HealPlayer()
    {
        for (int i = 0; i < heartContainers.runtimeValue; i++)
        {
            hearts[i].sprite=fullHeart;

        }
        playerCurrentHealth.runtimeValue = 6f;
        Debug.Log("Healed");
    }
}
