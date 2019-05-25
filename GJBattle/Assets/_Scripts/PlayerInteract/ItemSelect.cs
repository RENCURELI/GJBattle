﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    [SerializeField]
    private LayerMask Clickable;

    private int selectCount = 0;

    /// <summary>
    /// Coords of mouse ray hit
    /// </summary>
    public static Vector3 castCoord;
    

    private void Update()
    {
        RayCasting();
    }

    public void RayCasting()
    {
        if (Input.GetMouseButtonDown(0) && selectCount < 1)
        {
            RaycastHit raycast;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycast))
            {
                raycast.collider.GetComponent<CellClass>().CellSelected();
                ++selectCount;
            }
        }

        if (Input.GetMouseButton(0) && selectCount >= 1)
        {
            RaycastHit raycast;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycast))
            {
                castCoord = new Vector3(raycast.point.x, raycast.point.y);
                CellClass.CellCast();
            }
        }
    }
}
