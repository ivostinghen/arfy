using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller2 : MonoBehaviour {
	public GameObject optionA,optionB,recordPanel,questionPanel; 
	public GameObject okBt;
	public Text chatText;

    public IEnumerator Start()
    {
    	yield return new WaitForSeconds(3);
    	questionPanel.SetActive(true);
    }
	public void OptionBt()
	{
		optionA.SetActive(true);
		// optionB.SetActive(true);
		okBt.SetActive(false);
		chatText.text = "Toque no simbolo abaixo e pronuncie a palavra 'ESQUIVAR' para esquivar-se do barco.";
	}
	
	public void CheckAnswer(string answer)
	{
		print(GetComponent<Watson>().word);
		// print(answer);
		if(GetComponent<Watson>().word.Equals(answer))
		{
			
			print("ACERTOOOOOOOO MIZERAVIIIIIIIIII");
			// Destroy(GameObject.Find(answer));
			// GameObject.Find("Character").GetComponent<Player>().Jump();
		}
		else
		{
			print("ERRoooOOOOOU");
		}
	}

	public void OptionABt()
	{
		StartCoroutine(Record("dive"));
	}
	public void OptionBBt()
	{
		StartCoroutine(Record("float"));
	}
	
	public IEnumerator Record(string action)
	{
		recordPanel.GetComponentInChildren<Animator>().SetBool("open",true);
		recordPanel.SetActive(true);
		GetComponent<Watson>().Active=true;
		GetComponent<Watson>().StartRecording();
		Coroutine cor = StartCoroutine(RecordAnim());
		yield return new WaitForSeconds(5F);
		StopCoroutine(cor);
		recordPanel.GetComponentInChildren<Animator>().SetBool("open",false);
		yield return new WaitForSeconds(1);
		recordPanel.SetActive(false);
		GetComponent<Watson>().Active=false;
		GetComponent<Watson>().StopRecording();
		CheckAnswer(action);
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
