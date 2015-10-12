using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	private bool mainMenu;
	GameObject newGameButton;
	GameObject continueButton;
	GameObject quitButton;

	void Start()
	{
		mainMenu = true;
		newGameButton = transform.Find ("NewGame").gameObject;
		continueButton = transform.Find ("Continue").gameObject;
		quitButton = transform.Find ("Quit").gameObject;


	}
	//buttons for MainMenu
	public void NewGame()
	{
		Game.current = new Game();
		mainMenu = false;
		//currentMenu = Menu.NewGame;
		//play animation
	}

	public void Continue()
	{
		SaveLoad.Load();
		mainMenu = false;
		//currentMenu = Menu.Continue;
	}

	public void Quit()
	{
		Application.Quit();
	}

	//Buttons for NewGame



	void Update()
	{
	
	}


	public enum Menu {
		MainMenu,
		NewGame,
		Continue
	}

	public Menu currentMenu;

	void OnGUI () {

		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();
		//
		if(currentMenu == Menu.MainMenu) {

			GUILayout.Box("Mutate LA");
			GUILayout.Space(10);

			if(GUILayout.Button("New Game")) {
				Game.current = new Game();
				currentMenu = Menu.NewGame;
			}

			if(GUILayout.Button("Continue")) {
				SaveLoad.Load();
				currentMenu = Menu.Continue;
			}

			if(GUILayout.Button("Quit")) {
				Application.Quit();
			}
		}
		//
		else if (currentMenu == Menu.NewGame) {

			GUILayout.Box("Name Your Characters");
			GUILayout.Space(10);

			GUILayout.Label("Character Name");
			Game.current.currentCharacter.name = GUILayout.TextField(Game.current.currentCharacter.name, 20);


			if(GUILayout.Button("Save")) {
				//Save the current Game as a new saved Game
				SaveLoad.Save();
				//Move on to game...
				Application.LoadLevel(1);
			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}

		}

		else if (currentMenu == Menu.Continue) {
			
			GUILayout.Box("Select Save File");
			GUILayout.Space(10);
			
			foreach(Game g in SaveLoad.savedGames) {
				if(GUILayout.Button(" - " + g.currentCharacter.name + " - " )) {
					Game.current = g;
					//Move on to game...
					Application.LoadLevel("Level1");
				}

			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}
			
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}
}
