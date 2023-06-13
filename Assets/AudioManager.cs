using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("AudioClips:")]
    public Sound[] MusicSounds, SfxSounds;

    [Header("Audio Sources:")]
    public AudioSource MusicSource, SfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string Name)
    {
        Sound s = Array.Find(MusicSounds, x => x.Name == Name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource.clip = s.Clip;
            MusicSource.Play();
        }
    }

    public void PlaySFX(string Name, float Volume)
    {
        Sound s = Array.Find(SfxSounds, x => x.Name == Name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            SfxSource.clip = s.Clip;
            SfxSource.PlayOneShot(s.Clip, Volume);
        }
    }

    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }

    public void ToggleSFX()
    {
        SfxSource.mute = !SfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        SfxSource.volume = volume;
    }
}
