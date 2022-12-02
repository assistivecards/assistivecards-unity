using UnityEngine;
using UnityEngine.UI;

public class SoundManagerUI : MonoBehaviour
{
    GameAPI gameAPI;
    public Toggle musicToggle;
    public Toggle sfxToggle;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    private void Awake()
    {
        gameAPI = Camera.main.GetComponent<GameAPI>();

    }
    private void OnEnable()
    {
        musicToggle.isOn = gameAPI.GetMusicPreference() == 1 ? true : false;
        sfxToggle.isOn = gameAPI.GetSFXPreference() == 1 ? true : false;
        musicSource.mute = musicToggle.isOn ? false : true;
        sfxSource.mute = sfxToggle.isOn ? false : true;
    }
    public void SaveSettings()
    {
        gameAPI.SetMusicPreference(musicToggle.isOn ? 1 : 0);
        gameAPI.SetSFXPreference(sfxToggle.isOn ? 1 : 0);
        musicSource.mute = musicToggle.isOn ? false : true;
        sfxSource.mute = sfxToggle.isOn ? false : true;
        if (musicToggle.isOn == false)
        {
            musicSource.Stop();
        }
        else if (musicToggle.isOn == true)
        {
            musicSource.Play();
        }
    }
}
