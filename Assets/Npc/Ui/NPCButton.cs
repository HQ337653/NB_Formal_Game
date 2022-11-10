using NBGame.dialogue;
using NBGame.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCButton : MonoBehaviour
{
    public bool distoryed;
    public dialogueData currentItem;
    public TextMeshProUGUI TMP;

    internal void showD(dialogueData i)
    {
        currentItem = i;
        TMP.text = i.Name;
    }

    public void clicked()
    {
        UiController.showDialoge(currentItem);
        GameObject.Destroy(gameObject);
    }
}
