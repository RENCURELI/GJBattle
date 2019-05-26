using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Destruction");
        Object.Destroy(this, 0.5f);
    }
}
