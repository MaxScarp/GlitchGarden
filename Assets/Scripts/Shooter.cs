using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] Projectile projectilePrefab;

    public void Fire()
    {
        Instantiate(projectilePrefab, gun.transform.position, transform.rotation);
    }
}
