using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	//0: グー、1: チョキ、2: パー
	[SerializeField]
	private int id;
	private Button button;

	// Use this for initialization
	void Start () {
		button = this.GetComponent<Button> ();
		button.onClick.AddListener (OnClickButton);
	}

	public void OnClickButton () {
		//プレイヤが動いていないときだけボタンを押せる
		if (!BoardMaster.is_moving) {
			BoardMaster.getInstance ().UpdateGame (id);
		}
	}
}