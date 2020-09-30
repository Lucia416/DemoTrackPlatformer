using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ItemStats
{
    public int m_id;
    public bool m_isRightTrack;
    public Sprite m_sprite;
    public AudioSource m_audio;
    public bool m_isItemPickedUp { get; set; }

    public ItemStats(int id, bool isRightTrack, Sprite sprite, AudioSource audio)
    {
        m_id = id;
        m_isRightTrack = isRightTrack;
        m_sprite = sprite;
        m_audio = audio;
    }
    public ItemStats()
    {
        this.m_id = -1;
    }

}

[Serializable]
public class Inventory : MonoBehaviour
{

    public static Inventory m_inventory;

    //slots available in the inventory
    [HideInInspector]
    public int m_availableSlots = 6;

    public Intro m_intro;

    [SerializeField]
    public List<ItemStats> m_items = new List<ItemStats>();
    public delegate void UpdateItemStatus();
    public UpdateItemStatus m_updateItemStatus;

    public GameObject m_panelSlot;

    [HideInInspector]
    public bool m_itemAllCollected;

    void Awake()
    {
       
        if (m_inventory != null)
        {
            Debug.LogError("There are multiple inventories in the inspector");
            return;
        }
        else
        {
            m_inventory = this;
        }

    }

    public void AddToList(ItemStats itemStats)
    {
        if (m_items.Count >= m_availableSlots)
        {
            m_panelSlot.SetActive(true);
            m_intro.StartPlayText();
            if (m_updateItemStatus != null) m_updateItemStatus.Invoke();
            DataHandler dataHandler = GetComponentInChildren<DataHandler>();
            if (dataHandler.m_onStatusChanged != null) dataHandler.m_onStatusChanged.Invoke();
        }
        m_items.Add(itemStats);

    }

    //WIP
    //public void Remove(ItemStats item)
    //{
    //    m_items.Remove(item);
    //    if (m_updateItemStatus != null) m_updateItemStatus.Invoke();
    //}

    public List<ItemStats> GetItems()
    {
        return m_items;
    }
}
