using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPoint : MonoBehaviour
{

    [SerializeField]
    Transform _mainPoint;
    [SerializeField]
    GameObject _cross;
    [SerializeField]
    CrossActive _crossActive;


    void Update()
    {
        MainPointActive();
    }

    private void MainPointActive()
    {        
        if (_crossActive.ActiveCross())
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
            
            yield return new WaitForSeconds(5);
            
            CoffinController.OpenCoffin();
            gameObject.GetComponent<MainPoint>().enabled = false;
            //StopAllCoroutines();
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
