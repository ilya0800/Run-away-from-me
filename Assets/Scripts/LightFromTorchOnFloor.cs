using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightFromTorchOnFloor : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;
    [SerializeField]
    Torch torch;

    private void Start()
    {
        torch = GetComponent<Torch>();
    }

    private void Update()
    {
       Debug.Log(torch.PlayerPickUpTorch);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor") && torch.PlayerPickUpTorch)
            tilemap.color = new Color(255, 255, 255);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor") && torch.PlayerPickUpTorch)
            tilemap.color = new Color(255, 255, 255);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor") && !torch.PlayerPickUpTorch)
            tilemap.color = new Color32(150, 150, 150, 255);
    }
}
