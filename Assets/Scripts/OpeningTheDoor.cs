using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpeningTheDoor : MonoBehaviour
{
    [SerializeField]SpriteRenderer _barLoading;
    [SerializeField] GameObject _key;
    [SerializeField] Door _door;
    AudioSource audio;
    Animator animator;
    private bool _open = false;
    private bool _checkKey;
    public static bool CrossActive;
    public static bool ActiveOpenDoor; 

    //  private bool _contactPlayer;

    private void Start()
    {
       animator = GetComponent<Animator>();
       audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        if(Input.GetKey(KeyCode.E) && ChekDestroyKey() && _door.ContactPlayer && !CrossActive)
        {
            ActiveOpenDoor = true;
            if (BarLoading._timer <= 0)
            {
                animator.SetBool("IsOpen", true);
                Destroy(audio);
            }
            PlayAudio();
            _barLoading.enabled = true;
            Debug.Log("srabotai");
        }

        if (!Input.GetKey(KeyCode.E) || !_door.ContactPlayer)
        {
            _barLoading.enabled = false;
            StopAudio();
        }
    }

    private bool ChekDestroyKey()
    {
        _checkKey = _key.IsDestroyed();
        return _checkKey;
    }

    private void PlayAudio()
    {
        if (!audio.isPlaying)
            audio.Play();
    }

    private void StopAudio()
    {
        if(audio.isPlaying)
            audio.Stop();
    }

    
}
