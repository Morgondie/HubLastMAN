using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool redDoor = false;
        [SerializeField] private bool redKey = false;
        [SerializeField] private bool greenDoor = false;
        [SerializeField] private bool greenKey = false;
        [SerializeField] private bool yellowDoor = false;
        [SerializeField] private bool yellowKey = false;
        [SerializeField] private bool blueDoor = false;
        [SerializeField] private bool blueKey = false;
        [SerializeField] private bool violetDoor = false;
        [SerializeField] private bool violetKey = false;
        [SerializeField] private KeyInventory keyInventory = null;

        private KeyDoorController1 doorObject1;
        private KeyDoorController2 doorObject2;
        private Green door3;
        private Yellow door4;
        private Blue door5;


        private void Start()
        {
            if (redDoor)
            {
                doorObject1 = GetComponent<KeyDoorController1>(); 
            }
           
            if (violetDoor)
            {
                doorObject2 = GetComponent<KeyDoorController2>();
            }

            if (greenDoor)
            {
                door3 = GetComponent<Green>();
            }

            if (yellowDoor)
            {
                door4 = GetComponent<Yellow>();
            }

            if (blueDoor)
            {
                door5 = GetComponent<Blue>();
            }
        }

        public void ObjectInteraction()
        {
            if (redDoor)
            {
                doorObject1.PlayAnimation();
            }

            else if (redKey)
            {
                keyInventory.hasRedKey = true;
                gameObject.SetActive(false);
            }

            if (blueDoor)
            {
                door5.PlayAnimation();
            }

            else if (blueKey)
            {
                keyInventory.hasBlueKey = true;
                gameObject.SetActive(false);
            }

            if (greenDoor)
            {
                door3.PlayAnimation();
            }

            else if (greenKey)
            {
                keyInventory.hasGreenKey = true;
                gameObject.SetActive(false);
            }

            if (yellowDoor)
            {
                door4.PlayAnimation();
            }

            else if (yellowKey)
            {
                keyInventory.hasYellowKey = true;
                gameObject.SetActive(false);
            }

            if (violetDoor)
            {
                doorObject2.PlayAnimation();
            }

            else if (violetKey)
            {
                keyInventory.hasVioletKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}

