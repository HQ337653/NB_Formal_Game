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
        public bool MovingFromInput;
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
            inputActions.In3d.MoveDirection.performed += ctx => { if (isActiveAndEnabled) { movingDirection = ctx.ReadValue<Vector2>(); } };
            inputActions.In3d.Moving.performed += ctx => { if (isActiveAndEnabled) { MovingFromInput = true;  } };
            inputActions.In3d.Moving.canceled += ctx => { if (isActiveAndEnabled) { MovingFromInput = false;  } };
            //inputActions.In3d.Moving.
            //change InputAction to bool in frame
        }
        
        

        protected void Start()
        {
            WalkSpeed = 3; SpeedFactor = 1;
        }

        private void Update()
        {
            //Debug.Log(MovingFromInput);
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


        protected void FixedUpdate()
            {
            if (MovingFromInput) {
                selfRb.velocity = new Vector3(movingDirection.x * WalkSpeed* SpeedFactor / Time.timeScale , selfRb.velocity.y, movingDirection.y * WalkSpeed * SpeedFactor / Time.timeScale );
                
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
        #region active and disactive
        protected void OnEnable()
            {
            selfRb.velocity = Vector3.zero;
        }
        protected void OnDisable()
            {
            //inputActions.Disable();
        }

        //called before the gameObject is disactive
        public virtual void LeaveScene()
        {
        }
        //called before the gameObject is activated
        public virtual void SwitchToScene()
        {
        }

        public virtual void ChangeToTwo()
        {
            MovingFromInput=false;
        }
        #endregion

    } 
} 
