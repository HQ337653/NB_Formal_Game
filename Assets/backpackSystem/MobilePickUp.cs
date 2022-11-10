using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

namespace NBGame.backpack
{
    public class MobilePickUp : MonoBehaviour
    {
        [SerializeField]
        showItemname showItemname;
       public void pick()
        {
            backpackController.addToBackPack(showItemname.currentItem);
            Destroy(showItemname.objInScene);
            Destroy(gameObject);
        }
    }
}