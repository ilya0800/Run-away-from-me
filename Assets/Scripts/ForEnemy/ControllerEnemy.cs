using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ControllerEnemy : MonoBehaviour
{

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
    

    Animator _animator;

    static public float _distanceBetweenPlayerAndEnemy;
    public static float Speed = 2.5f;
    private bool _isSlime = false;

    public Vector2 _positionForHit;
    public bool IsSlime
    {
        set { _isSlime = value; }
        get { return _isSlime; }
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
      MovePlayer();
      RotationEnemy();
      EnemyMoveToDoor();
       
    }
        
    private void MovePlayer()
    {
        if (DistanceBetweenEnemyAndPlayer() > 1f && DistanceBetweenEnemyAndPlayer() < 5 && !Trap.IsTrap && !TimerEnemyMoveToCoffin.StartStop)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, _posForHit.transform.position, Speed * Time.deltaTime);
            _animator.SetBool("Active", true);
        }
    }

    public float DistanceBetweenEnemyAndPlayer()
    {
       float _positionForHit = Vector2.Distance(gameObject.transform.position, Player.transform.position);
        return _positionForHit;
    }



    private void RotationEnemy()
    {
        if (gameObject.transform.position.x > Player.transform.position.x &&  DistanceBetweenEnemyAndPlayer() < 4)
            gameObject.transform.rotation = Quaternion.Euler(0, -180, -2);

        else if (gameObject.transform.position.x < Player.transform.position.x && DistanceBetweenEnemyAndPlayer() < 4)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -2);
    }

    private void EnemyMoveToDoor()
    {
        if(_distanceBetweenPlayerAndEnemy > 2)
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Player.transform.position, Speed * Time.deltaTime);
    }
}






