using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace NBGame.UI
{
    public class DamagePopUp : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro textMesh;
        IEnumerator process()
        {
            yield return new WaitForSecondsRealtime(0.2f);
            gameObject.SetActive(false);
            yield break;


        }
        public void Setup(int damage)
        {

            textMesh.SetText(damage.ToString());
            gameObject.SetActive(true);
            StartCoroutine(process());
        }
    }
}
