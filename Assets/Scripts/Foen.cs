using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foen : MonoBehaviour
{

    public float radius = 3;

    private Rigidbody2D playerInRange;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Foen: Entered: " + other.gameObject.name + " " + other.tag);
            //infoGameObject.SetActive(true);
            playerInRange = other.gameObject.GetComponent<Rigidbody2D>();
        }
        
        //this.gameObject.transform.
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            Debug.Log(" Foen: Exited: " + other.gameObject.name + " " + other.tag);
            playerInRange = null;
        }
    }

    public void FixedUpdate()
    {
        if (playerInRange)
        {

            float distance = Vector3.Distance(this.transform.position, playerInRange.transform.position);
            Vector2 force = Vector2.up * Time.fixedDeltaTime * (10000 / distance);
            Debug.Log("Adding FOrce: " + force);
            playerInRange.AddForce(force , ForceMode2D.Force);
        }
    }
}
