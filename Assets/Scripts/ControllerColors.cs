using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerColors : MonoBehaviour {
 
	public GameObject hitPanel;
	public bool firstPress;
	int currentColor;
	public GameObject exclamationMark;
	public GameObject crystals;
	public bool inScene ;
	string[] colors= {"yellow","green","white","green","blue","yellow","black"};


	public string GetColor()
	{
		return colors[currentColor];
	}
	// void Start(){
	// 	//PC DEBUG currentColor = 4;
	// }

  	void Update () 
    {
    	if (Input.GetKeyDown(KeyCode.Escape)) 
		{
		 UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"); 
		}
		//
		// if(Input.GetKeyDown("a"))
		// {
		// 	StartCoroutine(HitWord());
		// }
	

        if (Input.GetMouseButtonDown(0))
        {
        	if(inScene) return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(/*!firstPress && */hit.transform.name.Equals("Character"))
                {
                	inScene=true;
                    firstPress=true;
                    GetComponent<UIControllerColors>().StartDialogue();
                    GetComponent<UIControllerColors>().DisableAssistance();
                }
                else if (hit.transform.name.Equals("ExclamationMark"))
                {
                	inScene=true;
                	GetComponent<UIControllerColors>().OpenQuest(colors[currentColor]);	
                	print(hit.transform.name); 
                }
            }
        }
    }

    public void UpdateExclamationPos()
    {
    	Vector3 pos = crystals.transform.GetChild(currentColor).transform.position;
    	pos.y = 1F;
    	exclamationMark.transform.position = pos;
    }
    public void CheckAnswer()
	{
		print(GetComponent<Watson>().word);
		print(colors[currentColor]);
		if(GetComponent<Watson>().word.Equals(colors[currentColor]))
		{
			StartCoroutine(HitWord());
		}
		else
		{
			print("WRONGGGGGGGGGGGGG");
			GameObject.Find("RespostaTxt").GetComponent<Text>().text = "Resposta incorreta!\n Tente de novo:";
		}
	}

	// public IEnumerator MoveCharacter()
	public IEnumerator MoveCharacter(Vector3 targetPos, Transform player)
	{
		targetPos.y = player.position.y;
		yield return new WaitForSeconds(2F);

			while(Vector3.Distance(player.position,targetPos) > .2F)
			{
				// print(Vector3.Distance(player.position,targetPos));
				yield return new WaitForSeconds(.02F);
				player.position = Vector3.MoveTowards(player.position,targetPos,Time.deltaTime* 2.3F);
			}
		yield return null;

	}
	
	public IEnumerator HitWord()
	{
		//TODO: SALVAR NO PLAYERPREFS a estatistica, tem porcentagem?
		// GameObject.Find("Character").GetComponent<Player>().score 
     	// Destroy(answer);

		
		hitPanel.SetActive(true);
		GetComponent<UIControllerColors>().QuitPanelBt();
		hitPanel.GetComponent<Animator>().SetBool("open",true);
		yield return new WaitForSeconds(.7F);
		
		hitPanel.GetComponent<Animator>().SetBool("open",false);
		yield return new WaitForSeconds(.5F);
		hitPanel.SetActive(false);
		
		print("ACERTOOOOOOOO MIZERAVIIIIIIIIII");
		

		Crystal c = crystals.transform.GetChild(currentColor).GetComponent<Crystal>();
		StartCoroutine(c.Close());
		
		// StartCoroutine(MoveCharacter());

		
		StartCoroutine(MoveCharacter(c.transform.position,GameObject.Find("Character").transform));
	    currentColor++;
		UpdateExclamationPos();
		if(currentColor==7)
		{
			yield return new WaitForSeconds(5F);
			Finished();
			
		}
		// GameObject.Find("Character").GetComponent<Player>().Jump();



	}
	void Finished()
	{
		GameObject c = GameObject.Find("Crown");
		c.transform.parent = GameObject.Find("Character").transform;
		c.transform.localPosition = new Vector3(0,1,0);

	}
                
}