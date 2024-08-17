using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemChanged;
    public static Inventory Instance { get; private set; }
    public List<Item> items= new List<Item>();
    private int space = 20;
    private void Awake()
    {
        Instance = this; 
    }
    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            OnItemChanged?.Invoke(this, EventArgs.Empty);
            items.Add(item);
            
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
}
