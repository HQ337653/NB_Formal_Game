using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using static backpackController;

namespace NBGame.backpack
{
    public class showItem : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI number;
        [SerializeField]
        Image icon;
        itemType item;
        BackPackDisplay Display;
      public void show(itemType itemType, int amount, BackPackDisplay backPackDisplay)
        {
            icon.sprite=itemType.icon;
            number.text=amount.ToString();
            Display=backPackDisplay;
            item = itemType;
        }

        public void pressed()
        {
            Display.show(item);
        }

    }
}