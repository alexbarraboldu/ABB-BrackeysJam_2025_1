using System;

using UnityEngine;

[Serializable]
public class BoxData
{
	///	Shared
	public Mesh mesh;
	public string number;

	///	Box GameObject
	public Material materialStamp;
	public Material materialColor;

	/// Box UI
	public Sprite spriteStamp;
	public Sprite spriteColor;


	public BoxData() { }

	public BoxData(Mesh mesh, Material materialStamp, Material materialColor, Sprite spriteStamp, Sprite spriteColor, string number)
	{
		this.mesh = mesh;
		this.number = number;

		this.materialStamp = materialStamp;
		this.materialColor = materialColor;

		this.spriteStamp= spriteStamp;
		this.spriteColor = spriteColor;
	}
}
