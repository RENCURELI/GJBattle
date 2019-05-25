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
        CameraZoom();
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

    void CameraZoom()
    {
        ///<summary>
        ///ScrollWheel change input
        ///</summary>
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollWheelChange != 0)
        {                                            //If the scrollwheel has changed
            float R = ScrollWheelChange * 15;                                   //The radius from current camera
            float PosX = Camera.main.transform.eulerAngles.x + 90;              //Get up and down
            float PosY = -1 * (Camera.main.transform.eulerAngles.y - 90);       //Get left to right
            PosX = PosX / 180 * Mathf.PI;                                       //Convert from degrees to radians
            PosY = PosY / 180 * Mathf.PI;                                       //^
            float X = R * Mathf.Sin(PosX) * Mathf.Cos(PosY);                    //Calculate new coords
            float Z = R * Mathf.Sin(PosX) * Mathf.Sin(PosY);                    //^
            float Y = R * Mathf.Cos(PosX);                                      //^
            float CamX = Camera.main.transform.position.x;                      //Get current camera postition for the offset
            float CamY = Camera.main.transform.position.y;                      //^
            float CamZ = Camera.main.transform.position.z;                      //^
            Camera.main.transform.position = new Vector3(CamX + X, CamY + Y, CamZ + Z);//Move the main camera
        }
    }
}
