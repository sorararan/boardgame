using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMaster : MonoBehaviour {
	[SerializeField]
	private int StageCount;
	private GameObject Player1Prefab, Player2Prefab;
	private GameObject StartPrefab, StagePrefab, GoalPrefab;
	// Use this for initialization
	void Start () {
		Player1Prefab = (GameObject)Resources.Load("Prefabs/Player1");
		Player2Prefab = (GameObject)Resources.Load("Prefabs/Player2");
		StartPrefab = (GameObject)Resources.Load("Prefabs/Start");
		StagePrefab = (GameObject)Resources.Load("Prefabs/Stage");
		GoalPrefab = (GameObject)Resources.Load("Prefabs/Goal");
		Instantiate(Player1Prefab, new Vector3(0, 0.5f, 0), Quaternion.identity);
		Instantiate(Player2Prefab, new Vector3(0, 0.5f, 2), Quaternion.identity);
		Instantiate(StartPrefab, new Vector3(0, 0.0001f, 0), Quaternion.identity);
		Instantiate(StartPrefab, new Vector3(0, 0.0001f, 2), Quaternion.identity);
		int i = 0;
		for(i = 0; i < StageCount; i++){
			Instantiate(StagePrefab, new Vector3(1.5f + i * 1.5f, 0.0001f, 0), Quaternion.identity);
			Instantiate(StagePrefab, new Vector3(1.5f + i * 1.5f, 0.0001f, 2), Quaternion.identity);
		}
		Instantiate(GoalPrefab, new Vector3(1.5f + i * 1.5f, 0.0001f, 0), Quaternion.identity);
		Instantiate(GoalPrefab, new Vector3(1.5f + i * 1.5f, 0.0001f, 2), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
