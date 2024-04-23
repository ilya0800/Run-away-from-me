using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IRandomCoordinates
{
    [SerializeField]
    private Animator _animatorEnemy;
    [SerializeField]
    private LayerMask _layerMask;
    private Animator _animator;
    private float _posX;
    private float _posY;
    private AudioSource _audioSource;
    private bool _isTrap;
    private float _sizeCubeX = 4;
    private float _sizeCubeY = 4;
    private float _sizeCubeZ = 4;
    public bool IsTrapped
    {
        get { return _isTrap; }
        set { _isTrap = value; }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        RandomCoordinates(ref _posX,ref _posY);
        SpawnTrap();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("Active", true);
            StartCoroutine(FreezPositionPlayer(collision));
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            _animatorEnemy.SetBool("Idle", true);
            _animatorEnemy.SetBool("ActiveMove", false);
            _animator.SetBool("Active", true);
            StartCoroutine (FreezPositionEnemy(collision));
        }
    }

    IEnumerator FreezPositionPlayer(Collider2D collider2D)
    {
        yield return new WaitForSeconds(0.2f);  
        collider2D.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
       
        if (!_audioSource.isPlaying)
            _audioSource.Play();

    }

    IEnumerator FreezPositionEnemy(Collider2D collider2D)
    {
        yield return new WaitForSeconds(0.5f);
        collider2D.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        collider2D.gameObject.GetComponent<ControllerEnemy>().enabled = false;
        collider2D.gameObject.GetComponent<EnemyMoveToPoint>().enabled = false;
    
        if (!_audioSource.isPlaying)
            _audioSource.Play();
        _isTrap = true;

        yield return new WaitForSeconds(3);
        _animatorEnemy.SetBool("Idle", false);
        _animatorEnemy.SetBool("ActiveMove", true);
        _isTrap = false;
        collider2D.gameObject.GetComponent<ControllerEnemy>().enabled = true;
        collider2D.gameObject.GetComponent<EnemyMoveToPoint>().enabled = true;

    }

    public void RandomCoordinates(ref float PosX, ref float PosY)
    {
        PosX = Random.Range(-10, 16);
        PosY = Random.Range(12, -6.90f);
    }

    private void SpawnTrap()
    {
        if (!CheckSpawnTrapOnPlayer())
            gameObject.transform.position = new Vector2(_posX, _posY);
        else if (CheckSpawnTrapOnPlayer())
        {
            RandomCoordinates(ref _posX, ref _posY);
            gameObject.transform.position = new Vector2(_posX, _posY);
        }
    }

    private bool CheckSpawnTrapOnPlayer()
    {
        Collider2D collider2D = Physics2D.OverlapBox(gameObject.transform.position, new Vector3(_sizeCubeX, _sizeCubeY,_sizeCubeZ), 0, _layerMask);
        return collider2D;
    }
}
