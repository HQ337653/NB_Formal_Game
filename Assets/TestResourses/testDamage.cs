using System.Collections;
using UnityEngine;
using NBGame.HealthSystem;
namespace NBGame.TestResource
{
    public class testDamage : MonoBehaviour
    {
        // Start is called before the first frame update
        ArrayList gameObjects;

        void Start()
        {
            gameObjects = new ArrayList();
            StartCoroutine(normalAtkProcess());
        }

        private void OnTriggerEnter(Collider other)
        {
            gameObjects.Add(other);
        }
        private void OnTriggerExit(Collider other)
        {
            gameObjects.Remove(other);
        }
        protected virtual IEnumerator normalAtkProcess()
        {
            while (true)
            {
                Collider[] c = Physics.OverlapBox(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), new Vector3(gameObject.transform.localScale.x / 2, gameObject.transform.localScale.y / 2, gameObject.transform.localScale.z / 2));
                foreach (Collider a in c)
                {
                    if (a.gameObject.activeInHierarchy == true)
                    {
                        a.gameObject.GetComponent<CharacterHp>()?.damage(10, false);
                    }

                }
                yield return new WaitForSecondsRealtime(0.5f);
            }


        }
    }
}
