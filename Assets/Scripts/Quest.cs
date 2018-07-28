using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quest : MonoBehaviour {	
    
    bool firstChat=false;
    Controller controller;
    void Start()
    {
        controller = GameObject.Find("Controller").GetComponent<Controller>();
        StartCoroutine(FirstTutorial());
    }

    IEnumerator FirstTutorial()
    {
        Transform c = GameObject.Find("Character").transform;
        Transform mark = GameObject.Find("ExclamationMark").transform;
        mark.gameObject.SetActive(false);
        while(true)
        {
            if(Vector3.Distance(c.position,mark.position)<2F)
            {
                controller.GetComponent<UIController>().EnableAssistance();
                break;
            }
            yield return new WaitForSeconds(.02F);
        }
    }


    public void CallQuest()
    {
        GameObject q ;
        if(!firstChat)
        {
            firstChat=true;

            controller.gameObject.GetComponent<UIController>().ShowScorePanel();
            controller.ActivateFruits();
            // GameObject.Find("ExclamationMark").transform.GetChild(0).gameObject.SetActive(false);
        }
        
        if(controller.score == 2 )
        {
            controller.gameObject.GetComponent<UIController>().ShowBossQuestion(this.gameObject);
        } 
        else
        {

            GameObject.Find("Controller").GetComponent<UIController>().ShowBossFirstQuest();
            //TEXT 3D I'm HUNGRY    
        }
    }
    // void OnTriggerEnter(Collider col)
    // {
    	
    // }

}
