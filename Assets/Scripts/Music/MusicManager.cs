using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }
    AudioSource audioSource;
    [SerializeField]
    AudioClip track;

    [SerializeField]
    float dampenMusicVolume;

    float normalVolume;
    void Start()
    {
        instance = gameObject.GetComponent<MusicManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
        normalVolume = audioSource.volume;
    }

    public void StartMusic(float time)
    {
        audioSource.volume = 0f;
        Tween.Volume(audioSource, normalVolume, time, 0f, Tween.EaseLinear, obeyTimescale: false);
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void DampenMusic()
    {
        Tween.Volume(audioSource, dampenMusicVolume, 0.5f, 0f, Tween.EaseLinear,obeyTimescale: false);
    }

    public void RestoreNormalVolime()
    {
        Tween.Volume(audioSource, normalVolume, 0.5f, 0f, Tween.EaseLinear, obeyTimescale: false);
    }

}
