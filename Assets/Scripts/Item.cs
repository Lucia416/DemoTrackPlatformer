using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    //assigning value to items
    public int m_itemId;
    public Sprite m_sprite;
    public AudioSource m_audio;
    bool m_isRightTrack;
    public bool m_isPickedUp = false;
    ItemStats m_itemStats;

    private void Awake()
    {
        m_itemStats = new ItemStats(m_itemId,m_isRightTrack, m_sprite, m_audio);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_isPickedUp) AddToTheInventory();
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //hide the obj once it's picked up   
        if (m_isPickedUp) gameObject.SetActive(false);
    }

    public void AddToTheInventory()
    {      
        m_isPickedUp = true;
        if(gameObject) Inventory.m_inventory.AddToList(m_itemStats);
    }

}