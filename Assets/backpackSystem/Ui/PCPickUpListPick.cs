using NBGame.backpack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PCPickUpListPick : MonoBehaviour
{
    protected PlayerInput inputActions;
    private void Start()
    {
        inputActions = new PlayerInput();
        inputActions.Enable();
        inputActions.Universal.pick.performed += ctx => { pick(); };
    }
    void pick()
    {
        foreach (Transform child in transform)
        {
 
            if (child.gameObject.GetComponent<showItemname>() != null)
            {
                backpackController.addToBackPack(child.gameObject.GetComponent<showItemname>().currentItem);
                Destroy(child.gameObject.GetComponent<showItemname>().objInScene);
                Destroy(child.gameObject);
                
            }
        }
    }
}
