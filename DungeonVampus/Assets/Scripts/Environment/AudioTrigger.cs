using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private float _timeDelay;

    private bool _alreadyPlayed = false;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_alreadyPlayed)
        {
            StartCoroutine(PlayWithDelay(_timeDelay));
        }
    }

    IEnumerator PlayWithDelay(float delay)
    {
        _alreadyPlayed = true;
        yield return new WaitForSeconds(delay);
        _audioSource.Play();
    }
}
