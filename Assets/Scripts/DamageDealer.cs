using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 5;

    public int GetDamage() => damage;
}
