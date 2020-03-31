using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Exp exp;
    private Image barImage;
    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        barImage.fillAmount = 0f;//comment out if having trouble with bar

        //exp = new Exp();
        
    }
    /*private void Update()
    {
        exp.Update();
        barImage.fillAmount = exp.GetExpNormal();
    }*/

}