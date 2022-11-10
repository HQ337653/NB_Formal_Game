
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NBGame.dialogue
{
    [System.Serializable]
    public class dialogueData:ISerializationCallbackReceiver
    {
        [SerializeReference]
        public List<DialagueContent> dialagueContents=new List<DialagueContent>();
       public List<connection> connectionsList=new List<connection>();
        public string Name;

        public int index=0;
        public DialagueContent AddDialogueChoice()
        {
            Debug.Log("addChoice");
            DialogueChoice a = new DialogueChoice();
            a.index = index;
            
            index += 1;
            dialagueContents.Add(a);
            return a;
        }

        public DialagueContent addCharaChange()
        {
            Debug.Log("addCharaChange");
            characterChange a = new characterChange();
            a.index = index;

            index += 1;
            dialagueContents.Add(a);
            return a;
        }
        public void setConnection(int start, int end,int whichStart)
        {
            connection Connection = new connection();
            Connection.begin = start;
            Connection.end = end;
            Connection.beginIndex = whichStart;
            connectionsList.Add(Connection);
            dialagueContents[start].next[whichStart] = dialagueContents[end];

        }

        public DialagueContent AddSingleDialogue()
        {
            singleDialogue a = new singleDialogue();
            a.index = index;
            if (index == 0&& connectionsList==null&& dialagueContents==null)
            {
                Debug.Log("new one");
                connectionsList = new List<connection>();
                dialagueContents = new List<DialagueContent>();
            }
            index += 1;
            dialagueContents.Add(a);
            return a;
        }
        DialagueContent[] d;
        connection[] connections;
        [System.Serializable]
        public class connection
        {
           public int begin;
            public int beginIndex;
           public int end;
        }
        #region Serialize
        public void OnBeforeSerialize()
        {
           // dialagueContentsForSerialize= dialagueContents.ToArray();
            //connectionsForSerialize= connectionsList.ToArray();

        }

        public void OnAfterDeserialize()
        {
            foreach (DialagueContent data in dialagueContents)
            {
                if (data is DialogueChoice)
                {
                    while (((DialogueChoice)data).choice.Count > data.next.Count)
                    {
                        data.next.Add(null);
                    }
                }
            }
            
            foreach (connection c in connectionsList)
            {
                
                dialagueContents[c.begin].next[c.beginIndex] = dialagueContents[c.end];
            }
        }
        #endregion

        #region data
        [System.Serializable]
        public class DialagueContent 
        {
            public string name;
            public Rect positionInEdictor;
            public position PicturePosition;
            public List<DialagueContent> next { get; private set; }
            public int index;
            public DialagueContent()
            {
                next = new List<DialagueContent>();
            }

            public enum position
            {
                Left, right, middle
            }
        }
        public class characterChange:DialagueContent, ISerializationCallbackReceiver
        {
            //character from left to right, null for empty
           public Sprite[] characters=new Sprite[3];
            public string[] charaPictureName=new string[3];
            public characterChange()
            {
                next.Add(null);
            }

            public void OnAfterDeserialize()
            {
                if (charaPictureName != null )
                {
                    for(int i=0;i< charaPictureName.Length;i++)
                    {
                        if (charaPictureName[i] != null&& charaPictureName[i] != "")
                        {
                            characters[i]= Resources.Load<Sprite>("NPC_Icon\\" + charaPictureName[i]);
                        }
                        else
                        {
                            characters[i] = null;
                        }
                    }
                }

            }

            public void OnBeforeSerialize()
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    if (characters[i] != null )
                    {
                        charaPictureName[i] = characters[i].name;
                    }
                    else
                    {
                        charaPictureName[i] = null;
                    }
                }
            }
        }
        [System.Serializable]
        public class singleDialogue : DialagueContent, ISerializationCallbackReceiver
        {
            public Sprite characterPicture;
            public string characterPictureName;
            public string dialogueContent="";
            public singleDialogue()
            {
                next.Add(null);
            }

            public void OnAfterDeserialize()
            {
                if (characterPictureName != null && characterPictureName != "")
                {
                    characterPicture = Resources.Load<Sprite>("NPC_Icon\\" + characterPictureName);
                }

            }

            public void OnBeforeSerialize()
            {
                if (characterPicture != null)
                    characterPictureName = characterPicture.name;
            }
            //public position p;
        }
        [System.Serializable]
        public class DialogueChoice : DialagueContent
        {
           // public string[] choice;
            public List<string> choice = new List<string>();
        }

        #endregion
    }
}