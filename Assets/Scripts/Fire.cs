using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    [SerializeField] 
    GameObject PlayerOnFire;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            animator.SetBool("Collision", true);
        }

        if(collision.gameObject.CompareTag("Player"))
            PlayerOnFire.SetActive(true);
    }


}
