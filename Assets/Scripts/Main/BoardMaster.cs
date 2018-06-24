using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoardMaster : MonoBehaviour {
	private PlayerController playercontroller;
	private TextController textcontroller;
	//階段がいくつか定める
	[SerializeField]
	private int StageCount;
	private float finish_point;
	private static int winid;
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
		playercontroller = GetComponent<PlayerController>();
		textcontroller = GameObject.Find ("Instruction").GetComponent<TextController> ();
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
		finish_point = i * 1.5f;
		Instantiate (GoalPrefab, new Vector3 (i * 1.5f, 0.0001f, 0), Quaternion.identity);
		Instantiate (GoalPrefab, new Vector3 (i * 1.5f, 0.0001f, 2), Quaternion.identity);
	}

	public void UpdateGame (int id) {
		textcontroller.setText ("");

		int enemy_move = Random.Range (0, 3);

		Texture2D texture0 = getImage (id);
		Texture2D texture1 = getImage (enemy_move);
		Image img0 = GameObject.Find ("Canvas/player0Image").GetComponent<Image> ();
		img0.sprite = Sprite.Create (texture0, new Rect (0, 0, texture0.width, texture0.height), Vector2.zero);
		Image img1 = GameObject.Find ("Canvas/player1Image").GetComponent<Image> ();
		img1.sprite = Sprite.Create (texture1, new Rect (0, 0, texture0.width, texture0.height), Vector2.zero);

		int judge = RockScissorsPaper.getInstance ().Battle (id, enemy_move);
		switch (judge) {
			//引き分け
			case 0:
				textcontroller.addText ("あいこ\n");
				break;
				//負け
			case 1:
				textcontroller.addText ("負け\n");
				textcontroller.addText (idtostring (enemy_move) + "\n");
				 playercontroller.Move (idtostring (enemy_move).Length, Player1);
				break;
				//勝ち
			case 2:
				textcontroller.addText ("勝ち\n");
				textcontroller.addText (idtostring (id) + "\n");
				playercontroller.Move (idtostring (id).Length, Player0);
				break;
			default:
				Debug.Log ("勝負判定に変な値が入っている");
				break;
		}
	}

	private Texture2D getImage (int id) {
		switch (id) {
			case 0:
				return Resources.Load ("Materials/gu") as Texture2D;
			case 1:
				return Resources.Load ("Materials/choki") as Texture2D;
			default:
				return Resources.Load ("Materials/pa") as Texture2D;
		}
	}

	private string idtostring (int id) {
		switch (id) {
			case 0:
				return "グリコ";
			case 1:
				return "チヨコレイト";
			default:
				return "パイナツプル";
		}
	}

	void Update () {
		if(Player0.transform.localPosition.x > finish_point - 0.5f){
			winid = 0;
			SceneManager.LoadScene("Scenes/End");
		}
		if(Player1.transform.localPosition.x > finish_point - 0.5f){
			winid = 1;
			SceneManager.LoadScene("Scenes/End");
		}
	}

	public static int getwinID(){
		return winid;
	}
}