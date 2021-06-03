using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int damage = 1;

    int baseLives = 5;
    TextMeshProUGUI LivesText;

    private void Start()
    {
        baseLives -= PlayerPrefsController.GetDifficulty();
        LivesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        LivesText.text = baseLives.ToString();
    }

    public void LoseLife()
    {
        baseLives -= damage;
        UpdateDisplay();

        if(baseLives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }
}
