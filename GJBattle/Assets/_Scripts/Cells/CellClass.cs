using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellClass : MonoBehaviour
{
    public static CellClass current;
    public bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        //Debug.Log("Casting" + ItemSelect.castCoord);

        RaycastHit hit;
        Vector3 fwd = ItemSelect.castCoord;

        if (Physics.Raycast(transform.position, fwd, 100f))
        {
            Debug.Log("Casting");
            Debug.DrawRay(transform.position, ItemSelect.castCoord, Color.red);
        }
    }
}
