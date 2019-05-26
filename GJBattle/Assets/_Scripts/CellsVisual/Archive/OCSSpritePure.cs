using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OCSSpritePure : MonoBehaviour
{
    //	La selection de sprite utilise pour le visuel des Billy
	public Sprite traitR;
	public Sprite traitB;
	public Sprite traitG;

	//	Lequelle des trois traits herite ce genome
	public int spritePosition;

	public SpriteRenderer sprite;

	void Awake()
	{
		sprite = gameObject.GetComponent<SpriteRenderer>();
	}

	void Start()
    {
        if (this.gameObject.tag == "Orbit") 
		{
			spritePosition = gameObject.GetComponentInParent<GenesPure>().traits[0];
		}
		else if (this.gameObject.tag == "Core") 
		{
			spritePosition = gameObject.GetComponentInParent<GenesPure>().traits[1];
		}
		else if (this.gameObject.tag == "Satellite") 
		{
			spritePosition = gameObject.GetComponentInParent<GenesPure>().traits[2];
		}

		

		if (spritePosition == 0)
		{
			sprite.sprite = traitR;
		}
		else if (spritePosition == 1)
		{
			sprite.sprite = traitB;
		}
		else if (spritePosition == 2)
		{
			sprite.sprite = traitG;
		}
		
		//gameObject.GetComponentInParent();

    }

    

}
