using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public int points = 0;

	[SerializeField] private Image _progressSlider = null;

	[SerializeField] private List<GameObject> _stars = new();

	private int min1 = 1;
	private int min2 = 2;
	private int min3 = 4;


	private void Awake()
	{
		foreach (GameObject star in _stars)
		{
			star.SetActive(false);
		}
	}

	private void Start()
	{
		_stars[0].SetActive(points > min1);
		_stars[1].SetActive(points > min2);
		_stars[2].SetActive(points > min3);

		_progressSlider.fillAmount = (_progressSlider.fillAmount == 0) ? 0.01f : ((float)points / (float)min3);
	}
}
