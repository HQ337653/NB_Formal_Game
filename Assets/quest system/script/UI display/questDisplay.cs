using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NBGame.quest;
namespace NBGame.UI
{
    public class questDisplay : MonoBehaviour
    {
        private QuestState currentQuest;
        private subQuest currentSubQuest;
        [SerializeField]
        private TextMeshProUGUI title;
        [SerializeField]
        private TextMeshProUGUI discription;
        [SerializeField]
        private RequirementController requirementController;
        [SerializeField]
        private Image finishedIcon;

        public void switchActivez(bool active)
        {
            gameObject.SetActive(active);
        }
        public void displayQuest(int index)
        {
            currentQuest = questController.questStateDictionary[index];
            title.text = currentQuest.Base.title;

            displaySubQuest();

        }


        public void displaySubQuest()
        {
            if (currentQuest==null)
            {
                title.text = "N/A";
                discription.text = "N/A";
                return;
            }
            currentSubQuest = currentQuest.Base.subQuests[currentQuest.phase];
            discription.text = currentSubQuest.description;
           requirementController.make(currentSubQuest.requirements, currentQuest.getRequirementStateList(currentQuest.phase));

            if (currentQuest.questFinished == true)
            {
                finishedIcon.enabled = true;
            }
            else
            {
                finishedIcon.enabled = false;   
            }
        }

        public void pressed()
        {
            if (currentQuest!=null&&currentQuest.getSubquestState(currentQuest.phase))
            {

                currentQuest.move();
                displaySubQuest();
            }
        }
    }
}