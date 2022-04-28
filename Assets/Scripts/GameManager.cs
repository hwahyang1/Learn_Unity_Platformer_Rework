using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] GameManager
 * 게임의 전반적인 실행을 관리합니다.
 */
public class GameManager : MonoBehaviour
{
	private SoundManager soundManager;
	private ScoreManager scoreManager;

	[SerializeField]
	private GameObject groundCollider;
	[SerializeField]
	private GameObject gameOver;

	private GameObject player;
	private Rigidbody2D rigidbody2D;
	private Animator animator;

	[HideInInspector]
	public readonly string highScoreKey = "HighScore";

	[ReadOnly]
	public bool isPlayerAlive = true;

	private bool onceDieAnimationPlayed = false; // 죽는 애니메이션 + 효과음 + Force 적용 여부

	private void Start()
	{
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

		player = GameObject.FindGameObjectWithTag("Player");
		rigidbody2D = player.GetComponent<Rigidbody2D>();
		animator = player.GetComponent<Animator>();

		gameOver.SetActive(false);
	}

	private void Update()
	{
		if (isPlayerAlive)
		{

		}
		else
		{
			if (!onceDieAnimationPlayed)
			{
				if (scoreManager.highScore > PlayerPrefs.GetInt(highScoreKey, 0))
				{
					PlayerPrefs.SetInt(highScoreKey, scoreManager.highScore);
					PlayerPrefs.Save();
				}

				gameOver.SetActive(true);
				groundCollider.SetActive(false);

				soundManager.PlayDie();

				animator.SetBool("Die", true);
				rigidbody2D.velocity = new Vector2(0f, 0f);
				rigidbody2D.AddForce(new Vector2(0f, 500f));

				onceDieAnimationPlayed = true;
			}
		}
	}

	public void OnRestartButtonClicked()
	{
		soundManager.PlayClick();

		GameObject[] cactuses = GameObject.FindGameObjectsWithTag("Cactus");
		foreach (GameObject obj in cactuses)
		{
			Destroy(obj);
		}

		scoreManager.ResetScore(false);

		gameOver.SetActive(false);
		groundCollider.SetActive(true);

		animator.SetBool("Die", false);
		rigidbody2D.velocity = new Vector2(0f, 0f);

		isPlayerAlive = true;
		onceDieAnimationPlayed = false;

		player.transform.position = new Vector3(player.transform.position.x, -1.5f, 0f);
	}
}
