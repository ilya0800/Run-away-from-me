using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour, IRandomCoordinates
{
    [SerializeField] 
    GameObject PlayerOnFire;
    private Animator animator;
    private float PosX, PosY;

    void Start()
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
            PlayerOnFire.SetActive(true);
    }

    public void RandomCoordinates(ref float PosX, ref float PosY)
    {
        PosX = Random.Range(-9, 15);
        PosY = Random.Range(11, -5.90f);
    }

    private void SpawnFire()
    {
        gameObject.transform.position = new Vector3(PosX, PosY, -2);
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
