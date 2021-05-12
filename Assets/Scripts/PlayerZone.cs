using UnityEngine;

public class PlayerZone : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        FindObjectOfType<LivesDisplay>().LoseLife();
    }
}
