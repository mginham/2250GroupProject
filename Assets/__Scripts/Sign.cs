using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogue;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        // Don't need to do anything here
    }

    // Update is called once per frame
    void Update()
    {
        // Open dialogue when the Player is standing in front of the sign and presses space
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange) // TODO: Not best because it only works for space (consider changing in the future for all interact keys
        {
            // If the dialogue is already open, close it
            if (dialogueBox.activeInHierarchy)
            {
                dialogueBox.SetActive(false);
            }
            else // If the dialogue is closed, open it
            {
                dialogueBox.SetActive(true);
                dialogueText.text = dialogue;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the object is the player and is in range of the sign
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the object is the player and is not in range of the sign
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueBox.SetActive(false); // Close dialogue if the player is not in range
        }
    }
}
