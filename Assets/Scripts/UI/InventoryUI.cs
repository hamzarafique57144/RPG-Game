using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    void Start()
    {
        inventory = Inventory.Instance;
        inventory.OnItemChanged += UpdateUI;
    }

    private void UpdateUI(object sender, System.EventArgs e)
    {
        
    }
}
