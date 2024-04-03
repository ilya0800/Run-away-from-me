using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPoint : MonoBehaviour
{

    [SerializeField]
    Transform _mainPoint;

    private bool _OnesUse = true;
    private bool _startCoroutine;

    void Update()
    {
        MainPointActive();
    }

    private void MainPointActive()
    {        
        if (CrossActive.ActiveCross())
            StartCoroutine(MoveToMainPoint());
    }

    IEnumerator MoveToMainPoint()
    {
        OnDisableEnemyScripts();
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _mainPoint.transform.position, 3 * Time.deltaTime);
        if (gameObject.transform.position == _mainPoint.transform.position)
        {
            OnActiveEnemyScripts();
            CoffinController.CloseCoffin();
            _OnesUse = false;
            
            yield return new WaitForSeconds(5);
            
            CoffinController.OpenCoffin();
            _startCoroutine = false;
            StopAllCoroutines();
        }
    }

    private void OnDisableEnemyScripts()
    {
        gameObject.GetComponent<EnemyMoveToPoint>().enabled = false;
        gameObject.GetComponent<ControllerEnemy>().enabled = false;
    }

    private void OnActiveEnemyScripts()
    {
        gameObject.GetComponent<EnemyMoveToPoint>().enabled = true;
        gameObject.GetComponent<ControllerEnemy>().enabled = true;
    }
}
