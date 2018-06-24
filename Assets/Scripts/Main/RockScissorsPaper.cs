using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScissorsPaper : MonoBehaviour {
	static RockScissorsPaper instance;
	public static RockScissorsPaper getInstance () {
		if (instance == null) {
			instance = FindObjectOfType (typeof (RockScissorsPaper)) as RockScissorsPaper;
			if (instance == null) {
				Debug.Log ("RockScissorsPaperのインスタンスがない");
			}
		}
		return instance;
	}

	//player1が自分、2が敵
	//引数 0: グー、1: チョキ、3: パー
	//返り値 0: 引き分け、1: player1負け、2: player1勝ち
	public int Battle (int player1, int player2) {
		int judge = (player1 - player2 + 3) % 3;
		return judge;
	}
}