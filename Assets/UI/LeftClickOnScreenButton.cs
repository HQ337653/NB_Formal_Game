using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
//<Gamepad>/buttonEast

    //#if PACKAGE_DOCS_GENERATION || UNITY_INPUT_SYSTEM_ENABLE_UI
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;

////TODO: custom icon for OnScreenButton component

namespace UnityEngine.InputSystem.OnScreen
{
    /// <summary>
    /// A button that is visually represented on-screen and triggered by touch or other pointer
    /// input.
    /// </summary>
    [AddComponentMenu("Input/On-Screen Button")]
    public class LeftClickOnScreenButton : OnScreenControl, IPointerDownHandler, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {

            if (eventData.button == PointerEventData.InputButton.Left)
                SendValueToControl(0.0f);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                SendValueToControl(1.0f);
        }

        ////TODO: pressure support
        /*
        /// <summary>
        /// If true, the button's value is driven from the pressure value of touch or pen input.
        /// </summary>
        /// <remarks>
        /// This essentially allows having trigger-like buttons as on-screen controls.
        /// </remarks>
        [SerializeField] private bool m_UsePressure;
        */

        [InputControl(layout = "Button")]
        [SerializeField]
        public string m_ControlPath;

        protected override string controlPathInternal
        {
            get => m_ControlPath;
            set => m_ControlPath = value;
        }
    }
}
//#endif