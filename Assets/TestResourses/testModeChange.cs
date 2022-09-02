using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using NBGame.UI;

public class testModeChange : MonoBehaviour
{
    public Button B;

    private void Start()
    {
        B.onClick.AddListener(ctx);
    }

    private void ctx()
    {
        GameModeController.changeMode();
    }
}
