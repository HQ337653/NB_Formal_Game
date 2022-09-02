using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace NBGame.Player
{
    public class CharaChangeUiEvents : MonoBehaviour
    {
        public delegate void floatEvent(float i);
        public event floatEvent HpChanged;
        public event floatEvent SpecialBarChanged;
        public event floatEvent EnegryChanged;
        public event floatEvent ETimeChanged;
        public event floatEvent QTimeChanged;
        public delegate void boolEvent(bool i);
        public event boolEvent highLightE;
        public event boolEvent highLightQ;
        public delegate void BarInfo(Vector2 scale, Sprite s);
        public event BarInfo setBar;
        public delegate void Button(Sprite s);
        public event Button changeEButton;
        public event Button changeQButton;
        public event Button changeDashButton;
        public event Button changeNormalButton;
        public delegate void AllRelatedUi(Sprite E, Sprite Q, Sprite normal, Sprite Dash);

        public void AllCharaRelatedUiChanged(Sprite E, Sprite Q, Sprite normal, Sprite Dash)
        {
            EButtonChanged(E);
            QButtonChanged(Q);
            NormalButtonChanged(normal);
            DashButtonChanged(Dash);

        }
        public void AllHealthUiChanged(float Hp, float Energy, float Special)
        {
            showHp(Hp);
            showEnegry(Energy);
            showSpecialBar(Special);


        }


        public void showHp(float i)
        {
            HpChanged?.Invoke(i);
        }
        public void showSpecialBar(float i)
        {
            SpecialBarChanged?.Invoke(i);
        }

        public void showSpecialBar(Vector2 v, Sprite s)
        {
            setBar?.Invoke(v, s);
        }
        public void showEnegry(float i)
        {
            EnegryChanged?.Invoke(i);
        }
        public void EShowTime(float i)
        {
            ETimeChanged?.Invoke(i);
        }
        public void QShowTime(float i)
        {
            QTimeChanged?.Invoke(i);
        }
        public void EHightChanged(bool i)
        {
            highLightE?.Invoke(i);
        }

        public void QHightChanged(bool i)
        {
            highLightQ?.Invoke(i);
        }

        public void EButtonChanged(Sprite s)
        {
            changeEButton?.Invoke(s);
        }
        public void QButtonChanged(Sprite s)
        {
            changeQButton?.Invoke(s);
        }
        public void NormalButtonChanged(Sprite s)
        {
            changeNormalButton?.Invoke(s);
        }
        public void DashButtonChanged(Sprite s)
        {
            changeDashButton?.Invoke(s);
        }

    }
}
