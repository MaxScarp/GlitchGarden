using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    TextMeshProUGUI costText;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        costText = GetComponentInChildren<TextMeshProUGUI>();
        if(!costText)
        {
            Debug.LogError(name + "Manca l'ettichetta con il costo, mettine una!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetDefenderPrefab(defenderPrefab);
    }
}
