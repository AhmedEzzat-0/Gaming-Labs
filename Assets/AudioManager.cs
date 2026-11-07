using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Why static? Because the whole game will have only 1 instance of AudioManager
    public static AudioManager Instance;

    public AudioSource musicSource; // source that plays background music
    public AudioSource sfxSource; // source that plays sound effects

    public AudioClip overworldMusic; // audio clip of background music for level 1
    public AudioClip caveMusic; // audio clip of background music for level 2

    public AudioClip[] variousSFX; // array of sound effects clips to keep things varied

    void Awake()
    {
        // Make sure the entire game only has one Audio Manager throughout
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        // Background music clip is assigned
        musicSource.clip = overworldMusic;

        musicSource.Play();
    }

    // Play a specific sound effect
    public void PlayMusicSFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    // Play a specific soundtrack
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // Play a random sound effect
    public void PlayRandomSFX(params AudioClip[] clips)
    {
        // Assign the incoming array of items to our local array variable
        variousSFX = clips;

        // Randomly select a sound clip from the array
        int index = Random.Range(0, variousSFX.Length);

        sfxSource.PlayOneShot(variousSFX[index]);
    }
}