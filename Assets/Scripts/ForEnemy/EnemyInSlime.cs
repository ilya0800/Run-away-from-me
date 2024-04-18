using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInSlime : MonoBehaviour
{
    

    [Header("Slime")]
    [SerializeField] Slime[] _slimeScript;

    [SerializeField]
    Trap _trap;

    public delegate void SlimeDelegate();
    public event SlimeDelegate Slime;
    public bool InSlime { get; private set; }



    private void Start()
    {
        Slime += EnemyGoSlime;
    }

    public void Update()
    {
        EnemyGoSlime();
    }

    public IEnumerator NextSlimeGo()
    {
        InSlime = true;
        yield return new WaitForSeconds(3);
        for (int i = 0; i < _slimeScript.Length; i++)
            _slimeScript[i].PlayerOnSlime = false;
        InSlime = false;
        StopAllCoroutines();

    }

    public void EnemyGoSlime()
    {
        for (int i = 0; i < _slimeScript.Length; i++)
        {
            if (_slimeScript[i].PlayerOnSlime && !_trap.IsTrapped)
            {
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _slimeScript[i].transform.position, 2f * Time.deltaTime);
                StartCoroutine(NextSlimeGo());
            }
        }
    }

}
