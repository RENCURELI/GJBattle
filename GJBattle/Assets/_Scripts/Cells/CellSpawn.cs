using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GOAL : Spawn new cells ddepending on set rules
//ENTRY : Get information relative to object spawn
//EXIT : Spawn new Cell


public class CellSpawn : MonoBehaviour
{
    public Transform prefab;
    public bool spawned = false;
    private void FixedUpdate()
    {
        if(this.gameObject.GetComponent<CellClass>().spawn == true && spawned != true)
        {
            Debug.Log("I am Clamped");
            Instantiate(prefab, new Vector3(this.transform.position.x, this.transform.position.y + 50, -12), Quaternion.identity);
            spawned = true;
        }
    }


}
