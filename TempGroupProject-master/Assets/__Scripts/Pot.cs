using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Smash()
    {
        // Activate Smash animation
        _anim.SetBool("smash", true);
        StartCoroutine(BreakCo());
    }

    IEnumerator BreakCo()
    {
        // After Pot has been smashed, deactivate the Pot so that it disappears
        yield return new WaitForSeconds(.3f); // Wait 0.3 seconds (length of break animation)
        this.gameObject.SetActive(false);
    }
}
