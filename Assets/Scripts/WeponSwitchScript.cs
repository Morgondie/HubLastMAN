
using UnityEngine;

public class WeponSwitchScript : MonoBehaviour
{

    public int _selectWepon = 0;

    void Start()
    {

    }


    void Update()
    {

        int previousWepon = _selectWepon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_selectWepon >= transform.childCount - 1)
            {
                _selectWepon = 0;
            }
            else
            {
                _selectWepon++;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_selectWepon <= 0)
            {
                _selectWepon = transform.childCount - 1;
            }
            else
            {
                _selectWepon--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectWepon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount >= 2)
        {
            _selectWepon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            _selectWepon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            _selectWepon = 3;
        }
        if (previousWepon != _selectWepon)
        {
            SelectWepon();
        }
    }

        void SelectWepon()
        {
            int i = 0;
            foreach (Transform wepon in transform)
            {
                if (i == _selectWepon)
                {
                    wepon.gameObject.SetActive(true);
                }
                else
                {
                    wepon.gameObject.SetActive(false);
                }
                i++;
            }
        }
    
}
