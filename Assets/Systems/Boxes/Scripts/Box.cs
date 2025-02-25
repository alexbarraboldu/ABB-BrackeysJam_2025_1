using UnityEngine;
using UnityEngine.Rendering.Universal;

using Utils;

public class Box : MonoBehaviour
{
	public BoxData boxData = new();

	private MeshRenderer _meshRenderer;
	private DecalProjector _decalProjector;


	private void Awake()
	{
		_meshRenderer = GetComponentInChildren<MeshRenderer>();
		_decalProjector = GetComponentInChildren<DecalProjector>(true);

		boxData.mesh = GetComponentInChildren<MeshFilter>().sharedMesh;
	}


	public void SetColor(Material color)
	{
		_meshRenderer.material = color;

		boxData.materialColor = color;
	}

	public void SetDecal(Material decal)
	{
		_decalProjector.enabled = true;
		_decalProjector.material = decal;

		boxData.materialStamp = decal;
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareLayer("Garbage"))
		{
			Destroy(gameObject);
		}
	}
}
