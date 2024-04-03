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
        PosX = Random.Range(0, 10);
        Posy = Random.Range(0, 10);
    }

    private void Spawn()
    {
        gameObject.transform.position = new Vector3(_posX, _posY, 0);
    }
}

