using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardMaster : MonoBehaviour {
	TextController textcontroller;
	//階段がいくつか定める
	[SerializeField]
	private int StageCount;
	//Prefabs
	private GameObject Player0Prefab, Player1Prefab;
	private GameObject StartPrefab, StagePrefab, GoalPrefab;

	//プレイヤのクローン
	private GameObject Player0, Player1;

	static BoardMaster instance;
	public static BoardMaster getInstance () {
		if (instance == null) {
			instance = FindObjectOfType (typeof (BoardMaster)) as BoardMaster;
			if (instance == null) {
				Debug.Log ("BoardMasterのインスタンスがない");
			}
		}
		return instance;
	}

	// Use this for initialization
	void Start () {
		textcontroller = GameObject.Find("Instruction").GetComponent<TextController>();
		Player0Prefab = (GameObject) Resources.Load ("Prefabs/Player0");
		Player1Prefab = (GameObject) Resources.Load ("Prefabs/Player1");
		StartPrefab = (GameObject) Resources.Load ("Prefabs/Start");
		StagePrefab = (GameObject) Resources.Load ("Prefabs/Stage");
		GoalPrefab = (GameObject) Resources.Load ("Prefabs/Goal");
		Player0 = Instantiate (Player0Prefab, new Vector3 (0, 0.5f, 0), Quaternion.identity);
		Player1 = Instantiate (Player1Prefab, new Vector3 (0, 0.5f, 2), Quaternion.identity);
		Instantiate (StartPrefab, new Vector3 (0, 0.0001f, 0), Quaternion.identity);
		Instantiate (StartPrefab, new Vector3 (0, 0.0001f, 2), Quaternion.identity);
		//i=1なのはゴールを入れるとStageCountの数になるから
		int i;
		for (i = 1; i < StageCount; i++) {
			Instantiate (StagePrefab, new Vector3 (i * 1.5f, 0.0001f, 0), Quaternion.identity);
			Instantiate (StagePrefab, new Vector3 (i * 1.5f, 0.0001f, 2), Quaternion.identity);
		}
		Instantiate (GoalPrefab, new Vector3 (i * 1.5f, 0.0001f, 0), Quaternion.identity);
		Instantiate (GoalPrefab, new Vector3 (i * 1.5f, 0.0001f, 2), Quaternion.identity);
	}

	public void UpdateGame (int id) {
		
		int enemy_move = Random.Range (0, 3);
		
		Texture2D texture0 = getImage(id);
		Texture2D texture1 = getImage(enemy_move);
		Image img0 = GameObject.Find("Canvas/player0Image").GetComponent<Image>();
		img0.sprite = Sprite.Create(texture0, new Rect(0, 0, texture0.width, texture0.height), Vector2.zero);
		Image img1 = GameObject.Find("Canvas/player1Image").GetComponent<Image>();
		img1.sprite = Sprite.Create(texture1, new Rect(0, 0, texture0.width, texture0.height), Vector2.zero);
		
		int judge = RockScissorsPaper.getInstance ().Battle (id, enemy_move);
		switch (judge) {
			//引き分け
			case 0:
				textcontroller.addText("あいこ\n");
				break;
				//負け
			case 1:
				textcontroller.addText("負け\n");
				break;
				//勝ち
			case 2:
				textcontroller.addText("勝ち\n");
				break;
			default:
				Debug.Log ("勝負判定に変な値が入っている");
				break;
		}
	}

	private Texture2D getImage(int id){
		switch(id){
			case 0:
				return Resources.Load("Materials/gu") as Texture2D;
			case 1:
				return Resources.Load("Materials/choki") as Texture2D;
			case 2:
				return Resources.Load("Materials/pa") as Texture2D;
		}
		
		//ここへたどり着くとエラー
		Debug.Log("画像読み込みエラー")
		return Resources.Load("Materials/pa") as Texture2D;
	}
}