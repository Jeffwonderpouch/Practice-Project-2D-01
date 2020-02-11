using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTouch01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Constant for loop checking to see if there are any touch inputs
        //for (int i = 0; i < Input.touchCount; i++)
        //{
        //    // Gathering the touch position and making it a usable coordinate
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
        //    //Draws a line from the player to the touch points
        //    Debug.DrawLine(transform.position, touchPosition, Color.red);
        //}
        if (Input.touchCount > 0)
        {
            // Making a touch variable to store the first touch's input
            Touch touch = Input.GetTouch(0);
            // Creating a new vector3 to store our touch position and converting its coordinates on the screen to in game world coordinates
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0; // This makes sure that our player doesnt move "closer" to the screen, and it just moves to the 'x' and 'y' coodinates
            // Our position gets set to the touch input position
            transform.position = touchPosition;
        }

    }
}
