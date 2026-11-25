using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{

    public class keyrecreate : MonoBehaviour
    {
        [SerializeField] private int rayLengh = 5;
        [SerializeField] private LayerMask LayerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        public int Raylengh { get => rayLengh; set => rayLengh = value; }

        //private KeyItemController raycastdObject;
    }
}
