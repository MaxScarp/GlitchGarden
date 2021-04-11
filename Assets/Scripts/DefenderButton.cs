using UnityEngine;

public class DefenderButton : MonoBehaviour
{

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
