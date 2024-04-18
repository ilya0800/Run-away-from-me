using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioLauhter;

    public static bool DeadPlayer = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DeadPlayer = true;
            PlayAudio();
        }

    }

    private void PlayAudio()
    {
        _audioLauhter.Play();
    }
}
