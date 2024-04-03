using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private bool _playerOnSlime;
    AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public bool PlayerOnSlime
    {
        set { _playerOnSlime = value; }
        get { return _playerOnSlime; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOnSlime = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(!_audio.isPlaying)
                _audio.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOnSlime = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!_audio.isPlaying)
                _audio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerOnSlime = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (_audio.isPlaying)
                _audio.Stop();
        }
    }
}
