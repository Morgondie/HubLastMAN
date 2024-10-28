using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Municion : MonoBehaviour
{
    Gun currentammo;
    Gun maxammo;
    public int plusammo = 30;
    public TMP_Text _ammoDisplay;

    private void Start()
    {
        currentammo = GameObject.FindWithTag("Gun").GetComponent<Gun>();
    }

    private void Update()
    {
        //_ammoDisplay.text = currentammo.ToString();//
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentammo.currentammo += plusammo;

            Destroy(gameObject);
        }
    }
}
