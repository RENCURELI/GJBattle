using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBilly : MonoBehaviour
{
    
	//	Les gameobject que le script va utiliser pour comparer les genes de goa
	public GameObject firstBilly;
	public GameObject secondBilly;

	public GameObject firstBillyT1;
	public GameObject secondBillyT1;
	public GameObject firstBillyT2;
	public GameObject secondBillyT2;
	public GameObject firstBillyT3;
	public GameObject secondBillyT3;
    
	//	Ce GO est le prefab de Billy; le script va placer le script de gene dessus et remplacer les valeurs des traits.
	public GameObject billy;

	//	Le GO qui designe la nouvelle instance de Billy pendant qu'il recoit ses traits
	public GameObject goa;

	//	La lotterie qui determine quel parent va donner quelle trait
	public int[] lottery;

    void Start()
    {
        //Debug.Log("Hola hola");

		
    }

	void Update()
	{

		//	Le bouton pour activer la methode pour le croissement
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			//Debug.Log("Shag party");
			CrossBreed();
		}
	}

    // La fonction pour mixer les billy
    void CrossBreed()
    {
        //	La fonction genere une lotterie pour choisir les traits
		lottery = new int[3];

			lottery[0] = Random.Range (0,101);
			lottery[1] = Random.Range (0,101);
			lottery[2] = Random.Range (0,101);

		//	Un billy vierge est cree
		goa = (GameObject)Instantiate(billy, transform);
			//	Le profil de gene du nouveau billy
			goa.AddComponent<Genes>();


		// La methode verifie, trait par trait, quelle parent a leguer ces 
		if (lottery[0] <= 50)
		{
			goa.GetComponent<Genes>().traits[0] = firstBilly.GetComponent<Genes>().traits[0];
		}
		else if (lottery[0] >= 51)
		{
			goa.GetComponent<Genes>().traits[0] = secondBilly.GetComponent<Genes>().traits[0];
		}
		
		
		if (lottery[1] <= 50)
		{
			goa.GetComponent<Genes>().traits[1] = firstBilly.GetComponent<Genes>().traits[1];
		}
		else if (lottery[1] >= 51)
		{
			goa.GetComponent<Genes>().traits[1] = secondBilly.GetComponent<Genes>().traits[1];
		}

		
		if (lottery[2] <= 50)
		{
			goa.GetComponent<Genes>().traits[2] = firstBilly.GetComponent<Genes>().traits[2];
		}
		else if (lottery[2] >= 51)
		{
			goa.GetComponent<Genes>().traits[2] = secondBilly.GetComponent<Genes>().traits[2];
		}

		


    }
	// void Start()
	//{	
	//firstBillyT1 = firstBilly.GetComponent<Genes>().traits[0];
	//secondBillyT1 = secondBilly.GetComponent<Genes>().traits[0];
	//firstBillyT2 = firstBilly.GetComponent<Genes>().traits[1];
	//secondBillyT2 = secondBilly.GetComponent<Genes>().traits[1];
	//firstBillyT3 = firstBilly.GetComponent<Genes>().traits[2];
	//secondBillyT3 = secondBilly.GetComponent<Genes>().traits[2];

	
	
	//if (firstBillyT1 == secondBillyT1); {}
	//if (firstBillyT2 == secondBillyT2); {}
	//if (firstBillyT3 == secondBillyT3); {}
}
