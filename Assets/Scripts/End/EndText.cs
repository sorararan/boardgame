using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndText : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		//表示するテキスト
		text = GetComponent<Text>();
		string win;
		if(BoardMaster.getwinID() == 0){
			win = "勝ち";
		}else{
			win = "負け";
		}
		text.text = "あなたの" + win + "です。\nエンターを押して再スタート\n";
		//画像の表示
		Texture2D texture0 = Resources.Load("Materials/guriko") as Texture2D;
		Image img = GameObject.Find ("Canvas/Image").GetComponent<Image> ();
		img.sprite = Sprite.Create (texture0, new Rect (0, 0, texture0.width, texture0.height), Vector2.zero);
	}

	void Update()
	{
		//エンターキーでスタート画面へ
		if(Input.GetKeyDown(KeyCode.Return)){
			SceneManager.LoadScene("Scenes/Main");
		}
	}
}
