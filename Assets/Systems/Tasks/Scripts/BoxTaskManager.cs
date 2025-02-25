using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public class BoxTaskManager : BaseSingleton<BoxTaskManager>
{
	[SerializeField] private BoxDataHolderSO _boxDataHolder;

	private BoxSpawner _boxSpawner;
	private BoxTaskSpawner _boxTaskSpawner;

	private List<TaskController> _currentTasks = new();


	public override void Awake()
	{
		base.Awake();

		_boxSpawner = FindFirstObjectByType<BoxSpawner>();
		_boxTaskSpawner = FindFirstObjectByType<BoxTaskSpawner>();
	}

	private void Start()
	{
		GenerateMultipleBox(4);

		InvokeRepeating("CheckForNewBoxes", 10f, 10f);
	}

	[ContextMenu("GenerateBox")]
	private void GenerateBoxTask()
	{
		BoxData taskData = _boxDataHolder.GenerateBoxData();

		(BoxUI, TaskController) t = _boxTaskSpawner.AddToView(taskData);
		_boxSpawner.Spawn(taskData);

		_currentTasks.Add(t.Item2);
	}

	public bool CheckCurrentTask(BoxData boxData)
	{
		TaskController result = null;

		foreach (TaskController t in _currentTasks)
		{
			bool s = t.boxData.materialStamp == boxData.materialStamp;
			bool c = t.boxData.materialColor == boxData.materialColor;
			bool n = t.boxData.number == boxData.number;

			if (s && c && n)
			{
				result = t;
				break;
			}
		}

		if (result != null)
		{
			_currentTasks.Remove(result);
			result.CompleteTask();
		}

		return result != null;
	}

	private async void GenerateMultipleBox(int num)
	{
		for (int i = 0; i < num; i++)
		{
			await Task.Delay(2000);

			GenerateBoxTask();
		}
	}

	private void CheckForNewBoxes()
	{
		if (_currentTasks.Count < 4)
		{
			GenerateBoxTask();
		}
	}
}
