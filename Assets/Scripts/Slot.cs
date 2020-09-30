using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
  //  Image m_slotImage;
    Image m_iconImage;
    AudioSource m_audio;
 
    ItemStats m_item;

    private void Awake()
    {
        m_iconImage = GetComponentInChildren<Image>();
        m_iconImage.enabled = false;
        m_audio = GetComponent<AudioSource>();
    }

    public void AddItem(ItemStats newItem)
    {
        m_item = newItem;
        m_iconImage.sprite = newItem.m_sprite;
        m_audio.clip = newItem.m_audio.clip;
        m_iconImage.enabled = true;
    }


    //TO DO
    //public void ClearSlot()
    //{
    //    m_item = null;

    //    m_iconImage.sprite = null;
    //    m_iconImage.enabled = false;
    //}

    //// Called when dropped item in the slot
    //public void OnItemDropped()
    //{
    //    Inventory.m_inventory.Remove(item);
    //}

 
}
