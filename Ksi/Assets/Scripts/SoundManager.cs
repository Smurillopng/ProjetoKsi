using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    public AudioMixer musicManage;
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume") || !PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            PlayerPrefs.SetFloat("sfxVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void ChangeMusicVolume(float sliderValue)
    {
        musicManage.SetFloat("musicVol", Mathf.Log10 (musicSlider.value) * 20);
        Save();
    }

    public void ChangeSFXVolume(float sliderValue)
    {
        musicManage.SetFloat("sfxVol", Mathf.Log10 (sfxSlider.value) * 20);
        Save();
    }
    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
}
