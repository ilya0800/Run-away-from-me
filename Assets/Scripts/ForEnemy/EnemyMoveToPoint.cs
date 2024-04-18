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
    Trap _trap;
    [SerializeField]
    Transform Player;
    [SerializeField] 
    OpeningTheDoor _door;
  

    private Animator _animator;
    private int _randomNumber;
    private ControllerEnemy _controllerEnemy;
    private EnemyInSlime _enemyInSlime;
    

    private void Start()
    {
       _animator = GetComponent<Animator>();      
       _controllerEnemy = GetComponent<ControllerEnemy>();
       _enemyInSlime = GetComponent<EnemyInSlime>();
    }

    private void Update()
    {
        EnemyMoveToPoints();
        RotationEnemyPoint();
    }

    private void EnemyMoveToPoints()
    {
        if (!_enemyInSlime.InSlime && !_trap.IsTrapped && transformDistancePlayer() > 5 && !TimerEnemyMoveToCoffin.StartStop  && !_controllerEnemy.EnemyGoToDoor)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Way[_randomNumber].transform.position, _controllerEnemy.Speed * Time.deltaTime);

            while (gameObject.transform.position.x == Way[_randomNumber].transform.position.x && gameObject.transform.position.y == Way[_randomNumber].transform.position.y)
                _randomNumber = Random.Range(0, Way.Length);
            _animator.SetBool("ActiveMove", true);
        }
    }

    private void RotationEnemyPoint()
    {
        if (transformDistancePlayer() > 4)
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

