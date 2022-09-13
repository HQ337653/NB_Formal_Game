using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NBGame.Player
{
    //this class is the base class for all character 3d script
    public class charaControllerThreeD : MonoBehaviour
    {
        public bool Dashing;
        protected PlayerInput inputActions;
        protected Vector2 movingDirection;
        [SerializeField]
        protected Rigidbody selfRb;
        protected bool MovingFromInput;
        protected float WalkSpeed;
        public virtual float SpeedFactor { get; set; }
        public virtual float AtkSpeed { get; set; }

        public float ERemaingTime
        {
            get; private set;
        }
        public float QRemaingTime
        {
            get; private set;
        }
        protected void Awake()
        {
            inputActions = new PlayerInput();
            inputActions.Enable();
            inputActions.In3d.MoveDirection.performed += ctx => { movingDirection = ctx.ReadValue<Vector2>(); };
            inputActions.In3d.Moving.performed += ctx => MovingFromInput = true;
            inputActions.In3d.Moving.canceled += ctx => MovingFromInput = false;
            //change InputAction to bool in frame
        }

        public void EnterScene()
        {

        }

        protected void Start()
        {
            WalkSpeed = 3; SpeedFactor = 1;
        }

        private void Update()
        {
            if (MovingFromInput)
            {
                if (movingDirection.x > 0)
                {
                    flip(true);
                }
                else
                {
                    flip(false);
                }
            }
        }

       protected void flip(bool right)
        {
            if (right)
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 90, gameObject.transform.rotation.z);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 270, gameObject.transform.rotation.z);
            }
            
        }

            protected void OnEnable()
            {
                inputActions.Enable();
            }
            protected void OnDisable()
            {
            inputActions.Disable();
            }


        protected void FixedUpdate()
            {
            if (MovingFromInput) {
                selfRb.velocity = new Vector3(movingDirection.x * WalkSpeed* SpeedFactor / Time.timeScale , selfRb.velocity.y, movingDirection.y * WalkSpeed * SpeedFactor / Time.timeScale );
                
            }

            }

        internal void SwitchToScene()
        {
        }

        internal void LeaveScene()
        {
        }
    } 
} 
