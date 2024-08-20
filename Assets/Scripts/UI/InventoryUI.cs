using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    [SerializeField] InventorySlot[] slots;
   
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChanged += UpdateUI;
        
    }

   
    private void UpdateUI(object sender, System.EventArgs e)
    {

        for (int i=0; i< slots.Length;i++)
        {
           

            if (i < inventory.GetTotalItems())
            {
                Debug.Log("i is " + i + "inventory.Count " + inventory.GetTotalItems());

                slots[i].AddItem(inventory.GetItem(i));
               
            }
            else
            {

                slots[i].ClearSlot();
            }
        }
    }
}
