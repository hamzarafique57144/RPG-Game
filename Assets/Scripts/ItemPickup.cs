using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;


public class ItemPickup : Interactable
{
    
    public static ItemPickup Instance { get; private set; }
    private void Awake()
    {
        Instance = this; 
    }
    [SerializeField] Item item;
    

  
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    private void PickUp()
    {
       // item.Use();
        Debug.Log("Picking Up " + item.name);
        //Add to the inventory
        bool wasPickedUp = Inventory.Instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject, 1f);
            
        }

    }

    
}
