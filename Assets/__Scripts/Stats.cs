using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Stats : MonoBehaviour
{
    [SerializeField]
    public AudioSource scream;//TODO change later


    [SerializeField]
    public AudioSource HAH;


    [SerializeField]
    private GameObject HealthPickup;

    [SerializeField]
    private Animator LvlUP;

    [SerializeField]
    private Animator LvlUP2;

    private Image content;

    public static float Cool;



    Vector3 pos;

    private static Stats instance;

    public static Stats myInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Stats>();
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject player;

    [SerializeField]
    public GameObject LvlUpPrefab;

    private float OverFlow;

    [SerializeField]
    private Text levelText;

    [SerializeField]
    private int level;

    [SerializeField]
    private float lerpSpeed;
    

    [SerializeField]
    private Text statValue;

    [SerializeField]
    private Stats XP;

    private float currentFill;

    public float MyMaxValue { get; set; }

    private float currentValue;

    private bool isFull
    {
        get { return content.fillAmount == 1; }
    }


    public float MyOverFlow
    {
        get
        {
            float tmp = OverFlow;
            OverFlow = 0;
            return tmp;
        }
    }


    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > MyMaxValue)
            {
                OverFlow = value - MyMaxValue;
                currentValue = MyMaxValue;
            }else if (value < 0)
            {
                currentValue = 0;
            }
            else{
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
            statValue.text = currentValue + "/" + MyMaxValue;
        }
    }

    public int MyLevel { get => level; set => level = value; }

    void Start()
    {
        XP.Initialize(0, 10*MyLevel);
        content = GetComponent<Image>();
        levelText.text = MyLevel.ToString();
    }
    void Update()
    {
        if (currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.MoveTowards(content.fillAmount, currentFill,Time.deltaTime*lerpSpeed);
        }
        content.fillAmount = currentFill; 
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            GainXP(3);
            //scream.Play();
        }
        //Vector3 pos = player.transform.position;

    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }

    public void GainXP(int xpStat)
    {

        XP.MyCurrentValue += xpStat;
        //TODO add in display thingy guy has in video
        if (XP.MyCurrentValue >= XP.MyMaxValue)
        {
            StartCoroutine(Ding());
            if (Cool < 11)
            {
                Cool = 5 + ((MyLevel - 1) * 2);
                Cooldown(Cool);
            }
            else
            {
                Cooldown(Cool);
            }
            
        }
        
        //ExperienceTextManager.myInstance.CreateText(player.transform.position, xpStat.ToString(), SCCTYPE.XP);//THIS MAY BE SCREWING STUFF UP EITHER FIX IT OR GET RID OF IT

    }
    private IEnumerator Ding()
    {
        while (!XP.isFull)
        {
            yield return null;
        }
        MyLevel++;
        LvlUP.SetTrigger("LevelUp");
        LvlUP2.SetTrigger("LevelUp2");
        //HealthPickup.SetActive(false);
        HeartManager.myInstance.HealPlayer();
        /*Instantiate(HealthPickup);
        HealthPickup.transform.position = pos;
        HealthPickup.SetActive(true);*/



        levelText.text = MyLevel.ToString();
        XP.MyMaxValue = 10 * MyLevel;
        XP.MyCurrentValue = XP.MyOverFlow;
        XP.Reset();

        if (XP.MyCurrentValue >= XP.MyMaxValue)
        {
            StartCoroutine(Ding());
        }
    }


    public void Reset()
    {
        content.fillAmount = 0;
    }

    public static float Cooldown(float cooldown)
    {
        cooldown = Cool;
        return cooldown;
    }

}
