using UnityEngine;

using Utils;

public class BoxTaskChecker : MonoBehaviour
{
	[SerializeField] private int doorNumber = 1;

	private Box _enteredBox = null;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareLayer("Object"))
		{
			_enteredBox = other.GetComponent<Box>();

			BoxData boxData = _enteredBox.boxData;
			boxData.number = doorNumber.ToString();

			bool result = BoxTaskManager.Instance.CheckCurrentTask(boxData);
			if (result)
			{
				Destroy(other.gameObject);
				GameManager.Instance.tasksCompleted++;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareLayer("Object"))
		{
			if (other.gameObject == _enteredBox.gameObject)
			{
				_enteredBox.boxData.number = "";
				_enteredBox = null;
			}
		}
	}
}
