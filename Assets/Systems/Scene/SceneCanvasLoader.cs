using System;

using UnityEngine;

[Serializable]
public class SceneCanvasLoader
{
	[SerializeField] private GameObject _loaderCanvas = null;
	[SerializeField] private UnityEngine.UI.Image _progressBar = null;

	private float _progressAmountTarget;
	

	public void SetProgress(float progressAmount)
	{
		_progressAmountTarget = progressAmount;
	}

	private void ResetProgressBar()
	{
		if (_progressBar != null)
		{
			_progressBar.fillAmount = 0;
			_progressAmountTarget = 0;
		}
	}

	public void EnableCanvas()
	{
		if (_loaderCanvas != null) _loaderCanvas.SetActive(true);
	}

	public void DisableCanvas()
	{
		if (_loaderCanvas != null)
		{
			_loaderCanvas.SetActive(false);
			ResetProgressBar();
		}
	}

	public void UpdateProgressBar()
	{
		if (_progressBar != null) _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _progressAmountTarget, 2 * Time.deltaTime);
	}
}
