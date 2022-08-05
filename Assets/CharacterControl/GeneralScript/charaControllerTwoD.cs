using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace NBGame.Player
{
    public class charaControllerTwoD : MonoBehaviour
    {
        private PlayerInput inputActions;
        int movingDirection;
        [SerializeField]
        Rigidbody selfRb;
        private void Awake()
        {
            inputActions = new PlayerInput();
            inputActions.Enable();
            inputActions.In2d.LeftRight.performed += ctx => movingDirection = (int)ctx.ReadValue<float>();
            inputActions.In2d.LeftRight.canceled += ctx => movingDirection = 0;
            inputActions.In2d.Jump.performed += ctx => jump();
        }
        void jump()
        {
            if (isGrounded())
            {

                selfRb.AddForce(new Vector3(0, 12000, 0));
                // selfRb.velocity = new Vector3(0, 100, 0);
            }
        }

        private void OnEnable()
        {
            inputActions.Enable();
        }
        private void OnDisable()
        {
            inputActions.Disable();
        }

        public bool isGrounded()
        {
            {
                //return Physics.Raycast(transform.position, Vector3.down,1f);
                Collider[] c = Physics.OverlapBox(transform.parent.position, transform.parent.localScale / 2, transform.parent.rotation, 3);
                if (c.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        // Update is called once per fram

        private void FixedUpdate()
        {
            selfRb.velocity = new Vector3(movingDirection * 3 / Time.timeScale, selfRb.velocity.y, 0);

        }
    }
}
