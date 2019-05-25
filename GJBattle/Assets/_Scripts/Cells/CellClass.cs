using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellClass : MonoBehaviour
{
    public static CellClass current;
    public bool selected = false;
    private LineRenderer line;

    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Debug.Log("Casting");
            //Debug.DrawRay(transform.position, ItemSelect.castCoord, Color.red);
            
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, fwd);
        
    }

    public void Deselected()
    {
        selected = false;
        line.enabled = false;
    }

    public void LineOff()
    {
        //selected = false;
        //line.positionCount = 0;
        line.enabled = false;
    }
}
