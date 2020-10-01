using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHandler : MonoBehaviour
{
    AudioSource m_audio;

    public GameObject m_restartPanel;
    public bool m_isDead = false;

    private void Awake()
    {
        m_audio = GetComponent<AudioSource>();
        SaveAndReload.Init();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Save();
        m_audio.Play();
        m_restartPanel.SetActive(true);
        Inventory.m_inventory.m_updateItemStatus.Invoke();
        m_isDead = true;
    }

    private void Save()
    {
        List<ItemStats> itemStats = Inventory.m_inventory.GetItems();
   
        SaveData saveData = new SaveData
        {
            m_itemStats = itemStats,
        };
        string json = JsonUtility.ToJson(saveData);
        SaveAndReload.Save(json);
    }

    private void Load()
    {
        string saveString = SaveAndReload.Load();
        if (saveString != null)
        {
            SaveData savaData = JsonUtility.FromJson<SaveData>(saveString);

            Inventory.m_inventory.m_items = savaData.m_itemStats;
        }
        else
        {
            Debug.Log("Nothing to Load");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Load();
        m_isDead = false;
        m_restartPanel.SetActive(false);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

}
