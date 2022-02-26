using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _moveSound;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private AudioClip _takeDamageSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _fireballCastSound;

    private AudioSource _audioSource;

    public AudioClip MoveSound => _moveSound;
    public AudioClip AttackSound => _attackSound;
    public AudioClip TakeDamageSound => _takeDamageSound;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }
    public void PlayMoveSound()
    {
        if (!PauseMenu.gameIsPaused && !_audioSource.isPlaying && _audioSource != null)
            _audioSource.PlayOneShot(_moveSound);
    }

    public void PlayTakeDamageSound()
    {
        _audioSource.PlayOneShot(_takeDamageSound);
    }

    public void PlayAttackSound()
    {
        _audioSource.PlayOneShot(_attackSound);
    }

    public void PlayHitSound()
    {
        _audioSource.PlayOneShot(_hitSound);
    }

    public void PlayFireballCastSound()
    {
        _audioSource.PlayOneShot(_fireballCastSound);
    }
}
