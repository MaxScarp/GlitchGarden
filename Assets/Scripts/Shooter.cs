using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] Projectile projectilePrefab;

    AttackerSpawner myLaneSpawner;
    Animator animator;

    GameObject projectilesParent;

    const string PROJECTILES_PARENT_NAME = "Projectiles";

    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectilesParent();
    }

    private void CreateProjectilesParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT_NAME);
        if (!projectilesParent)
        {
            projectilesParent = new GameObject(PROJECTILES_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane() => !(myLaneSpawner.transform.childCount <= 0);
    public void Fire()
    {
        Projectile projectile =  Instantiate(projectilePrefab, gun.transform.position, transform.rotation) as Projectile;
        projectile.transform.parent = projectilesParent.transform;
    }
}
