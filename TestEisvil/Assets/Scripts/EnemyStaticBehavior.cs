using UnityEngine;

public class EnemyStaticBehavior : MonoBehaviour
{
	public GameBehavior gameManager;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			Destroy(this.transform.gameObject);
			gameManager.NotifyStaticEnemyDestroyed();
		}
	}
}
