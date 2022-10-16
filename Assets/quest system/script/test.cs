using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.quest;
using NBGame.UI;
public class test : MonoBehaviour
{
   public Quest Q;
    [SerializeField]
    questDisplay questD;
    public QuestState Qstate;
    // Start is called before the first frame update
    void Start()
    {
        List<subQuest> subQuests = new List<subQuest>();

        
        questRequirement re1= new questRequirement();
        re1.description = "red 1";
        questRequirement re2 = new questRequirement();
        re2.description = "red 2";
        List<questRequirement> res = new List<questRequirement>();
        res.Add(re1);
        res.Add(re2);
        subQuest q1 = new subQuest("fight red monster ", res);
        subQuests.Add(q1);  


        questRequirement re21 = new questRequirement();
        re21.description = "blue 1";
        List<questRequirement> res1 = new List<questRequirement>();
        res1.Add(re21);
        subQuest q2 = new subQuest("fight blue monster ", res1);
        subQuests.Add(q2);


        Q = new Quest("test", subQuests);
        Qstate = new QuestState(Q);
        //questD.displayQuest(0);
        
    }


}
