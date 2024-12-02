using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicEffectGroup;
    [SerializeField] private AudioMixerGroup soundEffectsGroup;

    public static AudioManager Instance;
    public Sounds[] sounds;

    private Dictionary<string, float> musicPlaybackPositions = new Dictionary<string, float>();

    public void Awake()
    {
        Instance = this;

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.Loop;

            switch (s.audioType)
            {
                case Sounds.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = soundEffectsGroup;
                    break;

                case Sounds.AudioTypes.music:
                    s.source.outputAudioMixerGroup = musicEffectGroup;
                    break;
            }
        }
    }

    public void FixedUpdate()
    {
        foreach (Sounds s in sounds)
        {
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.clipName == name);
        if (s == null)
        {
            Debug.LogWarning("Sound clip not found: " + name);
            return;
        }

        if (s.source.isPlaying)
        {
            //s.playbackPosition = s.source.time; // Store the playback position in the Sounds object
            s.source.Stop();
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.clipName == name);

        if (s == null)
        {
            Debug.LogWarning("Sound clip not found: " + name);
            return;
        }

        s.source.Play();

        if(name == "Music1" || name == "Music2" || name == "Music3" || name == "Music4" || name == "Music5" || name == "Music6" || name == "Music7")
        {
            StartCoroutine(WaitForSongToEnd(name));
            StartCoroutine(MonitorAudioClipEnd(name, s.source.clip.length));
        }
    }

    public SettingsOptions settingsScript;
    public int songNumber;
    IEnumerator WaitForSongToEnd(string songName)
    {
        Sounds s = Array.Find(sounds, sound => sound.clipName == songName);

        if (s == null)
        {
            Debug.LogWarning("Sound clip not found: " + songName);
            yield break;
        }

        //Debug.Log(songName + " is playing!");

        while (s.source.isPlaying)
        {
            yield return null;
        }

        // The song has ended, execute the PlayRandomSong method from the settingsScript

        if(songName == "Music1") { songNumber = 1;  SettingsOptions.music1Playing = false; }
        if (songName == "Music2") { songNumber = 2; SettingsOptions.music2Playing = false; }
        if (songName == "Music3") { songNumber = 3; SettingsOptions.music3Playing = false; }
        if (songName == "Music4") { songNumber = 4; SettingsOptions.music4Playing = false; }
        if (songName == "Music5") { songNumber = 5; SettingsOptions.music5Playing = false; }
        if (songName == "Music6") { songNumber = 6; SettingsOptions.music6Playing = false; }
        if (songName == "Music7") { songNumber = 7; SettingsOptions.music7Playing = false; }

        //Debug.Log(songName +" has eneded.");

        if(Choises.isInDeathScreen == false && Choises.isInWinScreen == false && DangerButtonEnding.isPlayingDangerButton == false && Choises.isChampionTransition == false && Choises.isHordeTransition == false && Choises.isBossTransition == false)
        {
            settingsScript.PlayRandomSong(songNumber);
        }
    }

    IEnumerator MonitorAudioClipEnd(string clipName, float clipLength)
    {
        float endTime = Time.time + clipLength;

        while (Time.time < endTime)
        {
            yield return null;
        }

    }

  

    //SettingsOptions.musicLength = s.source.clip.length;
    //s.source.time = s.playbackPosition; // Set the stored playback position

    public void UpdateMixerVolume()
    {
        musicEffectGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        soundEffectsGroup.audioMixer.SetFloat("Sound Effects", Mathf.Log10(AudioOptionsManager.soundEffectolume) * 20);
    }

    public void ChangeVolume(string name, float newVolume)
    {
        Sounds s = Array.Find(sounds, sound => sound.clipName == name);

        if (s == null)
        {
            Debug.LogWarning("Sound clip not found: " + name);
            return;
        }

        s.volume = Mathf.Clamp01(newVolume); // Ensure the new volume is between 0 and 1
        s.source.volume = s.volume;
    }

  
}
