using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Class] GameManager
 * 게임의 전반적 실행과 점수를 관리합니다.
 */
public class GameManager : MonoBehaviour
{
	private PlayerController playerController;
	private GameObject gameOver;

	private void Start()
	{
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
		gameOver = GameObject.Find("GameOver");

		gameOver.SetActive(false);
	}

	private void Update()
	{
		
	}
}
