using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent NM;
	Transform Player;

	void Start () {
		NM = GetComponent<UnityEngine.AI.NavMeshAgent>();
		Player = GameObject.FindWithTag("Player").transform;
	}
	
	void Update () {
		NM.SetDestination (Player.position);
	}
}