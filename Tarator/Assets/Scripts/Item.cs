using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    public UI_inventory inventory;
    public GameObject item;

    public string itemType;

    // Start is called on the frame when a script is enabled just before
    // any of the Update methods is called the first time.
    private void Start(){

    }

    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if other's type is "Player"
        if (other.gameObject.tag == "Player")
        {
            switch(itemType)
            {
                // Place to Melee Slot
                case "staff":
                inventory.inventory.addItem(new Items {itemType = Items.ItemType.MeleeWeapon});
                Debug.Log(inventory.inventory.itemList.Count);
                break;

                // Place to Ranged Slot
                case "bow":
                inventory.inventory.addItem(new Items {itemType = Items.ItemType.RangedWeapon});
                Debug.Log(inventory.inventory.itemList.Count);
                break;

                // Place to Special Weapon Slot
                case "vacuum":
                inventory.inventory.addItem(new Items {itemType = Items.ItemType.SpecialWeapon});
                Debug.Log(inventory.inventory.itemList.Count);
                break;
            }

            // Remove unneeded object
            Destroy(gameObject);
        }

    }
            
}
