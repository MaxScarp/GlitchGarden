using UnityEngine;

public class Juju : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Animator>().SetTrigger("ghostingTrigger");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Animator>().SetTrigger("stopGhostingTrigger");
        }
    }
}
