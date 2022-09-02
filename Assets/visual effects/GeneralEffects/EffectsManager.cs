using UnityEngine;
using NBGame.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
// make some common effect in the game, all public method shoud be static 
public class EffectsManager : MonoBehaviour
{
    [SerializeField]static GameObject PopUptextPrefab;
    //for a serilaized position
    [SerializeField]  GameObject _PopUptextPrefab;
    [SerializeField] GameObject Test;
    [SerializeField] Camera MainCamera;
    static Camera _MainCamera;
    public ComboDisplay ComboText;
    private float ComboWaitTime;
    private float DefaltComboWaitTime;
    private bool comboed;
    public int comboNum
    {
        get; private set;
    }
    private void Start()
    {
        PopUptextPrefab = _PopUptextPrefab;
        comboNum = 0;
        DefaltComboWaitTime = 2;
        ComboWaitTime = DefaltComboWaitTime;
        for (int i =0; i<30; i++) {
          GameObject g=  Instantiate(PopUptextPrefab,transform);
            g.layer = 7;
            g.SetActive(false);
            floatTextList.Enqueue(g);
        }
        _MainCamera = MainCamera;
    }

    #region damagePopUp
    [SerializeField]
    private static Queue<GameObject> floatTextList = new Queue<GameObject>();
    public static void DoFloatingText(Vector3 Position, int damage, DamageTextType Type)
    {
        Debug.Log(_MainCamera.WorldToViewportPoint(Position));
            GameObject g = floatTextList.Dequeue();
            g.transform.position = Position;
            g.GetComponent<DamagePopUp>().Setup(damage);
        floatTextList.Enqueue(g);


        //floatingText.GetComponent<DamagePopUp>().Setup(damage);
    }
    public enum DamageTextType
    {
        PlayerDamage, enemyCriticalAtk, enemyDamage
    }

    #endregion

    #region combo
    IEnumerator comboWait()
    {
        comboNum +=1;
        ComboText.showNum(comboNum);
        float passedTime=0;
        while (passedTime <= ComboWaitTime)
        {
            if (comboed)
            {
                comboNum += 1;
                ComboText.showNum(comboNum);
                comboed = false;
                passedTime = 0;
            }
            passedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        comboBreak();
    }

    void comboBreak()
    {
        comboNum = 0;
        ComboText.clearNum();
    }

    public static void addCombo()
    {
        EffectsManager effectsManager = FindObjectOfType<EffectsManager>();
        if (effectsManager.comboNum==0)
        {
            effectsManager.StartCoroutine(effectsManager.comboWait());
        }
        else
        {
            effectsManager.comboed = true;
        }
    }
    #endregion

    public static void RedCubeTester(Vector3 Position)
    {

        EffectsManager effectsManager = FindObjectOfType<EffectsManager>();
        Instantiate(effectsManager.Test, new Vector3(Position.x, Position.y, Position.z), Quaternion.identity);
    }
}

