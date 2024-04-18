using UnityEngine;
public class PotionSpawn : MonoBehaviour, IRandomCoordinates
{
    private float _posX;
    private float _posY;

    private void Start()
    {
       RandomCoordinates(ref _posX, ref _posY);
       Spawn();
    }

    public void RandomCoordinates(ref float PosX,ref float Posy)
    {
        PosX = Random.Range(-10, 16);
        Posy = Random.Range(12, -6.90f);
    }

    private void Spawn()
    {
        gameObject.transform.position = new Vector3(_posX, _posY, 0);
    }
}

