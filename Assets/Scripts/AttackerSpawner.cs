using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackersPrefab;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int random = Random.Range(0, attackersPrefab.Length);
        Spawn(attackersPrefab[random]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker attackerClone = Instantiate(attacker, transform.position, transform.rotation) as Attacker;
        attackerClone.transform.parent = transform;
    }
}
