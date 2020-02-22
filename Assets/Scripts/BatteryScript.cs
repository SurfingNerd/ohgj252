using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public GameObject infoGameObject;
    // Start is called before the first frame update

    private GameObject playerInRange = null;
    private bool isMounted = false;
    private Transform originaParent = null;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange != null && Input.GetKey(KeyCode.E))
        {
            if (isMounted)
            {
                Debug.Log("Unmounted");
                this.transform.SetParent(originaParent);
                isMounted = false;
                // todo: Unmount.
            }
            else
            {
                // mount.
                isMounted = true;
                originaParent = this.transform.parent;
                this.transform.SetParent(playerInRange.transform);
                Debug.Log("Mounted");
            }
        }
    }
    
    
    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered: " + other.gameObject.name + " " + other.tag);
        if (other.CompareTag("Player"))
        {
            infoGameObject.SetActive(true);
            playerInRange = other.gameObject;
        }
        
        //this.gameObject.transform.
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited: " + other.gameObject.name + " " + other.tag);
        if (other.CompareTag("Player"))
        {
            infoGameObject.SetActive(false);
            if (!isMounted)
            {
                playerInRange = null;
            }
        }
    }
}
