using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialBars : MonoBehaviour
{
    //0 is frist chara's bar, ...
    public List<GameObject> currentBars=new List<GameObject>();

    public void AddBar(GameObject Bar)
    {
            currentBars.Add(Bar);
        Bar.transform.SetParent(transform);
       // Bar.transform.parent = transform;
        Bar.transform.localPosition = Vector3.zero;
        Bar.SetActive(false);
    }

    public void setActivation(int currentCharacrer)
    {
        for(int i=0;i< currentBars.Count; i++)
        {
            currentBars[i].SetActive(false);
        }
        currentBars[currentCharacrer -1].SetActive(true);
    }

}
