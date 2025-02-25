using System;

using UnityEngine;

[Serializable]
public class TaskController : MonoBehaviour
{
	private BoxUI _boxUi;
	public BoxData boxData;

	private Timer _timer = new();


	public bool IsCompleted { get; private set; }


	private void Awake()
	{
		_boxUi = GetComponent<BoxUI>();

		_timer.SetTimer(120);
		_timer.TimerCompleted += EndTask;
	}

	private void Start()
	{
		_timer.Start();
	}

	private void Update()
	{
		_timer.UpdateTimer(Time.deltaTime);
		_boxUi.SetSlider(_timer.TargetMagnitude);
	}


	public void CompleteTask()
	{
		IsCompleted = true;
		EndTask();
	}

	private void EndTask()
	{
		_boxUi.DestroyBoxUI();
	}

	public void SetData(BoxData boxData)
	{
		this.boxData = boxData;
	}
}
