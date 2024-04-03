using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(VisibleDarknessFalse());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Active", true);
        }
    }


    IEnumerator VisibleDarknessFalse()
    {
        if (animator.GetBool("Active") == true)
        {
            yield return new WaitForSeconds(10);
            animator.SetBool("Active", false);
            StopAllCoroutines();
        }
    }
}
