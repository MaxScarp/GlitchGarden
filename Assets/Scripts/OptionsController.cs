using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    [SerializeField] float defaultVolume = 0.8f;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    }

    private void Update()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No Music Player found in the scene.");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<LevelLoader>().MainMenu();
    }

    public void SetToDefaultSettings()
    {
        volumeSlider.value = defaultVolume;
    }
}
