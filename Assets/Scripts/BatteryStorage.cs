using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryStorage : MonoBehaviour
{
    private Foen foen;
    // Start is called before the first frame update
    void Start()
    {
        foen = GetComponentInParent<Foen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered: " + other.gameObject.name + " " + other.tag);
        //if (other.CompareTag("Player"))
        //{
        //    infoGameObject.SetActive(true);
        //    playerInRange = other.gameObject;
        //}

        BatteryScript battery = other.GetComponent<BatteryScript>();

        if (battery != null)
        {
            Debug.Log("activated:");
            foen.ActivateFoen();
        }

        //this.gameObject.transform.
    }

    //When the Primitive exits the collision, it will change Color
    private void OnTriggerExit2D(Collider2D other)
    {
        BatteryScript battery = other.GetComponent<BatteryScript>();

        if (battery != null)
        {
            Debug.Log("Deactivated:");
            foen.DeactivateFoen();
        }
    }
}
