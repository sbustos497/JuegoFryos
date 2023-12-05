using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCon : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip audioClip)
    {
        if (audioSource.isPlaying)
        {
            //eliminar los otros audios que estan sonando
            audioSource.Stop();
            
        }

        audioSource.clip = audioClip;
        audioSource.Play();
    }

    // END: abpxx6d04wxr
    // BEGIN: be15d9bcejpp
}
