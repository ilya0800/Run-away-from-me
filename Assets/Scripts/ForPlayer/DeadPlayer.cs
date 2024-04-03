using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    ParticleSystem _partical;

    private void Start()
    {
        _partical = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.CompareTag("HitEnemy"))
        {
            GetComponent<Animator>().SetBool("Dead", true);
            if (!_partical.isPlaying)          
                _partical.Play();
            
        }

    }
}
