using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemChanged;
    [SerializeField] GameObject inventoryUI;
    public static Inventory Instance { get; private set; }
    public List<Item> items= new List<Item>();
    private int space = 20;
    private void Awake()
    {
        Instance = this; 
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
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
          
            items.Add(item);
            OnItemChanged?.Invoke(this, EventArgs.Empty);
        }
        return true;
    }
    public Item GetItem(int n)
    {
        return items[n];
    }
    public int GetTotalItems()
    {
        return items.Count;
    }



   
    public void Remove(Item item)
    {
        items.Remove(item);
        OnItemChanged?.Invoke(this, EventArgs.Empty);
    }
}
