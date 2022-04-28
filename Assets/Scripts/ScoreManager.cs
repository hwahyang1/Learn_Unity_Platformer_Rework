using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/*
 * [Class] ScoreManager
 * 플레이어의 점수를 관리합니다.
 */
public class ScoreManager : MonoBehaviour
{
	private GameManager gameManager;
	private SoundManager soundManager;

	[SerializeField]
	private Text highScoreText;
	[SerializeField]
	private Text currentScoreText;

	private int _highScore = 0;
	public int highScore
	{
		get { return _highScore; }
		private set { _highScore = value; }
	}
	private int currentScore = 0;
	[SerializeField]
	private int defaultScore = 0;

	[SerializeField]
	private float scoreDuration = 0f;
	private float nowDuration = 0f;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

		highScore = PlayerPrefs.GetInt(gameManager.highScoreKey, 0);
	}

	private void Update()
	{
		highScoreText.text = highScore + "";
		currentScoreText.text = currentScore + "";
	}

	private void FixedUpdate()
	{
		if (gameManager.isPlayerAlive)
		{
			if (nowDuration >= scoreDuration)
			{
				currentScore += defaultScore;

				nowDuration = 0f;
			}
			else
			{
				nowDuration += Time.deltaTime;
			}

			if (currentScore >= highScore)
			{
				highScore = currentScore;
			}
		}
	}

	/*
	 * [Method] ResetScore(bool resetHighScore=false): void
	 * 현재 점수와 최고 점수(저장된 점수 포함)을 0점으로 초기화 시킵니다.
	 * 
	 * <bool resetHighScore=false>
	 * 최고 점수(저장된 점수 포함)을 초기화 시킬지 결정합니다.
	 * true이면 최고점수(저장된 점수 포함)을 같이 초기화합니다.
	 * false이면 현재 점수만 초기화합니다.
	 */
	public void ResetScore(bool resetHighScore=false)
	{
		soundManager.PlayClick();

		currentScore = 0;

		if (resetHighScore)
		{
			highScore = 0;
			PlayerPrefs.SetInt(gameManager.highScoreKey, 0);
		}

		highScoreText.text = highScore + "";
		currentScoreText.text = currentScore + "";
	}
}
