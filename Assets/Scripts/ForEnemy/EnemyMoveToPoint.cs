using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMoveToPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] Way;

    [SerializeField]
    Transform Player;

    Animator _animator;

    [SerializeField] 
    OpeningTheDoor _door;

    
    private float distance;
    private int _randomNumber;
    private bool _startCoroutine;
    private bool _enemyOnMainPoint;
    

    private void Start()
    {
       _animator = GetComponent<Animator>();       
    }

    // Update is called once per frame
    private void Update()
    {
        EnemyMoveToPoints();
        RotationEnemyPoint();
    }

    private void EnemyMoveToPoints()
    {
        if (!gameObject.GetComponent<EnemyInSlime>().InSlime && !Trap.IsTrap && transformDistancePlayer() > 5 && !TimerEnemyMoveToCoffin.StartStop && !_startCoroutine)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Way[_randomNumber].transform.position, ControllerEnemy.Speed * Time.deltaTime);

            while (gameObject.transform.position.x == Way[_randomNumber].transform.position.x && gameObject.transform.position.y == Way[_randomNumber].transform.position.y)
                _randomNumber = Random.Range(0, Way.Length);

            _animator.SetBool("Active", true);
        }
    }

    private void RotationEnemyPoint()
    {
        float distance = transformDistancePlayer();
        if (distance > 4)
        {
            if(transform.position.x < Way[_randomNumber].transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, -2);
            if(transform.position.x > Way[_randomNumber].transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, -2);
        }
    }

    private float transformDistancePlayer()
    {
       float distance = Vector2.Distance(transform.position, Player.transform.position);
       return distance;
    }
}

