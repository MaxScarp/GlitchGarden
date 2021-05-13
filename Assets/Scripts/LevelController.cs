using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;

    Slider timer;

    int attackersNumber = 0;
    bool timerFinished = false;
    float waitToLoad = 4.5f;

    private void Start()
    {
        timer = FindObjectOfType<Slider>();
        if (!timer) { Debug.LogError("Nessuno slider presente in scena."); }

        winLabel.SetActive(false);
    }

    public void AddAttackersNumber()
    {
        attackersNumber++;
    }

    public void SubtractAttackersNumber()
    {
        attackersNumber--;
        if (attackersNumber == 0 && timerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void TimerFinished()
    {
        timerFinished = true;
        StopAttackersSpawn();
    }

    private void StopAttackersSpawn()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawn in spawners)
        {
            spawn.StopSpawning();
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        GetComponent<LevelLoader>().LoadNextScene();
    }
}
