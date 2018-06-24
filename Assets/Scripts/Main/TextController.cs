using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour {
	private Text text;
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text>();
		text.text = "じゃんけーん\n";
	}

	public void setText(string txt){
		text.text = txt;
	}

	public void addText(string txt){
		text.text += txt;
	}
}
