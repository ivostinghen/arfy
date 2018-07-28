using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour 
{
	public GameObject mainMenu, levelMenu, cardMenu;
	public Text cardText,infoTxt;

	public void GoToPage(string page)
	{
		if(page.Equals("MainMenu"))
		{
			mainMenu.SetActive(true);
			levelMenu.SetActive(false);
		}
		else if(page.Equals("LevelMenu"))
		{
			mainMenu.SetActive(false);
			cardMenu.SetActive(false);
			levelMenu.SetActive(true);
		}
		else if(page.Equals("CardMenu"))
		{
			cardMenu.SetActive(true);
			levelMenu.SetActive(false);
		}
	}

	public void ChanceCardText(string card)
	{
		cardText.text = card;
		if(card.Equals("Cores"))
		{
			infoTxt.text = "Descrição:\nCard: A\nIdade: 6-9anos\nNível: Fácil";
		}
		else
		{
			infoTxt.text = "Descrição:\nCard: B\nIdade: 9-12anos\nNível: Médio";
		}
	}

	public  void InfoBt()
	{

	}

	public void LoadCard(string scene)
	{
		SceneManager.LoadScene(cardText.text);
	}

	public void QuitBt()
	{
		Application.Quit();
	}

	
}
