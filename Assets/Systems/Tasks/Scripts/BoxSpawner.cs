using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
	[SerializeField] private List<GameObject> _boxPrefabs = new();


	private GameObject GetGameObjectByMesh(Mesh mesh) => _boxPrefabs.Select(box => box.gameObject).Where(box => box.GetComponentInChildren<MeshFilter>().sharedMesh == mesh).First(); 

	private Box InstantiateBox(GameObject gameObject) => Instantiate(gameObject, transform.position, Quaternion.identity).GetComponent<Box>();

	internal Box Spawn(BoxData boxData)
	{
		GameObject boxGameObject = GetGameObjectByMesh(boxData.mesh);

		return InstantiateBox(boxGameObject);
	}
}
