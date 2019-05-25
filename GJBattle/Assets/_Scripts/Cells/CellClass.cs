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
        if(selected != false)
        {
            CellSelected();
        }
    }

    private void CellSelected()
    {
        Debug.Log(selected);
    }
}
