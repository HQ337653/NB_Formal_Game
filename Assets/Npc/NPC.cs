using NBGame.backpack;
using NBGame.Player;
using NBGame.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Xml;
using UnityEngine;
namespace NBGame.dialogue
{
    public class NPC : MonoBehaviour
    {
        public TextAsset dialoguedataJson;
        bool allowed=true;
        dialogueData dialoguedata;
        [SerializeField]
        BoxCollider c;
        private void Awake()
        {
            dialoguedata= JsonUtility.FromJson<dialogueData>(dialoguedataJson.text);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<CharaModeSwitcher>() != null&&allowed)
            {
                // UiController.showDialoge(dialoguedata);
                NPCButtonList.addObjToScreen(dialoguedata);
                 allowed = false;
            }

        }

        private void OnTriggerExit(Collider other)
        {
            NPCButtonList.removeItemOnScreen(dialoguedata);
            allowed = true;
        }
        void refreshList()
        {
            NPCButtonList.removeItemOnScreen(dialoguedata);
            Collider[] colliders = Physics.OverlapBox(c.center, new Vector3(c.size.x / 2, c.size.y / 2, c.size.z / 2));
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.GetComponent<CharaModeSwitcher>() != null)
                {
                    NPCButtonList.addObjToScreen(dialoguedata);

                }
            }
        }
    }
}