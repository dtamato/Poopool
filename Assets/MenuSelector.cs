///*
/// 
///
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class MenuSelector : MonoBehaviour {

	public EventSystem ES;
	private GameObject firstSelected;

	public bool buttonSelected = false;

	// Use this for initialization
	void Start () {
		firstSelected = ES.firstSelectedGameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (ES.firstSelectedGameObject != firstSelected) {
			if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) {
				if (ES.currentSelectedGameObject == null) {
					ES.SetSelectedGameObject (firstSelected);

				} else {
					firstSelected = ES.currentSelectedGameObject;

				}
			}
		}
	}
}

//*/

/*
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuSelector : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;

	private bool buttonSelected;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) 
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
	}

	private void OnDisable()
	{
		buttonSelected = false;
	}
}
*/