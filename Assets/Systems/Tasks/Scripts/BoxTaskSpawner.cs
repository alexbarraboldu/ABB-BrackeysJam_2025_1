using UnityEngine;

public class BoxTaskSpawner : MonoBehaviour
{
	[SerializeField] public GameObject _boxUIPrefab;

	public (BoxUI, TaskController) AddToView(BoxData boxData)
	{
		GameObject boxTask = Instantiate(_boxUIPrefab, transform);

		BoxUI boxUI = boxTask.GetComponent<BoxUI>();
		TaskController taskController = boxTask.GetComponent<TaskController>();

		boxUI.SetData(boxData);
		taskController.SetData(boxData);

		return (boxUI, taskController);
	}
}
