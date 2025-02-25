using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseSingleton<GameManager>
{
	public int tasksCompleted = 0;


	public override void Awake()
	{
		base.Awake();

		SceneManager.sceneLoaded += OnSceneLoaded;

	}

	private void Start()
	{
		SceneManager.LoadScene(1);
	}
	

	private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		if (arg0.name == "MainMenu")
		{
			CursorOptions.SetCursorOption(true);
			tasksCompleted = 0;
		}
		else if (arg0.name == "EndScene")
		{
			FindFirstObjectByType<ScoreController>().points = tasksCompleted;
			CursorOptions.SetCursorOption(true);
		}
	}

	internal static void OnLevelCompleted()
	{
		SceneController.LoadSceneAsync("EndScene");
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
