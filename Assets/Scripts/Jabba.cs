using UnityEngine;

public class Jabba : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            Attack(otherObject);
        }
    }

    private void Attack(GameObject otherObject)
    {
        GetComponent<Attacker>().Attack(otherObject);
    }
}
