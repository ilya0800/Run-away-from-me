using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float _leftBounds;
    [SerializeField]
    private float _rightBounds;
    [SerializeField]
    private float _topBounds;
    [SerializeField]
    private float _bottomBounds;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BoundsCamera();

    }

    private void BoundsCamera()
    {
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, _leftBounds, _rightBounds),
            Mathf.Clamp(transform.position.y, _bottomBounds, _topBounds), 
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(_leftBounds, _bottomBounds),new Vector2(_rightBounds, _bottomBounds)); 
        Gizmos.DrawLine(new Vector2(_leftBounds, _topBounds), new Vector2(_rightBounds, _topBounds));
        Gizmos.DrawLine(new Vector2(_leftBounds, _bottomBounds), new Vector2(_leftBounds, _topBounds));
        Gizmos.DrawLine(new Vector2(_rightBounds, _bottomBounds), new Vector2(_rightBounds, _topBounds));

    }
}
