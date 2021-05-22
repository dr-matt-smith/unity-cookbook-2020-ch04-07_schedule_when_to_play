using UnityEngine;
using System;
using UnityEngine.UI;

public class ScheduledSoundManager : MonoBehaviour 
{
    public Text textScheduledMessage;
    private AudioSource audioSource;
    private bool activated = false;
    private float secondsUntilPlay = 0;
    private DateTime scheduledPlayTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// play sound at specified time
    /// </summary>
    public void PlayMusic(int hours, int minutes, int seconds)
    {
        scheduledPlayTime = DateTime.Today.Add(new TimeSpan(hours, minutes, seconds));
        UpdateSecondsUntilPlay();
        audioSource.PlayDelayed(secondsUntilPlay);
        activated = true;
    }

    private void Update()
    {
        // default message
        String message = "played!";

        if(activated){
            UpdateSecondsUntilPlay();
            if(secondsUntilPlay > 0){
                message = "scheduled to play in " + secondsUntilPlay + " seconds";
            } else {
                activated = false;
            }
            textScheduledMessage.text = message;
        }
    }

    private void UpdateSecondsUntilPlay()
    {
        TimeSpan delayUntilPlay = scheduledPlayTime - DateTime.Now;
        secondsUntilPlay = delayUntilPlay.Seconds;
    }
}