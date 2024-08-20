using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    Item item;
    [SerializeField] Image icon;
    [SerializeField] Button removeButton;

   
    public void AddItem(Item newItem)
    {
        icon.enabled = true;
        removeButton.interactable = true;
        item = newItem;
        icon.sprite = item.icon;
        Debug.Log("Name of item is "+item.name);




    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
       removeButton.interactable = false;
    }

    public void OnRemoveButtonClick()
    {
        Inventory.Instance.Remove(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            Debug.Log("Using in slot");
            item.Use();
        }
    }
}
