using KeySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    private Animation doorAnim;
    private bool doorOpen = false;

    [Header("Animation names")]
    [SerializeField] private string openAnimationName = "open";
    [SerializeField] private string closeAnimationName = "close";

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;
    [SerializeField] private KeyInventory keyInventory = null;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animation>();
    }

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);

        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if (keyInventory.hasYellowKey)
        {
            if (!doorOpen && !pauseInteraction)
            {
                doorAnim.PlayQueued(openAnimationName, 0, 0.0f);
                doorOpen = true;
                StartCoroutine(PauseDoorInteraction());
            }

            else if (doorOpen && !pauseInteraction)
            {
                doorAnim.PlayQueued(closeAnimationName, 0, 0.0f);
                doorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }

        else
        {
            StartCoroutine(ShowDoorLocked());
        }
    }

    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }
}
