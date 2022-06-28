using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOn;
    [SerializeField] Image soundOff;

    private bool muted = false;

    private void Update()
    {
        UpdateButtonIcon();
    }

    // Start is called before the first frame update
    void Start()
    {   
        UpdateButtonIcon();
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(!muted)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
    }


    private void UpdateButtonIcon()
    {
        if(!muted)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {    
        if(muted)
        {
            PlayerPrefs.SetInt("muted",1);
        }
        else
        {
            PlayerPrefs.SetInt("muted",0);
        }
    }
}
