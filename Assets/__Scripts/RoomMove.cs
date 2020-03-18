using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    private CameraMovement _cam;
    public Vector2 camChange;
    public Vector3 playerChange;
    public bool textNeeded;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // Adjust camera position according to change in location
            _cam.minPosition += camChange;
            _cam.maxPosition += camChange;

            // Adjust player position according to change in location
            other.transform.position += playerChange;

            // Display place name when player enters
            if(textNeeded)
            {
                StartCoroutine(placeNameCoroutine());
            }
        }
    }

    private IEnumerator placeNameCoroutine() //coroutine acts alongside the main routine
    {
        // Display the text
        text.SetActive(true);
        placeText.text = placeName;

        // Wait a few seconds before deactivating the text
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
} // end class
