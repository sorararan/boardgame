using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartText : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		//表示するテキスト
		text = GetComponent<Text>();
		text.text = "グリコゲーム\nエンターを押してスタート\n";
	}

	void Update()
	{
		//エンターキーでゲーム画面へ
		if(Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene("Scenes/Main");
		}
	}
}
