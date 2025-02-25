using UnityEngine;

public class StampMachine : Machine
{
	protected override void OnMachineUse(GameObject gameObject)
	{
		gameObject.GetComponent<Box>().SetDecal(CurrentMaterial);
	}
}
