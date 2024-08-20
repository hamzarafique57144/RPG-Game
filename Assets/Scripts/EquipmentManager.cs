using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];
    }

    public void Equip(Equipment newItem)
    {
        int indexOfSlot = (int)newItem.equipmentSlot;
        currentEquipment[indexOfSlot] = newItem;

        Equipment oldItem = null;
        if(currentEquipment!= null)
        {
            oldItem = currentEquipment[indexOfSlot];
            inventory.Add(oldItem);
        }
    }
}
