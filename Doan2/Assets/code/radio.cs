using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class radio : MonoBehaviour
{
   
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            other.GetComponent<dichuye>().count++;
            Destroy(gameObject);
        }
    }
    

}
