using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Gun : MonoBehaviour
{
    public float _damage = 10f;
    public float _range = 10f;
    public GameObject _impacteffect;
    public MoveCamera _fpscam;
    
    public int maxammo = 60;
    public int currentammo;

    public TMP_Text ammoDisplay;

    public float _impactforce = 20f;
    public float _fireRate = 15f;
    public float _nextTimeToFire = 0f;


    private void Start()
    {
        currentammo = maxammo;
    }
    void Update()
    {
        ammoDisplay.text = currentammo.ToString();

        if (Input.GetMouseButton(0) && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;

            Shoot();

        } 

        if (currentammo <= 0)
        {
            return;
        }

    }
    void Shoot()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(_fpscam.transform.position, _fpscam.transform.forward, out hit, _range))
        {
            Debug.Log(hit.transform.name);

            Enemigo target = hit.transform.GetComponent<Enemigo>();
            if (target != null)
            {
                target.takedamage(_damage);
            }

            if (hit.rigidbody!= null)
            {
                hit.rigidbody.AddForce(-hit.normal * _impactforce);
            }

            Instantiate(_impacteffect, hit.point, Quaternion.LookRotation(hit.normal));

            currentammo--;
        }

    }
}
