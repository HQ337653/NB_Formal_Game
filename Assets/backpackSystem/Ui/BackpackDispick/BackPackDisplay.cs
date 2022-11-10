using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NBGame.backpack {
    public class BackPackDisplay : MonoBehaviour
    {
        [SerializeField]
         GameObject _prefeb;
        [SerializeField]
        TextMeshProUGUI itemInfoTitle;
        [SerializeField]
        TextMeshProUGUI itemInfoDetail;
        [SerializeField]
        Image itemInfoIcon;
        public void showBackpack()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            foreach (KeyValuePair<itemType, int> item in backpackController.PlayerBackpack)
            {
                
                GameObject g = Instantiate(_prefeb);
                g.transform.SetParent(transform);
                g.GetComponent<showItem>().show(item.Key,item.Value,this);
            }
        }

        internal void show(itemType item)
        {
            itemInfoTitle.text = item.name;
            itemInfoDetail.text = item.description;
            itemInfoIcon.sprite= item.icon;
        }
    }
}