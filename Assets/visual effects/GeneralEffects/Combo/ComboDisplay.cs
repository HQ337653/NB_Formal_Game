using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMP;
    public void showNum(int num)
    {
        textMP.text = num.ToString();
    }

    public void clearNum()
    {
        textMP.text ="";
    }

    public void ChangeTextColor(Color C)
    {

    }
    public void ChangeBackGroundColor(Color C)
    {

    }

    public void shine()
    {

    }

    public void grey()
    {

    }
}
