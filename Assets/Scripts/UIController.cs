using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour {


	public GameObject questionPanel;
	public Sprite[] items; 
	public GameObject scorePanel;
	public GameObject recordPanel;
	public AudioSource speak;
	public string answer;
	public bool firstLearn;
	public void DisableAssitance()
	{
		Transform track = GameObject.Find("TrackAssistance").transform;
        track.transform.GetComponent<Image>().enabled = false;
        track.GetChild(0).gameObject.SetActive(false);
	}

	public void EnableAssistance()
	{
		GameObject track = GameObject.Find("TrackAssistance");
        track.transform.GetComponent<Image>().enabled = true;
        track = track.transform.GetChild(0).gameObject;    
        track.GetComponent<Text>().text = "Quando o Ponto de Exclamação aparecer,\n você pode clicar no objeto para interagir"; 
        track.SetActive(true);
	}

	public void UpdateScore(int score)
	{
		scorePanel.transform.GetComponentInChildren<Text>().text = score+"/2 frutas";
	}

	public void ShowScorePanel()
	{
		scorePanel.SetActive(true);
	}

	public void ShowQuestion(GameObject item)
	{
		questionPanel.transform.GetChild(1).gameObject.SetActive(true);
		questionPanel.transform.GetChild(2).transform.gameObject.SetActive(true);
		GetComponent<Controller>().inScene = true;
		questionPanel.GetComponent<Animator>().SetBool("open",true);
		GetComponent<Controller>().answer = item;
		answer = item.name;
		int id = 0;
		for(int i=0;i<items.Length;i++)
		{	
			if(items[i].name.Equals(item.name))
			{
				id = i;
			}
		}
		questionPanel.transform.GetChild(0).GetComponent<Image>().sprite = items[id];
		questionPanel.SetActive(true);
		///TODO: mostrar mic, desabilitar andar personagem
		questionPanel.GetComponentInChildren<Text>().text = "Hmm ... what's the name of this fruit in English?\n\nHmm... qual é mesmo o nome dessa fruta em inglês?";
	}

	public void ShowBossQuestion(GameObject item)
	{
		GetComponent<Controller>().inScene = true;
		questionPanel.GetComponent<Animator>().SetBool("open",true);
		questionPanel.transform.GetChild(0).GetComponent<Image>().sprite = items[2];
		questionPanel.SetActive(true);
		questionPanel.GetComponentInChildren<Text>().text = "WOW! Apple and strawberrie these are my favorite fruits! Thank you, I was very hungry ...\n\nWOW! Maçã e morango, essas são minhas frutas preferidas! Obrigado, eu estava com muita fome... ";
		questionPanel.transform.GetChild(4).gameObject.SetActive(true);
		questionPanel.transform.GetChild(1).gameObject.SetActive(false);
		// questionPanel.gameObject.GetChild(0).GetComponent<Text>().text = "WOW! Banana e morango minhas frutas preferidas! Obrigado, eu estava com muita fome...";
	}
	public void ShowBossFirstQuest()
	{
		GetComponent<Controller>().inScene = true;
		questionPanel.GetComponent<Animator>().SetBool("open",true);
		questionPanel.transform.GetChild(0).GetComponent<Image>().sprite = items[2];
		questionPanel.SetActive(true);
		questionPanel.transform.GetChild(4).gameObject.SetActive(true);
		questionPanel.transform.GetChild(1).gameObject.SetActive(false);
		questionPanel.GetComponentInChildren<Text>().text = "I am starving! Bring me two fruits and I'll give you a reward ...\n\nEstou faminto! Me traga duas frutas e te darei uma recompensa...";
	}

	public void QuitPanelBt()
	{
		firstLearn = false;
		StartCoroutine(QuitPanel());
	}

	public void ReadBt(GameObject bt)
	{
		if(firstLearn)return;
		StartCoroutine(CorReadBt(bt));

	}
	public IEnumerator CorReadBt(GameObject bt)
	{
		
		firstLearn = true;
		bt.transform.GetComponent<Animator>().enabled= true;
		bt.GetComponent<Animator>().SetBool("open",true);
		Text t = bt.GetComponentInChildren<Text>();
		yield return new WaitForSeconds(.3F);
		t.text = answer;
		t.enabled = true;
	}
	
	public void LearnBt(GameObject obj)
	{
		// GameObject l = Instantiate(Resources.Load("LearnPanel"))as GameObject;
		// // l.transform.parent = questionPanel.transform;
		// l.transform.SetParent(questionPanel.transform, false);

		obj.SetActive(true);
		if(firstLearn)return;
		
		obj.GetComponent<Image>().enabled = true;

		// obj.GetComponent<Animator>().SetBool("open",true);
		speak.clip = Resources.Load("audio/"+answer) as AudioClip;
		
	}

	public void Listen()
	{
		speak.Play();
	}
	public void QuitLearn(GameObject bt)
	{
		bt.transform.GetChild(0).GetChild(0).GetComponent<Animator>().enabled= false;

		bt.GetComponent<Animator>().SetBool("open",false);
		bt.SetActive(false);
	}
	public IEnumerator QuitPanel()
	{

    	if(GetComponent<Controller>().score == 2)
    	{
    		//TODO SPAWN COROA OU ALGUM PRESENTE

    	} 

		questionPanel.GetComponent<Animator>().SetBool("open",false);
		yield return new WaitForSeconds(1);
		GetComponent<Controller>().inScene = false;
		questionPanel.transform.GetChild(2).gameObject.SetActive(false);
		questionPanel.transform.GetChild(3).gameObject.SetActive(false);
		questionPanel.transform.GetChild(4).gameObject.SetActive(false);
		GameObject l = questionPanel.transform.GetChild(5).GetChild(0).GetChild(0).gameObject;
		l.GetComponent<Animator>().SetBool("open",false);
		l.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
		l.transform.gameObject.GetComponent<Image>().enabled = true;
		l.transform.gameObject.GetComponent<Animator>().enabled = true;

		questionPanel.SetActive(false);

	}
	public void StartRecordBt()
	{
		StartCoroutine(Record());
		
	}


	public void OpenRecord()
	{
		recordPanel.GetComponentInChildren<Animator>().SetBool("open",true);
		recordPanel.SetActive(true);
	}
	public IEnumerator Record()
	{
		
		GetComponent<Watson>().Active=true;
		GetComponent<Watson>().StartRecording();
		Coroutine cor = StartCoroutine(RecordAnim());
		recordPanel.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);

		recordPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Animator>().SetBool("recording",true);
		recordPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Button>().interactable = false;
		yield return new WaitForSeconds(5F);
		StopCoroutine(cor);
		yield return new WaitForSeconds(1);
		// recordPanel.SetActive(false);
		GetComponent<Watson>().Active=false;
		GetComponent<Watson>().StopRecording();
		recordPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Button>().interactable = true;
		recordPanel.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);

		recordPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Animator>().SetBool("recording",false);

		recordPanel.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>().text = "Vamos lá!\nToque para gravar:";
		GetComponent<Controller>().CheckAnswer();
	}


	public void QuitRecordPanel()
	{
		recordPanel.SetActive(false);
	}
	public IEnumerator RecordAnim()
	{
		Text txt = recordPanel.GetComponentInChildren<Text>();
		string[] sequencia = {"Gravando.", "Gravando..","Gravando..."};
		int i=0;
		while(true)
		{
			txt.text = sequencia[i];
			yield return new WaitForSeconds(.2F);	
			i++;
			if(i==3)i=0;
		}
		

	}
}
