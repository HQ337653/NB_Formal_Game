using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.backpack
{
    public class PickUIController : MonoBehaviour
    {
        [SerializeField]
        GameObject _prefeb;
        [SerializeField]
        static GameObject prefeb;
        static GameObject thisObject;
        private void Awake()
        {
            prefeb = _prefeb;
            thisObject = gameObject;
        }
        //public static
        public static void addObjToScreen(itemType i,GameObject self)
        {
            GameObject g = Instantiate(prefeb);
            g.transform.SetParent(thisObject.transform);
            g.GetComponent<showItemname>().setItem(i,self);
        }

        public static void removeItemOnScreen(itemType i)
        {
            Debug.Log(i.name);
            foreach (Transform child in thisObject.transform)
            {
                if(child.gameObject.GetComponent<showItemname>()!=null && child.gameObject.GetComponent<showItemname>().currentItem == i&& child.gameObject.GetComponent<showItemname>().distoryed==false)
                {
                    child.gameObject.GetComponent<showItemname>().distoryed = true;
                    Debug.Log(child.gameObject.name);
                    Destroy(child.gameObject);
                    
                    return;
                }
            }
            Debug.Log("Backpack error: item type not found while trying to distory target");
        }
    }


}