using System.Collections.Generic;
namespace NBGame.quest
{
    //QuestState save the state and also save a reference of which the Quest is these states for, can be serilized into json
    [System.Serializable]
    public class QuestState
    {
        //the quest id of the base- for saving and loading
        public int index;
        public bool active;
        public int phase;
        public bool questFinished;
       public List<bool> subquestFinished;
        public List<bool> requirementsFinshed;
        // because quest is not serilizable, this data will not be saved/ load to json
        public Quest Base;
        public delegate void d();
        public d finishQuest;

        public QuestState(Quest b)
        {
            Base = b;
            index=Base.questID;
            subquestFinished = new List<bool>();
            for (int i = 0; i < Base.subQuests.Count; i++)
            {
                subquestFinished.Add(false);
            }
            requirementsFinshed = new List<bool>();
            for (int i = 0; i < Base.subQuests.Count; i++)
            {
                for (int j = 0; j < Base.subQuests[i].requirements.Count; j++)
                {
                    requirementsFinshed.Add(false);
                }

            }

        }

        public bool getSubquestState(int index)
        {
            return subquestFinished[index];
        }

        public void setSubState(int index, bool value)
        {
            subquestFinished[index] = value;
        }
        public bool getRequirementState(int subquestIndex, int requrementIndex)
        {
            //get all previous index
            int targetIndex = -1;
            for (int i = 0; i < subquestIndex; i++)
            {
                targetIndex += Base.subQuests[i].requirements.Count;
            }
            targetIndex += requrementIndex;
            return requirementsFinshed[targetIndex];
        }

        public List<bool> getRequirementStateList(int subquestIndex)
        {
            List<bool> result = new List<bool>();
            int index = 0;
            for (int i=0;i< subquestIndex; i++)
            {
                index+=Base.subQuests[i].requirements.Count;
            }
            for (int i = 0; i < Base.subQuests[subquestIndex].requirements.Count; i++)
            {
                index += i;
                result.Add(requirementsFinshed[index]);
               
            }
            return result;
        }

        public void setRequirementState(int subquestIndex, int requrementIndex, bool value)
        {
            //get all previous index
            int targetIndex = 0;
            for (int i = 0; i < subquestIndex; i++)
            {
                targetIndex += Base.subQuests[i].requirements.Count;
            }
            targetIndex += requrementIndex;
            requirementsFinshed[targetIndex] = value;

            //cheak if all requirement meet and can move on
            List<bool> boolVal = getRequirementStateList(subquestIndex);
            bool result=true;
            //cheak if there is any false
            foreach (bool val in boolVal)
            {
                result = result&&val;
            }
            //if no false
            if (result)
            {
                setSubState(subquestIndex, true);
            }
        }

        public void move()
        {

            if (phase + 1 < Base.subQuests.Count)
            {
                phase = +1;
            }
            else
            {
                questFinished = true;
                finishQuest?.Invoke();
            }
        }
    }
}