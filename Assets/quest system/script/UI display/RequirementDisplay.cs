using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NBGame.quest;
namespace NBGame.UI
{
    public class RequirementDisplay : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI textMeshPro;
        [SerializeField]
        private Image state;
        [SerializeField]
        private Sprite unfinished;
        [SerializeField]
        private Sprite finished;
        //public questRequirement questRequirement;
     /*   public void SetActivation(bool active)
        {
            if (active)
            {
                state.sprite = finished;
            }
            else
            {
                state.sprite = unfinished;
            }
        }*/

        public void show(bool finish, string requirement)
        {

            textMeshPro.text = requirement;
            //questRequirement.requirementMeeted += Activate;
            if (finish == true)
            {
                state.sprite = finished;
            }
            else
            {
                state.sprite = unfinished;
            }
        }

        private void Start()
        {
          /*  textMeshPro.text = questRequirement.description;
            //questRequirement.requirementMeeted += Activate;
            if (questRequirement.finished == true)
            {
                state.sprite = finished;
            }
            else
            {
                state.sprite = unfinished;
            }*/
        }

    }
}
