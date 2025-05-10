using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMobileBehavior : MonoBehaviour
{
	public GameBehavior gameManager;
	public Transform patrolRoute;
	public List<Transform> locations;

	private int _locationIndex = 0;
	private NavMeshAgent agent;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();

		InitializePatrolRoute();
		gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
		MoveToNextLocation();
	}

	private void Update()
	{
		if(agent.remainingDistance < 3f && !agent.pathPending)
		{
			MoveToNextLocation();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Destroy(this.transform.gameObject);
			gameManager.NotifyMobileEnemyDestroyed();
		}
	}

	void InitializePatrolRoute()
	{
		foreach (Transform child in patrolRoute)
		{
			locations.Add(child);
		}
	}

	void MoveToNextLocation()
	{
		if (locations.Count == 0)
		{
			return;
		}
		agent.destination = locations[_locationIndex].position;
		_locationIndex = (_locationIndex + 1) % locations.Count;
	}
}
