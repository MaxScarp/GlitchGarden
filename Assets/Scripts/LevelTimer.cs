using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [Tooltip("Time in seconds to the end of the level")]
    [SerializeField] int timeInSeconds = 10;

    bool triggeredTimerFinished = false;

    private void Update()
    {
        if (triggeredTimerFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / timeInSeconds;

        bool timerFinished = (Time.timeSinceLevelLoad >= timeInSeconds);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().TimerFinished();
            triggeredTimerFinished = true;
        }
    }
}
