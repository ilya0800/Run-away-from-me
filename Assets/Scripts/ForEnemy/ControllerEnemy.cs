using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerEnemy : MonoBehaviour
{
    #region [SerializeField]
    [SerializeField]
    GameObject Player;
    [SerializeField] 
    GameObject _posForHit;
    [SerializeField]
    LayerMask layerMask;
    [SerializeField] 
    OpeningTheDoor _door;
    [SerializeField] 
    GameObject _slime;
    [SerializeField] 
    AudioSource _source;
    [SerializeField]
    AudioSource _attack;
    [SerializeField]
     Trap _trap;
    #endregion
    #region Public Reference

    public float Speed 
    { 
        set { _speed = value;} 
        get { return _speed;} 
    }

    public bool IsSlime
    {
        set { _isSlime = value; }
        get { return _isSlime; }
    }

    public bool EnemyGoToDoor
    {
        set { _enemyGoToDoor = value; }
        get { return _enemyGoToDoor; }
    }
    #endregion
    private Animator _animator;
    private float _speed = 2.5f;
    private bool _isSlime = false;
    private bool _enemyGoToDoor = false;
    private Vector2 _positionForHit;
    

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        RotationEnemy();
        EnemyMoveToDoor();
    }

    private void FixedUpdate()
    {
        MovePlayer();

    }

    private void MovePlayer()
    {
        if (DistanceBetweenEnemyAndPlayer() > 1f && DistanceBetweenEnemyAndPlayer() < 5 && !_trap.IsTrapped && !TimerEnemyMoveToCoffin.StartStop)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _posForHit.transform.position, _speed * Time.deltaTime);
            _animator.SetBool("ActiveMove", true);
        }
    }

    public float DistanceBetweenEnemyAndPlayer()
    {
       float _positionForHit = Vector2.Distance(gameObject.transform.position, Player.transform.position);
        return _positionForHit;
    }



    private void RotationEnemy()
    {
        if (gameObject.transform.position.x > Player.transform.position.x && DistanceBetweenEnemyAndPlayer() < 4)
            gameObject.transform.rotation = Quaternion.Euler(0, -180, -2);

        else if (gameObject.transform.position.x < Player.transform.position.x && DistanceBetweenEnemyAndPlayer() < 4)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -2);
    }

    private void EnemyMoveToDoor()
    {
        if (OpeningTheDoor.ActiveOpenDoor)
            StartCoroutine(GoToDoorEnemy());    
    }

    IEnumerator GoToDoorEnemy()
    {
        _enemyGoToDoor = true;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Player.transform.position, _speed * Time.deltaTime);
        yield return new WaitForSeconds(5);
        _enemyGoToDoor = false;
        OpeningTheDoor.ActiveOpenDoor = false;
    }
}






