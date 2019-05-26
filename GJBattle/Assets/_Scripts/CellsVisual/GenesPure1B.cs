using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenesPure1B : MonoBehaviour
{
	//	l'array qui traque les traits des billy
	public int[] traits;

    //	Pour ce Billy Pure, je lui donne les memes trois traits
    void Awake()
    {
		traits = new int[3];

        traits[0] = 1;
		traits[1] = 1;
		traits[2] = 1;


    }
}
