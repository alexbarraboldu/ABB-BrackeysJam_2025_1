using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshCombiner : MonoBehaviour
{
	private void Awake()
	{
		CombineMeshFilters();
		SetMaterials();

		SetMeshColliders();
	}

	private void CombineMeshFilters()
	{
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>(false);
		meshFilters = meshFilters[1..meshFilters.Length];

		CombineInstance[] combine = new CombineInstance[meshFilters.Length];


		int i = 0;
		while (i < meshFilters.Length)
		{
			combine[i].mesh = meshFilters[i].mesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;

			//meshFilters[i].gameObject.SetActive(false);
			Destroy(meshFilters[i].gameObject);

			i++;
		}

		Mesh mesh = new Mesh();
		mesh.CombineMeshes(combine);
		GetComponent<MeshFilter>().sharedMesh = mesh;
	}

	private void SetMaterials()
	{
		MeshRenderer firstMR = transform.GetChild(0).GetComponent<MeshRenderer>();
		MeshRenderer baseMR = GetComponent<MeshRenderer>();

		List<Material> materials = new();
		firstMR.GetMaterials(materials);
		baseMR.SetMaterials(materials);
	}


	private void SetMeshColliders()
	{
		GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().mesh;
	}
}
