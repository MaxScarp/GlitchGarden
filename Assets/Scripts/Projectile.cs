using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}