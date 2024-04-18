using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeOnPlayer : MonoBehaviour
{
    [SerializeField] ControllerPlayer _controllerPlayer;
    [SerializeField] AudioSource []_audioSource;
    private bool _onMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            _controllerPlayer.ActionPlayer.Invoke(ref _onMove);
            _controllerPlayer.Speed = 0.5f;
            for (int i = 0; i < _audioSource.Length; i++)
            {
                if (!_audioSource[i].isPlaying)
                    _audioSource[i].Play();
                else if (!_onMove)
                    _audioSource[i].Stop();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            _controllerPlayer.ActionPlayer.Invoke(ref _onMove);
            _controllerPlayer.Speed = 0.5f;
            for (int i = 0; i < _audioSource.Length; i++)
            {
                if (!_audioSource[i].isPlaying)
                    _audioSource[i].Play();
                else if (!_onMove)
                    _audioSource[i].Stop();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            _controllerPlayer.Speed = 2;
            for(int i = 0; i < _audioSource.Length; i++)
            _audioSource[i].Stop();
        }
    }
}
