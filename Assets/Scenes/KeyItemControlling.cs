using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class keyitemcontrolling : MonoBehaviour
    {
        [SerializeField] private bool Door = false;
        [SerializeField] private bool Rustykey = false;

        [SerializeField] private keyinventory keyinventory = null;

        private keydoorcontroller doorObject;

        private void Start()
        {
            if (Door)
            {
                doorObject = GetComponent<keydoorcontroller>();
            }

        }

        public void ObjectInteraction()
        {
            if (Door)
            {
                doorObject.PlayAnimation();
            }

            else if (Rustykey)
            {
                _keyInventory.hasRustyKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}




