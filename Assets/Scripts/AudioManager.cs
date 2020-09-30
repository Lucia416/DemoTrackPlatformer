using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    AudioSource[] m_audiosources;
    bool m_isMusicStarted;

    private void Awake()
    {
        m_audiosources = GetComponentsInChildren<AudioSource>();    
    }

    //check if all the sounds are off to remove delay
    private bool IsEverySoundOff()
    {
        for (int i = 0; i < m_audiosources.Length; i++)
        {
            if (m_audiosources[i].isPlaying)
            {
                return false;
            }
        }
        return true;
    }
    

    public void OnClickAudioEvent(AudioSource audio)
    {
        if(m_isMusicStarted == false)
        {
            m_isMusicStarted = true;
            if (audio.isPlaying == false) audio.Play();
            else audio.Stop();
        }
        else if (m_isMusicStarted)
        {
            //adding delay to next sample in order to sync the samples
            audio.PlayDelayed(2f);
        }
        if (IsEverySoundOff())
        {
            m_isMusicStarted = false;
        }
    }
}
