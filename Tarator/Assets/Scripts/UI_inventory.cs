using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_inventory : MonoBehaviour
{
    public Inventory inventory;
    private Transform MeleeSlot;
    private Transform RangedSlot;
    private Transform SpecialSlot;
    
    public GameObject MeleeWeapon;
    public GameObject SpecialWeapon;
    public GameObject RangedWeapon;

    private void Start()
    {
        //MeleeWeapon = GameObject.Find("UI_Staff");
        MeleeWeapon.SetActive(false);

        //SpecialWeapon = GameObject.Find("UI_Vacuum");
        SpecialWeapon.SetActive(false);
          
        //RangedWeapon = GameObject.Find("UI_Bow");
        RangedWeapon.SetActive(false);
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }
    
    private void RefreshInventoryItems(){
        foreach(Items item in inventory.itemList){
            if(item.itemType == Items.ItemType.MeleeWeapon){
               MeleeWeapon.SetActive(true);
            }
            if(item.itemType == Items.ItemType.SpecialWeapon){
                SpecialWeapon.SetActive(true);
            }
            if(item.itemType == Items.ItemType.RangedWeapon){
                RangedWeapon.SetActive(true);
            }
        }
    }
}
