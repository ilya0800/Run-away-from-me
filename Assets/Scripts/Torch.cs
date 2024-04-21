using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject[] PointSpawn;
    [SerializeField]
    LayerMask LayerMask;
 
    private bool _playerPickUpTorch = false;
    public bool PlayerPickUpTorch
    {
        set { _playerPickUpTorch = value; }
        get { return _playerPickUpTorch; }      
    }
    private bool _activeTorch = true;
    private int _randomNumber; 
    Collider2D []Collider;


    private void Start()
    {
        StartSpawnTorch(ref _randomNumber);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fog"))        
            collision.gameObject.GetComponent<Animator>().SetBool("Active", true);
       
        PickUpToPlayerTorch(collision);
        CheckPositionOnTaken(ref Collider);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fog"))
            collision.gameObject.GetComponent<Animator>().SetBool("Active", true);

        CheckPositionOnTaken(ref Collider);
        PickUpToPlayerTorch(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fog"))
            collision.gameObject.GetComponent<Animator>().SetBool("Active", false);
    }

    private void PickUpToPlayerTorch(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && _activeTorch)
        {
            _playerPickUpTorch = true;
            gameObject.GetComponent<CircleCollider2D>().radius = 4;
            gameObject.transform.position = new Vector2(Player.transform.position.x - 0.5f, Player.transform.position.y + 0.5f);
            StartCoroutine(DisableTorch());
        }
    }

    IEnumerator DisableTorch()
    {
        _activeTorch = true;
        yield return new WaitForSeconds(5);
        _playerPickUpTorch = false;
        _activeTorch = false;
        Destroy(gameObject);
    }

    private void StartSpawnTorch(ref int RandomNumberForSpawn)
    {
        RandomNumberForSpawn = Random.Range(0, PointSpawn.Length);
        gameObject.transform.position = PointSpawn[RandomNumberForSpawn].transform.position;
    }

    private void CheckPositionOnTaken(ref Collider2D []collider2D)
    {
        collider2D = Physics2D.OverlapCircleAll(gameObject.transform.position, 2f, LayerMask);
    }
    
    private void NewPositionTorchIfOnTaken(Collider2D[] collider2s, int RandomNumber)
    {
        if(collider2s.Length > 1)
        {
            RandomNumber = Random.Range(0, PointSpawn.Length);
            gameObject.transform.position = PointSpawn[RandomNumber].transform.position;
        }
    }
}
