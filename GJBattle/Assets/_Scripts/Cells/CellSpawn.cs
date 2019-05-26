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

    public GameObject crossBilly;

    /// <summary>
    /// Parents coord
    /// </summary>
    public Vector3[] parents;

    public GameObject[] billyParents;

    private Vector3 spawnCoord;

    private void Awake()
    {
        parents = new Vector3[2];
        billyParents = new GameObject[2];
    }

    public void Spawn()
    {
        if(this.gameObject.GetComponent<CellClass>().spawn == true && spawned == false)
        {
            Debug.Log("I am Clamped");
            spawnCoord = (parents[0] + parents[1]) * 0.5f;
            //this.gameObject.GetComponent<CrossBilly>().CrossBreed();
            Instantiate(prefab, new Vector3(spawnCoord.x, spawnCoord.y + 20, -12), Quaternion.identity);
            multiSpawn(spawnCoord);
            
            Debug.Log(billyParents[0]);
            prefab.GetComponent<CrossBilly>().secondBilly = billyParents[1];
            prefab.GetComponent<CrossBilly>().firstBilly = Camera.main.GetComponent<ItemSelect>().selectedCell;
            //this.gameObject.GetComponent<CrossBilly>().CrossBreed();
            spawned = true;
        }
    }

    public void multiSpawn(Vector3 basePoint)
    {
        Vector3 origin = basePoint;
        int dist = 10; //X distance from origin cell
        int i, j; //Iterators
        int cellDist = 0; //Used to determine number of cells between 0 and current
        int mod = 0; //Used as intermediate variable for spawn distance determination
        int nbSpawn = 3; //Number of cells to spawn

        nbSpawn = Random.Range(2, 5);

        for(i = 1; i <= nbSpawn; i++)
        {
            cellDist = 0;
            
            for(j = i; j >= 0; j--)
            {
                //Debug.Log("J value : " + j);
                ++cellDist;
                //Debug.Log("cellDist value : " + cellDist);
                mod = cellDist % 2;
                //Debug.Log("modulo value : " + mod);
                
            }
            if (mod == 0)
            {
                Instantiate(prefab, new Vector3(origin.x + dist, origin.y + Random.Range(15f, 25f), -12), Quaternion.identity);
                //Debug.Log(origin);
                //Debug.Log("before dist mod : " + dist);
                dist = dist * 2;
                //Debug.Log("after dist mod : " + dist);
            }
            else
            {
                dist = dist / 2; //Come back to initial value
                Instantiate(prefab, new Vector3(origin.x - dist, origin.y + Random.Range(15f, 25f), -12), Quaternion.identity);
                dist = dist * 2; //Go back to modified value
                //Debug.Log("ERROR");
            }
            //Debug.Log("I value : " + i);
        }
    }

}
