using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCSSprite : MonoBehaviour
{
    //	La selection de sprite utilise pour le visuel des Billy
	public Sprite traitR;
	public Sprite traitB;
	public Sprite traitG;

	//	Lequelle des trois traits herite ce genome
	public int spritePosition;

	void Start()
    {
        if (this.gameObject.Tag == "Orbit") 
		{
			spritePosition = gameObject.GetComponentInParent(Genes).traits[0];

		}
		
		//gameObject.GetComponentInParent();

    }

    

}
