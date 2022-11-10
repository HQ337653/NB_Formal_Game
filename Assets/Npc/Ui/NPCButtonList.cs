
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.dialogue
{
    public class NPCButtonList : MonoBehaviour
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
        public static void addObjToScreen(dialogueData i)
        {
            GameObject g = Instantiate(prefeb);
            g.transform.SetParent(thisObject.transform);
            g.GetComponent<NPCButton>().showD(i);
        }
       public static void removeItemOnScreen(dialogueData i)
        {
            //Debug.Log(i.name);
            foreach (Transform child in thisObject.transform)
            {
                if (child.gameObject.GetComponent<NPCButton>() != null && child.gameObject.GetComponent<NPCButton>().currentItem == i && child.gameObject.GetComponent<NPCButton>().distoryed == false)
                {
                    child.gameObject.GetComponent<NPCButton>().distoryed = true;
                    Debug.Log(child.gameObject.name);
                    Destroy(child.gameObject);

                    return;
                }
            }
            Debug.Log("DialogueError: item type not found while trying to distory target");
        }
    }
}