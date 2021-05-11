using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100, health = 100;

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetStarCost() => starCost;

    public void AddStars(int stars)
    {
        FindObjectOfType<StarDisplay>().AddStars(stars);
    }
}
