using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> _menusGO = new();

	private Dictionary<string, GameObject> _menus = new();
	private string _currentMenu = "";


	private void Awake()
	{
		for (int i = 0; i < _menusGO.Count; i++)
		{
			_menus.Add(_menusGO[i].name, _menusGO[i]);
		}
		_currentMenu = _menusGO[0].name;
	}


	public void OpenMenu(string menuName)
	{
		_menus[_currentMenu].SetActive(false);
		_menus[menuName].SetActive(true);
		_currentMenu = menuName;
	}
}
