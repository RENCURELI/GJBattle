using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewBilly : MonoBehaviour
{
	
	public int[] chaos1;
	//public int[] chaos2;
	//public int[] chaos3;
	//public int[] chaos4;
	//public int[] chaos5;
	//public int[] chaos6;

	public GameObject billy;
	public GameObject goa;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("THE MACHINE");

		//chaos1 = new int[3];

		//chaos1[3] = Random.Range (0,1);

		// chaos2 = new int[3];

		//chaos2[3] = Random.Range (1,2);

		//chaos3 = new int[3];

		//chaos3[3] = Random.Range (1,2);

		//chaos4 = new int[3];
	
		//chaos4[3] = Random.Range (0,2);

		//chaos5 = new int[3];

		//chaos5[3] = Random.Range (0,1);

		//chaos6 = new int[3];

		//chaos6[3] = Random.Range (0,1);
		}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("1 Billy");

			chaos1 = new int[3];

			AkSoundEngine.Postevent("Spawn", gameobject);

			chaos1[0] = Random.Range (0,3);
			chaos1[1] = Random.Range (0,3);
			chaos1[2] = Random.Range (0,3);

			goa = (GameObject)Instantiate(billy, transform);

			goa.AddComponent<Genes>();
            goa.GetComponent<Genes>().traits[0] = chaos1[0];
            goa.GetComponent<Genes>().traits[1] = chaos1[1];
            goa.GetComponent<Genes>().traits[2] = chaos1[2];


			
			
        }

    }
}
