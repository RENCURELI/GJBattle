using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GOAL : Manage all camera movement options
//ENTRY : Get user input
//EXIT : Move camera accordingly


public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// Camera movement speed
    /// </summary>
    private const float DRAGESPEED = 1;

    /// <summary>
    /// Origin used to determine drag direction
    /// </summary>
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    // Camera coord limits
    public float outerLeft = -10f;
    public float outerRight = 10f;
    public float lowLimit = -10f;
    public float upLimit = 10f;


    // Update is called once per frame
    void LateUpdate()
    {
        MouseMove();
        
    }

    /// <summary>
    /// Mouse drag movement
    /// </summary>
    void MouseMove()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.2f;
        float right = Screen.width - (Screen.width * 0.2f);
        float up = Screen.height * 0.2f;
        float down = Screen.height - (Screen.height * 0.2f);

        //Drag state verification
        if (mousePosition.x < left)
            cameraDragging = true;
        else if (mousePosition.x > right)
            cameraDragging = true;

        if (mousePosition.y > up)
            cameraDragging = true;
        else if (mousePosition.y < down)
            cameraDragging = true;

        if (cameraDragging)
        {
            //Set drag origin point
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * DRAGESPEED, pos.y * DRAGESPEED, 0);

            if (move.x > 0f)
            {
                if (this.transform.position.x < outerRight)
                {
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.x > outerLeft)
                {
                    transform.Translate(move, Space.World);
                }
            }
            if (move.y > 0f)
            {
                if (this.transform.position.y > lowLimit)
                {
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.y < upLimit)
                {
                    transform.Translate(move, Space.World);
                }
            }
        }
    }
}
