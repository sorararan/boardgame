using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//countだけ進む
	public void Move (int count, GameObject player) {
		StartCoroutine (move (count, player));
	}

	private IEnumerator move (int count, GameObject player) {
		for (int i = 0; i < count; i++) {
			Vector3 pos = player.transform.position;
			pos.x += 1.5f;
			player.transform.position = pos;
			yield return new WaitForSeconds(0.5f);
		}
	}
}