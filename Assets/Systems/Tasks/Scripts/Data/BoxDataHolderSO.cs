using System.Collections.Generic;

using UnityEngine;

using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Box Data Holder", menuName = "Custom/BoxDataHolder")]
public class BoxDataHolderSO : ScriptableObject
{
	///	Shared
	[SerializeField] public List<Mesh> meshes;
	[SerializeField] public int numberOfDoors;

	///	Box GameObject
	[SerializeField] public List<Material> materialStamps;
	[SerializeField] public List<Material> materialColors;

	///	Box UI
	[SerializeField] public List<Sprite> spriteStamps;
	[SerializeField] public List<Sprite> spriteColors;

	public BoxData GenerateBoxData()
	{
		int rMesh = Random.Range(0, meshes.Count);
		int rStamp = Random.Range(0, materialStamps.Count);
		int rColor = Random.Range(0, materialColors.Count);
		int rDoor = Random.Range(1, numberOfDoors + 1);

		return new BoxData(
			meshes[rMesh],
			materialStamps[rStamp],
			materialColors[rColor],
			spriteStamps[rStamp],
			spriteColors[rColor],
			rDoor.ToString());
	}
}
