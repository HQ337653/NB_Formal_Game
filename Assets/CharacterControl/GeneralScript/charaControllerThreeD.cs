using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.Player
{
    public class charaControllerThreeD : MonoBehaviour
    {
        private PlayerInput inputActions;
        Vector2 movingDirection;
        [SerializeField]
        Rigidbody selfRb;
        private float ERemaingTime;
        private float QRemaingTime;
        private void Awake()
        {
            inputActions = new PlayerInput();
            inputActions.Enable();
            inputActions.In3d.Move.performed += ctx => movingDirection = ctx.ReadValue<Vector2>().normalized;
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void FixedUpdate()
        {
            selfRb.velocity = new Vector3(movingDirection.x * 3 / Time.timeScale, selfRb.velocity.y, movingDirection.y * 3 / Time.timeScale);
        }

        public float getERemainingTime()
        {
            return ERemaingTime;
        }

        public float getQRemainingTime()
        {
            return QRemaingTime;
        }

    }
}