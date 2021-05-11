using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(target);
        }
    }
}
