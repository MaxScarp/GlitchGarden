using TMPro;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    TextMeshProUGUI difficultyLabel;

    private void Start()
    {
        difficultyLabel = GetComponent<TextMeshProUGUI>();
    }

    public void SetDifficulty(int difficulty)
    {
        PlayerPrefsController.SetDifficulty(difficulty);

        switch (difficulty)
        {
            case 1:
                difficultyLabel.text = "EASY";
                break;
            case 2:
                difficultyLabel.text = "MEDIUM";
                break;
            case 3:
                difficultyLabel.text = "HARD";
                break;
            default:
                Debug.LogError("Difficulty is out of range.");
                break;
        }
    }
}
