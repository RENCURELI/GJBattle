using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenesPure2G : MonoBehaviour
{
	//	l'array qui traque les traits des billy
	public int[] traits;

    //	Pour ce Billy Pure, je lui donne les memes trois traits
    void Awake()
    {
		traits = new int[3];

        traits[0] = 2;
		traits[1] = 2;
		traits[2] = 2;


    }
}
