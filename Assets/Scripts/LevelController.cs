using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject pauseLabel;

    Slider timer;

    int attackersNumber = 0;
    bool timerFinished = false;
    bool isPaused = false;
    float waitToLoad = 4.5f;

    private void Start()
    {
        timer = FindObjectOfType<Slider>();
        if (!timer) { Debug.LogError("Nessuno slider presente in scena."); }

        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        pauseLabel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !(isPaused))
        {
            Pause();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Resume();
        }
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseLabel.SetActive(false);
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseLabel.SetActive(true);
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

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }
}
