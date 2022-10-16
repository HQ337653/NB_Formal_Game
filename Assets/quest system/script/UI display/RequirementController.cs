using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NBGame.quest;
namespace NBGame.UI
{
    public class RequirementController : MonoBehaviour
    {
        [SerializeField]
        GameObject Requirement_Prefab;

        //make requirment display based on the list of questRequirement
        public void make(List<questRequirement> requirements,List<bool> states)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            //List<questDisplay> result = new List<questDisplay>();
            for (int i = 0; i < requirements.Count; i++)
            {
                //foreach (questRequirement requirement in requirements)
                //{
                    GameObject g = Instantiate(Requirement_Prefab);
                g.GetComponent<RequirementDisplay>().show(states[i], requirements[i].description);
                    g.transform.SetParent(transform);
                //}
            }
            
        }
    }
}