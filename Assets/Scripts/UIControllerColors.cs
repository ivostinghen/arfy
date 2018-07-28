using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIControllerColors : MonoBehaviour {


	public GameObject questionPanel;
	public Sprite[] items; 
	public GameObject scorePanel;
	public GameObject recordPanel;
	public AudioSource speak;
	public string answer;
	public bool firstLearn;
	public Text chatText;
	
	int dialogues;
	public GameObject quitDialogue;
	public GameObject learnPanel;
     public Color StringToColor(string color)
     {
         return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
     }

	public void OpenQuest(string color)
	{

		chatText.text = "Qual a cor dessa plataforma?";
		questionPanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("images/platform");
		questionPanel.transform.GetChild(1).gameObject.SetActive(false);
		questionPanel.transform.GetChild(2).gameObject.SetActive(true);
		questionPanel.transform.GetChild(3).gameObject.SetActive(true);
		questionPanel.transform.GetChild(0).GetComponent<Image>().color = StringToColor(color);
		questionPanel.SetActive(true);
	}

	public void StartDialogue()
	{
		chatText.text =  "Sou a princesa Bia, preciso resgatar minha coroa...";

		questionPanel.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
		questionPanel.transform.GetChild(1).gameObject.SetActive(true);
		questionPanel.transform.GetChild(2).gameObject.SetActive(false);
		questionPanel.transform.GetChild(3).gameObject.SetActive(false);
		questionPanel.transform.GetChild(0).GetComponent<Image>().color = Color.white;
		questionPanel.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("images/girl") ;
		questionPanel.SetActive(true);
	}
	public void NextBt(GameObject bt)
	{
		dialogues++;
		if(dialogues == 1)
		{
			chatText.text =  "Preciso diminuir o tamanho das plataformas mágicas para chegar até ela...";
		}
		else if(dialogues == 2)
		{
			chatText.text =  "Preciso dizer cada cor em inglês, pode me ajudar?";
			
		}
		else if(dialogues == 3)
		{
			chatText.text =  "Legal! Toque na plataforma à minha frente para interagir.";
			dialogues = 0;
			bt.SetActive(false);
			quitDialogue.SetActive(true);
			GetComponent<ControllerColors>().UpdateExclamationPos();
			
			try {
				GameObject g = GameObject.Find("ExclamationMark0"); 
				g.name="ExclamationMark";
			}
			catch {
			    
			}
			
			GameObject.Find("ExclamationMark").GetComponent<Collider>().enabled = true;
		}
		
		
	}

	public void QuitDialogue(GameObject bt)
	{
		bt.SetActive(false);
		questionPanel.SetActive(false);
		GetComponent<ControllerColors>().inScene=false;	
		bt.transform.parent.GetChild(1).gameObject.SetActive(true);
	}
	public void DisableAssistance()
	{
		Transform track = GameObject.Find("TrackAssistance").transform;
        track.transform.GetComponent<Image>().enabled = false;
        track.GetChild(0).gameObject.SetActive(false);
	}

	// public void EnableAssistance()
	// {
	// 	Transform track = GameObject.Find("TrackAssistance").transform;
 //        track.transform.GetComponent<Image>().enabled = true;
 //        track.GetChild(0).GetComponent<Text>().text = "Toque na plataforma para interagir";
 //        track.GetChild(0).gameObject.SetActive(true);
	// }

	

	public void UpdateScore(int score)
	{
		scorePanel.transform.GetComponentInChildren<Text>().text = score+"/2 frutas";
	}

	public void ShowScorePanel()
	{
		scorePanel.SetActive(true);
	}

	public void QuitPanelBt()
	{
		// firstLearn = false;
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
		answer = GetComponent<ControllerColors>().GetColor();
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

    	// if(GetComponent<Controller>().score == 2)
    	// {
    	// 	//TODO SPAWN COROA OU ALGUM PRESENTE

    	// } 

		questionPanel.GetComponent<Animator>().SetBool("open",false);
		yield return new WaitForSeconds(1);
	
		// questionPanel.transform.GetChild(2).gameObject.SetActive(false);
		// questionPanel.transform.GetChild(3).gameObject.SetActive(false);
		questionPanel.transform.GetChild(4).gameObject.SetActive(false);
		// GameObject l = questionPanel.transform.GetChild(5).GetChild(0).GetChild(0).gameObject;
		// l.GetComponent<Animator>().SetBool("open",false);
		learnPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().enabled=true;
		learnPanel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>().enabled=true;
		learnPanel.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().enabled = false;
		// l.transform.gameObject.GetComponent<Image>().enabled = true;
		// l.transform.gameObject.GetComponent<Animator>().enabled = true;
		firstLearn = false;
		GetComponent<ControllerColors>().inScene=false;	

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
		yield return new WaitForSeconds(3F);
		StopCoroutine(cor);
		yield return new WaitForSeconds(1);
		// recordPanel.SetActive(false);
		GetComponent<Watson>().Active=false;
		GetComponent<Watson>().StopRecording();
		recordPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Button>().interactable = true;
		recordPanel.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);

		recordPanel.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Animator>().SetBool("recording",false);

		recordPanel.transform.GetChild(0).GetChild(2).gameObject.GetComponent<Text>().text = "Vamos lá!\nToque para gravar:";
		GetComponent<ControllerColors>().CheckAnswer();
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
