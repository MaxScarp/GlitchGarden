using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] GameObject deathVFX;

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
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject smoke = Instantiate(deathVFX, (new Vector2(transform.position.x + -0.3f, transform.position.y)), transform.rotation);
        Destroy(smoke, 1.5f);
    }
}
