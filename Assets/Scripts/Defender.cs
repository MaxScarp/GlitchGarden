using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    public int GetStarCost() => starCost;

    public void AddStars(int stars)
    {
        FindObjectOfType<StarDisplay>().AddStars(stars);
    }
}
