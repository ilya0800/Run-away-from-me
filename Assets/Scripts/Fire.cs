using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour, IRandomCoordinates
{
    [SerializeField] 
    private GameObject _PlayerOnFire;
    [SerializeField]
    private LayerMask _layerMask;
    private Animator animator;
    private float PosX, PosY;
    private float _sizeX = 4;
    private float _sizeY = 4;
    private float _sizeZ = -3;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        RandomCoordinates(ref PosX, ref PosY);
        SpawnFire();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
            animator.SetBool("Collision", true);    

        if(collision.gameObject.CompareTag("Player"))
            _PlayerOnFire.SetActive(true);
    }

    public void RandomCoordinates(ref float PosX, ref float PosY)
    {
        PosX = Random.Range(-9, 15);
        PosY = Random.Range(11, -5.90f);
    }

    private void SpawnFire()
    {
        if (!CheckStartSpawnOnPlayer())
        {
            gameObject.transform.position = new Vector3(PosX, PosY, -2);
            Debug.Log("dont reSpawn");
        }
        else if (CheckStartSpawnOnPlayer())
        {
            RandomCoordinates(ref PosX, ref PosY);
            gameObject.transform.position = new Vector3(PosX, PosY, -2);
        }
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    private bool CheckStartSpawnOnPlayer()
    {
        Collider2D collider2D = Physics2D.OverlapBox(gameObject.transform.position, new Vector3(_sizeX, _sizeY, _sizeZ), 0, _layerMask);
        return collider2D;
    }
}
