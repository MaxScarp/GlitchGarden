using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] int defaultDifficulty = 2;

    private void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        MusicPlayer musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogError("No Music Player found in the scene.");
        }

        Difficulty difficulty = FindObjectOfType<Difficulty>();
        if (difficulty)
        {
            difficulty.SetDifficulty((int)difficultySlider.value);
        }
        else
        {
            Debug.LogError("No Difficulty Script found in the scene.");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        FindObjectOfType<LevelLoader>().MainMenu();
    }

    public void SetToDefaultSettings()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
