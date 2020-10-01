using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    public Image m_iconImage;
    AudioSource m_audio;

    ItemStats m_item;

    private void Awake()
    {
        m_iconImage.enabled = false;
        m_audio = GetComponent<AudioSource>();
        if (m_audio == null)
        {
            Debug.Log("Component empty on slot");
        }
    }

    public void AddItem(ItemStats newItem)
    {

        m_item = newItem;
        m_iconImage.enabled = true;
        m_audio.clip = newItem.m_audio.clip;
        m_iconImage.sprite = newItem.m_sprite;


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
