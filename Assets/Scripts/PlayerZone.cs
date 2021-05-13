using UnityEngine;

public class PlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<LivesDisplay>().LoseLife();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Attacker>().Die();
    }
}
