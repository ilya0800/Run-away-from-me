using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    RaycastHit2D []hit;
    RaycastHit2D[] _hitUp;
    RaycastHit2D [] _hitDown;
    [SerializeField]
    LayerMask mask;
    public float distanceHitUp = 1.5f;
    public float distanceHitDown = 1.3f;
    public float distanceHitRight = 1.5f;

    void Update()
    {
        HitFog(hit, _hitUp, _hitDown);
    }

    private void HitFog(RaycastHit2D[] hit2Ds, RaycastHit2D[] hitUp, RaycastHit2D[] hitDown)
    {
        hitUp = Physics2D.RaycastAll(gameObject.transform.position, gameObject.transform.up, distanceHitUp, mask);
        hit2Ds = Physics2D.RaycastAll(gameObject.transform.position, gameObject.transform.right, distanceHitRight, mask);
        hitDown = Physics2D.RaycastAll(gameObject.transform.position, gameObject.transform.up * 1, distanceHitDown, mask);
        
        for (int i = 0; i < hit2Ds.Length; i++) {
            if (hit2Ds[i].collider != null)
            {
                hit2Ds[i].collider.gameObject.GetComponent<Animator>().SetBool("Active", true);
                StartCoroutine(OnDarknessRightRay());
            }
            IEnumerator OnDarknessRightRay()
            {
                yield return new WaitForSeconds(5);
                hit2Ds[i].collider.gameObject.GetComponent<Animator>().SetBool("Active", false);
            }
        }

        for (int j = 0;j < hitUp.Length; j++)
        {
            if (hitUp[j].collider != null)
            {
                hitUp[j].collider.gameObject.GetComponent<Animator>().SetBool("Active", true);
                StartCoroutine(OnDarknessUpRay());
            }
            IEnumerator OnDarknessUpRay()
            {
                yield return new WaitForSeconds(5);
                Debug.Log("rabotaet");
                hitUp[j].collider.gameObject.GetComponent<Animator>().SetBool("Active", false);
            }
        }

        for (int i = 0; i < hitDown.Length; i++)
        {
            if (hitDown[i].collider != null)
            {
                hitDown[i].collider.gameObject.GetComponent<Animator>().SetBool("Active", true);
                OnDarknessDownRay();
            }
            IEnumerator OnDarknessDownRay()
            {
                yield return new WaitForSeconds(5);
                hitDown[i].collider.gameObject.GetComponent<Animator>().SetBool("Active", false);
            }
        }
    }

  
}
