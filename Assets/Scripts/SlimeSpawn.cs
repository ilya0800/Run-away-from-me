using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour, IRandomCoordinates
{
    [SerializeField] GameObject []_slimeObj;
    private float _posX;
    private float _posY;

    private void Start()
    {
        RandomSpawn();
    }

    private void RandomSpawn()
    {
        for (int i = 0; i < _slimeObj.Length; i++) {
            RandomCoordinates(ref  _posX,ref _posY);
            _slimeObj[i].transform.position = new Vector3(_posX, _posY, 1f);
        }
    }

    public void RandomCoordinates(ref float x, ref float y)
    {
        x = Random.Range(-12, 9);
        y = Random.Range(-6, 9);
    }
}