using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudioManager : MonoBehaviour
{
    AudioSource source;
    public Sounds[] sounds;

    private void Start()
    {
        foreach (Sounds s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }
    }

    public void PlayAudio(string name)
    {
        Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        if(s == null)
            return;
        s.audioSource.Play();
    }
}
