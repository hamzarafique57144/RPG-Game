using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
   
        new public string name ;
        public Sprite icon ;
        public bool isDefaultItem = false;

       public virtual void Use()
       {
        //Use the Item
        Debug.Log("Use this item " + name);
       }
     public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
       
} 
