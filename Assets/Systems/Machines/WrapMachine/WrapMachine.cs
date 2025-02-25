using System.Collections.Generic;

using UnityEngine;

public class WrapMachine : Machine
{
	[SerializeField] private List<Material> _boxMaterials = new();

	protected override void OnMachineUse(GameObject gameObject)
	{
		gameObject.GetComponent<Box>().SetColor(_boxMaterials[MaterialIndex]);
	}
}
