using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] GameObject deathVFX;

    GameObject target;

    float movementSpeed = 0.9f;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddAttackersNumber();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if(levelController != null)
        {
            levelController.SubtractAttackersNumber();
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!target)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!target || !target.GetComponent<Defender>()) { return; }
        target.GetComponent<Defender>().LoseHealth(damage);
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        this.target = target;
    }

    public void SetMovementSpeed(float movementSpeed) { this.movementSpeed = movementSpeed; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessHit(collision);
    }

    private void ProcessHit(Collider2D collision)
    {
        if (collision.GetComponent<DamageDealer>())
        {
            health -= collision.GetComponent<DamageDealer>().GetDamage();
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        TriggerDeathVFX();
        Destroy(gameObject);
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject smoke = Instantiate(deathVFX, (new Vector2(transform.position.x + -0.3f, transform.position.y)), transform.rotation);
        Destroy(smoke, 1.5f);
    }
}
