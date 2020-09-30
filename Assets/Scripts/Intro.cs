using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Intro : MonoBehaviour 
{

	public Text m_txt;
    string m_intro;

    public GameObject m_panel;

    public bool m_isInitialIntro = true;

    void Awake()
    {
        m_intro = m_txt.text;
        m_txt.text = "";
        if (m_isInitialIntro) StartCoroutine("PlayText");
    }

    //to be called when the script is a reference eg in the inventory
    public void StartPlayText()
    {
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in m_intro)
        {
            m_txt.text += c;
            yield return new WaitForSeconds(0.125f);
        }
        yield return StartCoroutine("ShowPanel");
    }

    IEnumerator ShowPanel()
    {
        m_panel.SetActive(true);
        yield return null;
    }
    public void StartGame()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Scenes/Main");
    }

}
