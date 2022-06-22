using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public GameObject item;
    public string itemType;

    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    private void Start()
    {
       inventory = GameObject.FindGameObjectWithTag("Slot").GetComponent<Inventory>();
    }

    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only)
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch(itemType)
            {
                case "staff":
                Instantiate(item, inventory.slots[0].transform,false);
                break;

                case "bow":
                Instantiate(item, inventory.slots[1].transform,false);
                break;

                case "vacuum":
                Instantiate(item, inventory.slots[2].transform,false);
                break;
            }

            Destroy(gameObject);
        }

        
    }

    
            
}
