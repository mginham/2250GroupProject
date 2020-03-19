using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame (late -> comes last)
    void LateUpdate()
    {
        // If the transform isn't aimed at the target, move towards the target
        if(transform.position != target.position)
        {
            Vector3 tPosition = new Vector3(target.position.x, target.position.y, transform.position.z); // follow the target in x and y axis, but maintain own z axis

            // Make bounds such that the camera doesn't not go beyond the intended world
            tPosition.x = Mathf.Clamp(tPosition.x, minPosition.x, maxPosition.x);
            tPosition.y = Mathf.Clamp(tPosition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, tPosition, smoothing);

        }
    }
} // end class
