using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	[SerializeField]
	private int id;
	private Button button;

	// Use this for initialization
	void Start () {
		button = this.GetComponent<Button> ();
		button.onClick.AddListener (OnClickButton);
	}

	public void OnClickButton () {
		BoardMaster.getInstance().UpdateGame(id);
	}
}