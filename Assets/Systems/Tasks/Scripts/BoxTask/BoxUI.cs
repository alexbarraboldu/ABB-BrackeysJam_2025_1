using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class BoxUI : MonoBehaviour
{
	[Header("Progress bar")]
	[SerializeField] private Image sliderImage;

	[Header("Tasks")]
	[SerializeField] private MeshFilter boxMeshFilter;
	[SerializeField] private Image stampImage;
	[SerializeField] private Image colorImage;
	[SerializeField] private TMP_Text doorNumText;


	public void SetSlider(float value)
	{
		value = Mathf.Lerp(1, 0, value);

		if (value < 0.5) sliderImage.color = Color.yellow;
		if (value < 0.2) sliderImage.color = Color.red;

		sliderImage.fillAmount = value;
	}

	public void SetData(BoxData boxData)
	{
		boxMeshFilter.mesh	= boxData.mesh;
		stampImage.sprite	= boxData.spriteStamp;
		colorImage.sprite	= boxData.spriteColor;
		doorNumText.text	= boxData.number;
	}

	public void DestroyBoxUI()
	{
		Destroy(gameObject);
	}
}
