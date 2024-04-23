using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverLapDarkness : MonoBehaviour
{
    Collider2D[] _playerCollider;
    [SerializeField]
    LayerMask _layerMask;
    private const float _sizeX = 4;
    private const float _sizeY = 4;
    private const float _sizeZ = -3;
   
 
    private void Update()
    {
        CheckColliderInRadiusPlayer();
    }

    private void CheckColliderInRadiusPlayer()
    {
        _playerCollider = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector3(_sizeX,_sizeY,_sizeZ), 1 ,_layerMask);
        for (int i = 0; i < _playerCollider.Length; i++)
        {
            if (_playerCollider[i] != null)
                _playerCollider[i].GetComponent<Animator>().SetBool("Active", true); 
        }
    }
}
