using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPoint : MonoBehaviour
{

    [SerializeField]
    private Transform _mainPoint;
    [SerializeField]
    private GameObject _cross;
    [SerializeField]
    private CrossActive _crossActive;


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
        OpeningTheDoor.CrossActive = true;

        if (gameObject.transform.position == _mainPoint.transform.position)
        {
            OnActiveEnemyScripts();
            yield return new WaitForSeconds(5);
            OpeningTheDoor.CrossActive = false;
            gameObject.GetComponent<MainPoint>().enabled = false;
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
