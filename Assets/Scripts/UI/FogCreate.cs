using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.XR;

public class FogCreate : MonoBehaviour
{
    private float _randomX;
    private float _randomY;
    [SerializeField]
    GameObject []Fog;
    public static Collider2D colliders;
    [SerializeField]
    LayerMask layerMask;
    private bool FogBusyPos;
    private bool leaver = true;
    private Vector3 NewPosFog;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        FogPos();
        FogBusyPos = Physics2D.OverlapCircle(Fog[2].transform.position, 0.3f);
    }

    private void FogPos()
    {
        if (leaver)
        {  
            for (int i = 0; i < Fog.Length; i++)
            {
              
                _randomX = Random.Range(-7.91f, 7.04f);
                _randomY = Random.Range(4.95f, -4.95f);
                NewPosFog = new Vector3(_randomX, _randomY, -1);
                Fog[i].transform.position = NewPosFog;
                leaver = false;
             
            }
        }
    }
}



