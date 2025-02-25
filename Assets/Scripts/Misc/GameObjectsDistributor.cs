using UnityEngine;

public class GameObjectsDistributor : MonoBehaviour
{
	[SerializeField] private int numColumns = 0;

	[SerializeField] private float rowWidth = 5;
	[SerializeField] private float rowHeight = 5;

	private Transform[] transforms = null;

	private void Awake()
	{
		GetChilds();
	}

	private void Start()
	{
		SetChildsPosition();
	}

	private void OnValidate()
	{
		if (transforms != null &&
			transforms.Length == transform.childCount) return;

		GetChilds();
		SetChildsPosition();
	}

	private void GetChilds()
	{
		transforms = GetComponentsInChildren<Transform>(false);
		transforms = transforms[1..transforms.Length];
	}

	private void SetChildsPosition()
	{
		int x = 0;
		int y = 0;

		foreach (Transform t in transforms)
		{
			t.position = new Vector3(transform.position.x + x * rowWidth, transform.position.y, transform.position.z - y * rowHeight);

			x++;
			if (x > numColumns)
			{
				x = 0;
				y++;
			}
		}
	}
}
