using TMPro;

using UnityEngine;

public class TimerUI : MonoBehaviour
{
	private TMP_Text _timeText;

	private Timer _timer = new();


	private void Awake()
	{
		_timeText = GetComponentInChildren<TMP_Text>();
	}

	private void Start()
	{
		_timer.SetTimer(90);
		_timer.Start();

		_timer.TimerCompleted += GameManager.OnLevelCompleted;
	}

	private void Update()
	{
		_timer.UpdateTimer(Time.deltaTime);

		ParseTimer(_timer.Target);
	}

	
	private void ParseTimer(float progress)
	{
		int minutes = (int)(progress / 60f);
		int seconds = (int)((minutes * 60) - progress) * -1;

		string secondsText = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
		string text = minutes == 0 ? secondsText : minutes.ToString() + ":" + secondsText;

		_timeText.text = text;

		///	Color
		if (minutes == 0 && seconds <= 30)
		{
			_timeText.color = Color.red;
		}
	}
}
