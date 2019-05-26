using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelect : MonoBehaviour
{
    [SerializeField]
    private LayerMask Clickable;

    public GameObject selectedCell;

    private int selectCount = 0;

    /// <summary>
    /// Coords of mouse ray hit
    /// </summary>
    public static Vector3 castCoord;
    

    private void Update()
    {
        RayCasting();
        Deselection();
    }

    /// <summary>
    /// Raycasting and cell selection
    /// </summary>
    public void RayCasting()
    {
        if (Input.GetMouseButtonDown(0) && selectCount < 1)
        {
            RaycastHit raycast;

            //Cast ray from camera to game world to select Cell
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycast))
            {
                if (raycast.collider.GetComponent<CellClass>().clamped == false)
                {
                    raycast.collider.GetComponent<CellClass>().CellSelected();
                    selectedCell = raycast.collider.gameObject;
                    selectedCell.GetComponent<CellSpawn>().parents[0] = new Vector3(selectedCell.transform.position.x, selectedCell.transform.position.y);
                    ++selectCount;
                }
            }
        }

        //Cast ray from camera to game world to Draw Line Renderer
        if (Input.GetMouseButton(0) && selectCount == 1)
        {
            RaycastHit raycast;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycast))
            {
                castCoord = new Vector3(raycast.point.x, raycast.point.y, 0);
                selectedCell.GetComponent<CellClass>().CellCast();
                if(selectedCell.GetComponent<CellClass>().clamped == true)
                {
                    selectCount = 0;
                    return;
                }
            }   
        }

    }

    /// <summary>
    /// Deselection of cell
    /// </summary>
    private void Deselection()
    {
        if (Input.GetMouseButtonDown(1) && selectCount > 0)
        {
            selectCount = 0;
            selectedCell.GetComponent<CellClass>().Deselected();
        }
    }
}
