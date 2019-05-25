using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genes : MonoBehaviour
{
	//	l'array qui traque les traits des billy
	public int[] traits;

    //	Je vais donner des traits arbitraire pour les tests
    void Start()
    {
		traits = new int[3];

        traits[0] = 1;
		traits[1] = 2;
		traits[2] = 1;

		Debug.Log(traits.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
