﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellClass : MonoBehaviour
{
    [SerializeField]
    private LayerMask clickable;

    public static CellClass current;
    public bool clamped = false;
    public bool spawn = false;
    public bool selected = false;
    private LineRenderer line;

    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    public void CellSelected()
    {
        Debug.Log("I am selected");
        selected = true;
    }


    /// <summary>
    /// Raycast from cell, used to connect two cells
    /// </summary>
    public void CellCast()
    {
        line.enabled = true;

        RaycastHit hit;
        Vector3 fwd = ItemSelect.castCoord;
        if (Physics.Raycast(transform.position, fwd, out hit, 100f))
        {
            Debug.Log("Connect");
            if(hit.collider.tag != "backGround")
            {
                this.gameObject.GetComponent<CellSpawn>().parents[1] = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y);
                Clamp(hit.collider.gameObject);
                
                return;
            }
            
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, fwd);
        
    }

    /// <summary>
    /// Manage deselection
    /// </summary>
    public void Deselected()
    {
        selected = false;
        line.enabled = false;
    }

    /// <summary>
    /// Turn off line renderer temporarily
    /// </summary>
    public void LineOff()
    {
        line.enabled = false;
    }

    public void Clamp(GameObject other)
    {
        if (this.gameObject.GetComponent<CellSpawn>().spawned != true)
        {
            Debug.Log("Clamped");
            Deselected();
            clamped = true;
            spawn = true;
            this.gameObject.GetComponent<CellSpawn>().Spawn();
            other.GetComponent<CellClass>().clamped = true;
            line.enabled = true;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, other.transform.position, 100f))
            {

            }
            line.SetPosition(0, transform.position);
            line.SetPosition(1, other.transform.position);

        }else if(this.gameObject.GetComponent<CellSpawn>().spawned == true)
        {
           spawn = false;
            return;
        }
    }
}
