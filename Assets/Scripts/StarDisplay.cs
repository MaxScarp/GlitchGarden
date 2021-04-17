using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 50;

    TextMeshProUGUI starText;

    private void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int stars) => (this.stars >= stars);

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int stars)
    {
        this.stars += stars;
        UpdateDisplay();
    }

    public void SpendStars(int stars)
    {
        if(this.stars >= stars)
        {
            this.stars -= stars;
            UpdateDisplay();
        }
    }
}
