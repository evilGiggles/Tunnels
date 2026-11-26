using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace KeySystem
{

    public class keydoorcontroller : MonoBehaviour
    {
        private Animator doorAnim;
        private bool doorOpen = false;

        [Header("Animation Names")]
        [SerializeField] private string openAnimationName = "doorOpen";
        [SerializeField] private string closeAnimationName = "doorClose";

        [SerializeField] private int timeToShowUI = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private keyinventory _keyinventory = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnim = gameObject.GetComponent<Animator>();
            pauseInteraction = false;
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (_keyinventory.hasRustyKey)
            {
                if (!doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(openAnimationName, 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }

                else if (doorOpen && !pauseInteraction)
                {
                    doorAnim.Play(closeAnimationName, 0, 0.0f);
                    doorOpen = false;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
            
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(timeToShowUI);
            showDoorLockedUI.SetActive(false);

        }
    }
}