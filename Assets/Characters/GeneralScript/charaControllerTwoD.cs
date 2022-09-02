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
        [SerializeField]
        BoxCollider selfCollider;
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
        void testRange(Vector3 center, Vector3 half)
        {
            EffectsManager.RedCubeTester(center + half);
            EffectsManager.RedCubeTester(center - half);
            EffectsManager.RedCubeTester(new Vector3(center.x - half.x, center.y + half.y, center.z + half.z));
            EffectsManager.RedCubeTester(new Vector3(center.x + half.x, center.y - half.y, center.z + half.z));
            EffectsManager.RedCubeTester(new Vector3(center.x - half.x, center.y + half.y, center.z - half.z));
            EffectsManager.RedCubeTester(new Vector3(center.x + half.x, center.y - half.y, center.z - half.z));
        }
        public bool isGrounded()
        {
            {
                Vector3 center = transform.TransformPoint(selfCollider.center);
                center = new Vector3(center.x, center.y-0.05f, center.z);
                Vector3 half = new Vector3(selfCollider.size.x* selfCollider.gameObject.transform.lossyScale.x/2, selfCollider.size.y * selfCollider.gameObject.transform.lossyScale.y/2, selfCollider.size.z * selfCollider.gameObject.transform.lossyScale.z/2);
                Debug.Log(center);
                Debug.Log(half);
               // testRange(center,half);
                Debug.Log(Physics.BoxCast(center, half, Vector3.down, Quaternion.identity));
                //  return Physics.BoxCast(transform.position, new Vector3(tran);
                Collider[] c = Physics.OverlapBox(center, half, transform.parent.rotation, 3);
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
            if (movingDirection > 0)
            {
                flip(true);
            }
            else if(movingDirection < 0)
            {
                flip(false);
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

        private void Update()
        {
           /* Debug.Log(movingDirection);
                if (movingDirection > 0)
                {
                    flip(true);
                }
                else
                {
                    flip(false);
                }*/

        }
    }
}
