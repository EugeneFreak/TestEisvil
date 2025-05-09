using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public TMP_Text firstQuestText;
    public TMP_Text secondQuestText;
    public TMP_Text thirdQuestText;

    private int _countDestoyedobjects = 10;
    private int _allEnemies = 0;
    private int _enemyStaticDestroyed = 0;
	private int _enemyMobileDestroyed = 0;
	private float _countdownTimer = 5;

    public int AllEnemies
    {
        get { return _allEnemies; }
        set { _allEnemies = value;
			Debug.LogFormat($"All enemy destroyed: {_allEnemies}");
		}
    }

    public int EnemyStaticDestroyed
    {
        get { return _enemyStaticDestroyed; }
        set
        {
            _enemyStaticDestroyed = value;
            Debug.LogFormat($"Static enemy destroyed: {_enemyStaticDestroyed}");
        }
    }

    public int EnemyMobileDestroyed
    {
        get { return _enemyMobileDestroyed; }
        set
        {
            _enemyMobileDestroyed = value;
            Debug.LogFormat($"Mobile enemy destroyed: {_enemyMobileDestroyed}");
        }
    }

	private void Update()
	{
        if (_countdownTimer > 0)
        {
            _countdownTimer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(_countdownTimer / 60);
            float seconds = Mathf.FloorToInt(_countdownTimer % 60);
            firstQuestText.text = string.Format("Stay in the game for {0:00}:{1:00}" , minutes, seconds);
        }
        else
        {
            firstQuestText.text = "Stay in the game: FINISHED";
            _countdownTimer = 0;
            firstQuestText.color = Color.green;
        }

        if (_enemyStaticDestroyed >= _countDestoyedobjects)
        {
            secondQuestText.text = "You destroyed 10 static enemy!";
            secondQuestText.color = Color.green;
        }
        else
        {
            secondQuestText.text = string.Format($"You need destroy 10 static enemies\t {_enemyStaticDestroyed} / {_countDestoyedobjects}");
        }

        if (_allEnemies >= 10)
        {
            thirdQuestText.text = "You destroyed 10 all enemies ";
            thirdQuestText.color = Color.green;
        }
        else
        {
            thirdQuestText.text = string.Format($"You need destroy any enmies\t {_allEnemies}/ {_countDestoyedobjects}");
        }
	}
}
