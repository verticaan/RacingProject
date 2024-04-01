using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (musicSlider != null)
        {
            musicSlider.value = AudioManager.instance.GetMusicVolume();
        }

        if (sfxSlider != null)
        {
            sfxSlider.value = AudioManager.instance.GetSFXVolume();
        }
    }

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }

    public void QuitSound()
    {
        AudioManager.instance.PlaySFX("QuitSound");
    }
}
