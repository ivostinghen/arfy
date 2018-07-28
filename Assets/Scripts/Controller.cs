using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	public GameObject[] items;
	public GameObject fruits;
	public int score;
	public bool inScene;
	public GameObject answer;
	public GameObject acertouPanel;
	void Start()
	{
		items = GameObject.FindGameObjectsWithTag("Item");	
	}
	
	public void CheckAnswer()
	{
		print(GetComponent<Watson>().word);
		// print(answer);
		if(GetComponent<Watson>().word.Equals(answer.name))
		{
			StartCoroutine(HitWord(answer.name));
			

		}
		else
		{
			print("WRONGGGGGGGGGGGGG");
			GameObject.Find("RespostaTxt").GetComponent<Text>().text = "Resposta incorreta!\n Tente de novo:";
		}
	}
	public void UpdateUI()
	{
		GetComponent<UIController>().UpdateScore(score);

	}

	public void ActivateFruits()
	{
		fruits.SetActive(true);
	}

	//DEBUG PC ////////////////////////
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
		 UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"); 
		}
		// if(Input.GetKeyDown("a"))
		// {
		// 	StartCoroutine(HitWord("strawberry"));
		// }
	}

	//////////////////////





	public IEnumerator HitWord(string word)
	{
		//TODO: SALVAR NO PLAYERPREFS a estatistica, tem porcentagem?
		// GameObject.Find("Character").GetComponent<Player>().score 
     	Destroy(answer);
		score ++;
		// if(score == 2)
		// {

		// }
		UpdateUI();
		
		acertouPanel.SetActive(true);
		GetComponent<UIController>().QuitPanelBt();
		acertouPanel.GetComponent<Animator>().SetBool("open",true);
		yield return new WaitForSeconds(.7F);
		
		acertouPanel.GetComponent<Animator>().SetBool("open",false);
		yield return new WaitForSeconds(.5F);
		acertouPanel.SetActive(false);
		
		print("ACERTOOOOOOOO MIZERAVIIIIIIIIII");
	
		GameObject.Find("Character").GetComponent<Player>().Jump();



	}


}
