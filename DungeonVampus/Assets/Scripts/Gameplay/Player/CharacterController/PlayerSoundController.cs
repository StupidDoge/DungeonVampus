using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _hitSound;

    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMoveSound()
    {
        if (!_audio.isPlaying)
        {
            _audio.volume = Random.Range(0.9f, 1f);
            _audio.pitch = Random.Range(0.8f, 1.1f);
            _audio.Play();
        }
    }

    public void PlayHitSound()
    {
        _audio.pitch = Random.Range(0.9f, 1.1f);
        _audio.PlayOneShot(_hitSound);
    }
}
