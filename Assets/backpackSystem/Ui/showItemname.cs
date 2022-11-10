using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace NBGame.backpack
{
    public class showItemname : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI tmp;
        public bool distoryed = false;
        public GameObject objInScene;
       public itemType currentItem { get; private set; }
       public void setItem(itemType itemType,GameObject obj)
        {
            tmp.text = itemType.name;
            currentItem= itemType;
            objInScene= obj;

        }
    }
}