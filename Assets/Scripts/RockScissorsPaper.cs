using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockScissorsPaper : MonoBehaviour {
	[SerializeField]
	private int id;
	private Button Button;
	
	// Use this for initialization
	void Start () {
		Button = this.GetComponent <Button>();
		Button.onClick.AddListener (OnClickButton);
	}
	
	public void OnClickButton(){
		Debug.Log(id);
	}
}
