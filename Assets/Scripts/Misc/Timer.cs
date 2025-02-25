using UnityEngine;

public class Timer
{
	private bool _isRunning = false;
	private float _timer = 60f;
	private float _target = 0f;
	private float _ammount = 0f;

	public float Target => _target;
	public float TargetMagnitude => _ammount;
	public bool IsDone => _target <= 0f;
	public bool IsRunning => _isRunning;


	public delegate void Completed();

	public event Completed TimerCompleted;


	public void UpdateTimer(float deltaTime)
	{
		if (!_isRunning) return;

		_target -= deltaTime;
		_ammount = Mathf.Lerp(1, 0, _target / _timer);

		if (_target <= 0f)
		{
			TimerCompleted?.Invoke();
			_isRunning = false;
		}
	}

	public void SetTimer(float value)
	{
		_timer = value;
	}

	public void Start()
	{
		_target = _timer;
		_isRunning = true;
	}

	public void Pause() => _isRunning = false;
	public void Resume() => _isRunning = true;
}
