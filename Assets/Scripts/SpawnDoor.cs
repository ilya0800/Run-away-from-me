using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoor : MonoBehaviour
{
    [SerializeField] Transform[] _point;
    private int _randomNumber;

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        gameObject.transform.position = new Vector3(_point[_randomNumber].position.x, _point[_randomNumber].position.y, -1f);
        StartCoroutine(CreateRandomNumber());
    }

    IEnumerator CreateRandomNumber()
    {
        yield return new WaitForSeconds(10);
        _randomNumber = Random.Range(0, _point.Length);
        StopAllCoroutines();
    }
}
