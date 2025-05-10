using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
	public TMP_Text firstQuestText;
	public TMP_Text secondQuestText;
	public TMP_Text thirdQuestText;

	private float _countdownTimer = 120;
	private const int _countDestoyedObjectsForStatic = 10;
	private const int _countDestoyedObjectsForTotal = 10;
	private int _currentEnemyStaticDestroyed = 0;
	private int _currentEnemyMobileDestroyed = 0;
	private int _curentTotalEnemyDestroyed = 0;

    void Update()
    {
        UpdateFirstQuest();
		UpdateSecondQuest();
		UpdateThirdQuest();
    }

	private void UpdateFirstQuest()
	{
		if (_countdownTimer > 0)
		{
			_countdownTimer -= Time.deltaTime;
			float minutes = Mathf.FloorToInt(_countdownTimer / 60);
			float seconds = Mathf.FloorToInt(_countdownTimer % 60);
			firstQuestText.text = string.Format("Stay in the game for {0:00}:{1:00}", minutes, seconds);
		}
		else
		{
			firstQuestText.text = "Stay in the game: FINISHED";
			_countdownTimer = 0;
			firstQuestText.color = Color.green;
		}
	}

	private void UpdateSecondQuest() 
	{
		if (_currentEnemyStaticDestroyed >= _countDestoyedObjectsForStatic)
		{
			secondQuestText.text = "You destroyed 10 static enemy!";
			secondQuestText.color = Color.green;
		}
		else
		{
			secondQuestText.text = string.Format($"You need destroy 10 static enemies\t {_currentEnemyStaticDestroyed} / {_countDestoyedObjectsForStatic}");
		}
	}
	private void UpdateThirdQuest() 
	{
		if (_curentTotalEnemyDestroyed >= _countDestoyedObjectsForTotal)
		{
			thirdQuestText.text = "You destroyed 10 all enemies ";
			thirdQuestText.color = Color.green;
		}
		else
		{
			thirdQuestText.text = string.Format($"You need destroy any enmies\t {_curentTotalEnemyDestroyed}/ {_countDestoyedObjectsForTotal}");
		}
	}

	public void AddStaticEnemyDestroyed()
	{
		_currentEnemyStaticDestroyed++;
		_curentTotalEnemyDestroyed++;
	}
	public void AddMobileEnemyDestroyed()
	{
		_currentEnemyMobileDestroyed++;
		_curentTotalEnemyDestroyed++;
	}

}
