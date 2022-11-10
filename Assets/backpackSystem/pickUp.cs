using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.Player;
namespace NBGame.backpack
{
    //script to be put into the object in scene
    public class pickUp : MonoBehaviour
    {
        [SerializeField]
        BoxCollider c;
        float Z2d= 23.1f;
        float Z3d= 1.4f;
        [SerializeField]
        SpriteRenderer sp;
        [SerializeField]
        PickableItems.itemsName name;
        private void Awake()
        {
            GameModeController.ModeChangediFTo2D += changeToIf2d;
           
        }
        private void Start()
        {
            GameModeController.CharacterChangedIfToActive += refreshList;
           sp.sprite = PickableItems.ItemByName[name].icon;
        }

        private void OnDestroy()
        {
            GameModeController.ModeChangediFTo2D -= changeToIf2d;
        }
        void changeToIf2d(bool twoD)
        {
            if (twoD)
            {
                c.size = new Vector3(7, 4.42f, Z2d);
            }
            else
            {
                c.size = new Vector3(7, 4.42f, Z3d);
            }
        }

        void refreshList(bool changeToActive)
        {
            if (!changeToActive)
            {
                PickUIController.removeItemOnScreen(PickableItems.ItemByName[name]);
            }
            else
            {
                Collider[] colliders = Physics.OverlapBox(c.center, new Vector3(c.size.x / 2, c.size.y / 2, c.size.z / 2));
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject.GetComponent<CharaModeSwitcher>() != null)
                    {
                        PickUIController.addObjToScreen(PickableItems.ItemByName[name], gameObject);
                    }
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<CharaModeSwitcher>() != null)
            {

                //PickUIController.addObjToScreen(backpackController.ItemByName[name],gameObject);
                PickUIController.addObjToScreen(PickableItems.ItemByName[name], gameObject);
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<CharaModeSwitcher>() != null)
            {
                    PickUIController.removeItemOnScreen(PickableItems.ItemByName[name]);

            }

        }
    }
}