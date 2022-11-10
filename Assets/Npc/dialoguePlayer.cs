using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NBGame.UI;

namespace NBGame.dialogue
{
    public class dialoguePlayer : MonoBehaviour
    {
        [SerializeField]
        private Image leftImg;
        [SerializeField]
        private Image middleImg;
        [SerializeField]
        private Image rightImg;
        [SerializeField]
        private TextMeshProUGUI ContentText;
        [SerializeField]
        private TextMeshProUGUI CharaName;
        [SerializeField]
        GameObject contentBox;

        dialogueData dialogueData;
        dialogueData.DialagueContent currentContent;

        internal void endPlay()
        {
            gameObject.SetActive(false);
            UiController.EndDialoge();
        }

        internal void startPlay(dialogueData data)
        {
            dialogueData=data;
            gameObject.SetActive(true);
            currentContent = dialogueData.dialagueContents[0];
            clearImg();
            clearContent();
            show(currentContent);
            contentBox.SetActive(false);
        }

        void clearImg()
        {
            setSprite(leftImg, null);
            setSprite(middleImg, null);
            setSprite(rightImg, null);
        }

        void clearContent()
        {
            ContentText.text = "";
            CharaName.text = "";
        }
        void setSprite(Image img,Sprite s)
        {
            if (s==null)
            {
                img.enabled = false;
            }
            else
            {
                img.enabled = true;
                img.sprite = s;
            }
        }
        public void playNext()
        {
            if (currentContent.next==null|| currentContent.next.Count==0|| currentContent.next[0]==null)
            {
                endPlay();
            }
            currentContent = (currentContent.next[0]);
            show(currentContent);
        }
        void show(dialogueData.DialagueContent content)
        {
            if (content is dialogueData.singleDialogue)
            {
                showSingleDialogue((dialogueData.singleDialogue)content);
            }
            else if (content is dialogueData.DialogueChoice)
            {
                showChoiceDialogue((dialogueData.DialogueChoice)content);
            }else if (content is dialogueData.characterChange)
            {
                showCharaChange((dialogueData.characterChange)content);
            }
        }

        private void showCharaChange(dialogueData.characterChange content)
        {
            //leftImg.sprite = content.characters[0];
            setSprite(leftImg, content.characters[0]);
           // middleImg.sprite = content.characters[1];
            setSprite(middleImg, content.characters[1]);
            //rightImg.sprite = content.characters[2];
            setSprite(rightImg, content.characters[2]);
        }

        private void showChoiceDialogue(dialogueData.DialogueChoice content)
        {
           // throw new NotImplementedException();
        }

        private void showSingleDialogue(dialogueData.singleDialogue content)
        {
            contentBox.SetActive(true); 
            Debug.Log("showNext"+ content.dialogueContent+" "+ content.name);
            if (content.PicturePosition == dialogueData.DialagueContent.position.Left)
            {
                //leftImg.sprite = content.characterPicture;
                setSprite(leftImg, content.characterPicture);
            }
            else if (content.PicturePosition == dialogueData.DialagueContent.position.right)
            {
                //rightImg.sprite = content.characterPicture;
                setSprite(rightImg, content.characterPicture);
            }
            else
            {
                //middleImg.sprite = content.characterPicture;
                setSprite(middleImg, content.characterPicture);

            }

            ContentText.text=content.dialogueContent;
            CharaName.text = content.name;

        }

        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {

        }
    }
}