using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class PauseGame : MonoBehaviour
{
	[SerializeField] private GameObject _pauseMenu = null;

	public bool IsPaused = false;


	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			CyclePause();
		}
	}

	private void OnDestroy()
	{
		Pause(false);
		PauseConfiguration(true);
	}


	public void CyclePause()
	{
		IsPaused = !IsPaused;

		Pause(IsPaused);
		PauseConfiguration(IsPaused);
	}

	private void Pause(bool value)
	{
		Time.timeScale = value ? 0f : 1f;
	}

	private void PauseConfiguration(bool value)
	{
		CursorOptions.SetCursorOption(value);
		_pauseMenu.SetActive(value);
	}
}
