using System;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : BaseSingleton<SceneController>
{
	[SerializeField]
	[Tooltip("Delay (in milliseconds) after the scene is loaded to set it active")]
	[Range(0, 500)] private int _finalisedDelay = 100;

	[Header("Canvas Load Progress Bar")]
	[SerializeField] private SceneCanvasLoader _canvasLoader = new();

	private static int _finalisedFakeDelay = 100;
	private static SceneCanvasLoader _staticCanvasLoader;

	public override void Awake()
	{
		base.Awake();

		_finalisedFakeDelay = _finalisedDelay;
		_staticCanvasLoader = _canvasLoader;
	}

	private void Update()
	{
		_staticCanvasLoader?.UpdateProgressBar();
	}


	public static async void LoadSceneAsync(string sceneName)
	{
		_staticCanvasLoader?.EnableCanvas();

		AsyncOperation sceneToLoad = SceneManager.LoadSceneAsync(sceneName);
		sceneToLoad.allowSceneActivation = false;

		do
		{
			await Task.Delay(500);

			_staticCanvasLoader?.SetProgress(0.9f / sceneToLoad.progress);
		}
		while (sceneToLoad.progress < 0.9f);

		await Task.Delay(_finalisedFakeDelay);

		sceneToLoad.allowSceneActivation = true;
		_staticCanvasLoader?.DisableCanvas();
	}
}
