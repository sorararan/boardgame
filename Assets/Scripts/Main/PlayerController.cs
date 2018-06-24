using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	private TextController textcontroller;

	void Start()
	{
		textcontroller = GameObject.Find ("Instruction").GetComponent<TextController> ();
	}

	//countだけ進む
	public void Move (int count, GameObject player) {
		StartCoroutine (move (count, player));
	}

	private IEnumerator move (int count, GameObject player) {
		BoardMaster.is_moving = true;
		int dir = 1;
		for (int i = 0; i < count; i++) {
			if (player.transform.position.x > BoardMaster.getInstance ().getfinishPoint () - 0.5f) {
				dir = -1;
			}
			Vector3 pos = player.transform.position;
			pos.x += dir * 1.5f;
			player.transform.position = pos;
			if (player.gameObject.tag == "0") {
				GameObject.Find ("Main Camera").transform.position = new Vector3 (player.transform.position.x + 15, 25.5f, -6);
			}
			yield return new WaitForSeconds (0.5f);
		}
		if (player.transform.position.x == BoardMaster.BackStage * 1.5f) {
			Vector3 pos = player.transform.position;
			pos.x = 0;
			player.transform.position = pos;
			if (player.gameObject.tag == "0") {
				GameObject.Find ("Main Camera").transform.position = new Vector3 (player.transform.position.x + 15, 25.5f, -6);
			}
		}
		if (player.transform.position.x > BoardMaster.getInstance ().getfinishPoint () - 0.5f) {
			BoardMaster.getInstance ().finish ();
		}
		textcontroller.addText("finish move\n");
		BoardMaster.is_moving = false;
	}
}