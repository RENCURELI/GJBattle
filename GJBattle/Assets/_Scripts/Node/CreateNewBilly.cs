using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBilly : MonoBehaviour
{
	
	private int[] chaos1;
	private int[] chaos2;
	private int[] chaos3;
	private int[] chaos4;
	private int[] chaos5;
	private int[] chaos6;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("THE MACHINE");

		chaos1 = new int[3];

		chaos1[3] = Random.Range (0,1);

		chaos2 = new int[3];

		chaos2[3] = Random.Range (1,2);

		chaos3 = new int[3];

		chaos3[3] = Random.Range (1,2);

		chaos4 = new int[3];

		chaos4[3] = Random.Range (0,2);

		chaos5 = new int[3];

		chaos5[3] = Random.Range (0,1);

		chaos6 = new int[3];

		chaos6[3] = Random.Range (0,1);

		

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("5 Billy");


        }
    }
}
