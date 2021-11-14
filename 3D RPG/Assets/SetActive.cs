using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    // Start is called before the first frame update
    float respawn;
    public float respawnDelay;
    bool isActive;
    public GameObject dataobj;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn <= 0.0f && isActive == false) //if the child object is inactive, count down and reactivate when timer expires
        {
           dataobj.SetActive(true);
            isActive = true;
        }
        else
            respawn -= Time.deltaTime;

    }
    public void DeactivateObject() //sets the data object to inactive, and sets a respawn timer
    {
        isActive = false;
        respawn = respawnDelay;
        dataobj.SetActive(false);
    }
}
