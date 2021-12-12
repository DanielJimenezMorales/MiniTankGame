using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioConsumer : MonoBehaviour
{
    private AudioSource audioSource = null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Initialize()
    {
        audioSource.playOnAwake = false;
    }

    public void PlayAudio(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
}
