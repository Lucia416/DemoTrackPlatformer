using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    public Transform m_itemsParent;   

    Slot[] m_slots;

    void Start()
    {
        m_slots = m_itemsParent.GetComponentsInChildren<Slot>();
        Inventory.m_inventory.m_updateItemStatus += UpdateSlot;
    }

    //called with delegate, loops through the slots and add item when items are added in the inventory
    void UpdateSlot()
    {
        for (int i = 0; i < m_slots.Length; i++)
        {
            if (i < Inventory.m_inventory.m_items.Count) 
            {
                m_slots[i].AddItem(Inventory.m_inventory.m_items[i]);  
            }
            else
            {
           //     m_slots[i].ClearSlot();
            }
        }
    }
}
