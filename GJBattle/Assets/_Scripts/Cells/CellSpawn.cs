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

    /// <summary>
    /// Parents coord
    /// </summary>
    public Vector3[] parents;

    private Vector3 spawnCoord;

    private void Start()
    {
        parents = new Vector3[2];
    }

    public void Spawn()
    {
        if(this.gameObject.GetComponent<CellClass>().spawn == true && spawned == false)
        {
            Debug.Log("I am Clamped");
            spawnCoord = (parents[0] + parents[1]) * 0.5f;
            Instantiate(prefab, new Vector3(spawnCoord.x, spawnCoord.y + 50, -12), Quaternion.identity);
            spawned = true;
        }
    }


}
