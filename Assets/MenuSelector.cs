using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MenuSelector : MonoBehaviour {

	public EventSystem ES;
	private GameObject firstSelected;

	// Use this for initialization
	void Start () {
		firstSelected = ES.firstSelectedGameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (ES.firstSelectedGameObject != firstSelected)
		{
			if (ES.currentSelectedGameObject == null){
				ES.SetSelectedGameObject (firstSelected);
			} else {
				firstSelected = ES.currentSelectedGameObject;

			}
		}
	}
}
