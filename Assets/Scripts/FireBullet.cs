using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _timer = 2f;
    
    
    private int _counter;

    [SerializeField]
    private int _maxCounter = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireB());

    }

    IEnumerator FireB()
    {
        Debug.Log("Inicio coroutine");
        for (int i = 0; i < _maxCounter; i++) 
        {
            _counter++;
            Instantiate(_bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(_timer);

        }

        Debug.Log("fin coroutine");
    }
}
