using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IRandomCoordinates
{
    private Animator animator;
    private float PosX, PosY;
    void Start()
    {
        animator = GetComponent<Animator>();
        RandomCoordinates(ref PosX, ref PosY );
        SpawnBox();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
            animator.SetBool("BoxOnFire", true);
    }

    public void RandomCoordinates(ref float PosX, ref float PosY)
    {
        PosX = Random.Range(-9, 15);
        PosY = Random.Range(11, -5.90f);
    }

    private void SpawnBox()
    {
        gameObject.transform.position = new Vector3(PosX, PosY, -2);
    }
}
