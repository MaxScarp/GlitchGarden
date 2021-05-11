using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Grave>())
        {
            Jump();
        }
        else if (otherObject.GetComponent<Defender>())
        {
            Attack(otherObject);
        }
    }

    private void Jump()
    {
        GetComponent<Animator>().SetTrigger("jumpTrigger");
    }

    private void Attack(GameObject otherObject)
    {
        GetComponent<Attacker>().Attack(otherObject);
    }
}
