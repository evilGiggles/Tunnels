using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KeySystem
{

    public class keyRaycreate : MonoBehaviour
    {
        [SerializeField] private int rayLengh = 5;
        [SerializeField] private LayerMask LayerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        public int Raylengh { get => rayLengh; set => rayLengh = value; }

        private keyitemcontrolling raycastedObject;
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        [SerializeField] private Image Crosshair = null;
        private bool isCrosshairActive;
        private bool doOnce;

        private string interactableTag = "InteractiveObject";

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | LayerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLengh, mask))
            {
                if (!doOnce)
                {
                    raycastedObject = hit.collider.gameObject.GetComponent<keyitemcontrolling>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {

                    raycastedObject.ObjectInteraction();
                }

                else;

                {
                    if (isCrosshairActive)
                    {
                        CrosshairChange(false);
                        doOnce = false;
                    }
                }
            }

            void CrosshairChange(bool on)
            {
                if (doOnce && !doOnce)
                {
                    Crosshair.color = Color.red;
                }
                else;
                {
                    Crosshair.color = Color.white;
                    isCrosshairActive = false;
                }
            }

        }
    }
}



