using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public QuestManager questManager;

	private void Awake()
	{
		questManager = FindObjectOfType<QuestManager>();
	}

	public void NotifyStaticEnemyDestroyed()
	{
		questManager.AddStaticEnemyDestroyed();
	}

	public void NotifyMobileEnemyDestroyed()
	{
		questManager.AddMobileEnemyDestroyed();
	}
}
