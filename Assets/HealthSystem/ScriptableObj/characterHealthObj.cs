using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "HpObj/characterHealthObj")]
public class characterHealthObj : ScriptableObject
{
    public int CurrentHP;
    public int MaxHp;
    //ÈÍÐÔ
    public int maxPoiseHealth;
    public int poiseHealth;

    public int atk;
    public int def;
    public int MoveSpeedRate;
    //±©»÷
    public int CritRate;
     public int CritDamage;
    //ÀäÈ´±¶ÂÊ
    public int QCoolDownRate = 100;
    public int ECoolDownRate = 100;
    //³äÄÜ
    public int RechargeRate = 100;
    public int currentEnergy;
    public int MaxEnergy;

    public float specialVal;
    public float currentSpecialVal;
     public characterHealthObj()
    {
        MaxEnergy = 1;
        specialVal = 1;
        maxPoiseHealth = 1;
        CurrentHP = 1;
        MaxHp = 1;

}
}
