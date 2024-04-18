using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObj : MonoBehaviour
{
    [SerializeField]
    ControllerPlayer _playerScript;
    [SerializeField]
    GameObject _cameraStart;
    [SerializeField]
    GameObject _cameraPlayer;
    [SerializeField]
    GameObject TimeLineStart;
   
    private float _timer = 0;
    private bool _enabled = true;

    // Update is called once per frame
    void Update()
    {
        Timer();
        DisableMovePlayer();
    }

    private float Timer()
    {
        _timer += Time.deltaTime;
        return _timer;
    }

    private void DisableMovePlayer()
    {
        if (Input.anyKeyDown)
        {
            _enabled = false;
            Destroy(TimeLineStart);
            Destroy(_cameraStart);
            _playerScript.enabled = true;
            _cameraPlayer.SetActive(true);
        }
        else if(_timer > 7)
            _playerScript.enabled=true;
        else if  (_timer < 7 && _enabled)
            _playerScript.enabled = false; 
    }
}
