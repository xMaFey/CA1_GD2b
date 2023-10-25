using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;
    public AudioClip swordAttackSound;
    public AudioClip ambientMusic;
    public AudioClip backgroundMusic;
    public AudioClip slimeSpawn;
    public AudioClip slimeHit;
    public AudioClip playerHit;
    public AudioClip gameOver;


    private AudioSource soundEffectSource;
    private AudioSource backgroundMusicSource;
    private AudioSource ambientMusicSource;

    // This will be in all scenes and it wont desapear or get destroyed
    void Awake()
    {
        if(audioInstance == null)
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundEffectSource = gameObject.AddComponent<AudioSource>(); 
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        ambientMusicSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();

        ambientMusicSource.clip = ambientMusic;
        ambientMusicSource.loop = true;
        ambientMusicSource.Play();
    }


    // Created functions which play the sounds for each thing
    
    public void PlaySwordAttackSound()
    {
        soundEffectSource.PlayOneShot(swordAttackSound);
    }

    public void PlaySlimeHitSound()
    {
        soundEffectSource.PlayOneShot(slimeHit);
    }

    public void PlaySlimeSpawnSound()
    {
        soundEffectSource.PlayOneShot(slimeSpawn);
    }

    public void PlayPlayerHitSound()
    {
        soundEffectSource.PlayOneShot(playerHit);
    }

    public void PlayGameOverSound()
    {
        soundEffectSource.PlayOneShot(gameOver);
    }

    // Background sound functions
    public void PlayBackgroundMusic()
    {
        if(!backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Play();
        }
    }

    public void PauseBackgroundMusic()
    {
        backgroundMusicSource.Pause();
    }

    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }


    // Ambient sound functions
    public void PlayAmbientMusic()
    {
        if(!ambientMusicSource.isPlaying)
        {
            ambientMusicSource.Play();
        }
    }

    public void PauseAmbientMusic()
    {
        ambientMusicSource.Pause();
    }

    public void StopAmbientMusic()
    {
        ambientMusicSource.Stop();
    }
    public void SetAmbientMusicVolume(float volume)
    {
        ambientMusicSource.volume = volume;
    }
}
