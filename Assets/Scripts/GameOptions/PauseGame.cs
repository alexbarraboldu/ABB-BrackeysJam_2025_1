using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class PauseGame : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenu;


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			CyclePauseGame();
		}
	}


	public void Unpause()
	{
		CyclePauseGame();
	}

	private void CyclePauseGame()
	{
		bool isPaused = Time.timeScale == 0f;

		Pause(!isPaused);
		PauseConfiguration(!isPaused);
	}

	private void Pause(bool isPaused)
	{
		Time.timeScale = isPaused ? 0f : 1f;
	}

	private void PauseConfiguration(bool isPaused)
	{
		CursorOptions.SetCursorOption(isPaused);
		_pauseMenu.SetActive(isPaused);
	}

	private void OnDestroy()
	{
		Unpause();
	}
}
