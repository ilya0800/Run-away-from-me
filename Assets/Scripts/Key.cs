using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IRandomCoordinates
{
    [SerializeField]
    GameObject KeyImage;
    [SerializeField]
    GameObject Door;
 
    private float _posX;
    private float _posY;

    private void Start()
    {
        SpawnKey();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            KeyImage.SetActive(true);
            //Door.GetComponent<Door>().СheckKey = true;
        }
    }

   public void RandomCoordinates(ref float PosX, ref float PosY)
   {
        PosX = Random.Range(-12,9);
        PosY = Random.Range(-6, 9);
   }

   private void SpawnKey()
   {
        RandomCoordinates(ref _posX, ref _posY);
        gameObject.transform.position = new Vector2(_posX, _posY);
   }

}
