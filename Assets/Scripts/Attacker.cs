using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int health = 10;

    float movementSpeed = 0.9f;

    private void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float movementSpeed) { this.movementSpeed = movementSpeed; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessHit(collision);
    }

    private void ProcessHit(Collider2D collision)
    {
        health -= collision.GetComponent<DamageDealer>().GetDamage();
        Destroy(collision.gameObject);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
