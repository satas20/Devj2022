using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Menu : MonoBehaviour
{
    public GameObject settings;
    public AudioMixer music;

    public AudioMixer sound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setLevelSound(float sliderValue) 
    {
        Debug.Log(sliderValue);

        sound.SetFloat("SoundVolume",Mathf.Log10 (sliderValue)*20);
    }
    public void setValueMusic(float sliderValue)
    {
        Debug.Log(sliderValue);

        sound.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PLay() 
    {
        SceneManager.LoadScene("xx");
    }
    public void Exit() 
    {
        Application.Quit();
    }
    public void Settings() 
    {
        settings.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Back() 
    {
        gameObject.SetActive(true);
        settings.SetActive(false);
    }

}
