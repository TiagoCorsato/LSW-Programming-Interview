using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource chicken_1, coins_1, collect_1, alert_1;

    public void PlayChickenAudio_1()
    {
        chicken_1.Play();
    }

    public void PlayCoinsAudio_1()
    {
        coins_1.Play();
    }

    public void PlayCollectAudio_1()
    {
        collect_1.Play();
    }

    public void PlayAlertAudio()
    {
        alert_1.Play();
    }
}
