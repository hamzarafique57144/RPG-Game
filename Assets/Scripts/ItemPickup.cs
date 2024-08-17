using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }
    private void PickUp()
    {
        Debug.Log("Picking Up "+item.name);
        //Add to the inventory
        bool wasPickedUp =Inventory.Instance.Add(item);
        if(wasPickedUp)
        {
            Destroy(gameObject,1f);
        }
        
    }

   
}
