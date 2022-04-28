using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] Cactus
 * 선인장의 이동과 제거, 충돌을 관리합니다.
 */
public class Cactus : MonoBehaviour
{
	private GameManager gameManager;

	private CactusManager cactusManager;

	// 아래의 변수들은 모두 CactusManager의 설정을 따릅니다.

	[ReadOnly]
	private float scrollingSpeed;

	[ReadOnly]
	private float destroyX;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

		cactusManager = transform.parent.GetComponent<CactusManager>();
	}

	private void FixedUpdate()
	{
		scrollingSpeed = cactusManager.scrollingSpeed;
		destroyX = cactusManager.destroyX;

		if (gameManager.isPlayerAlive)
		{
			if (transform.position.x <= destroyX)
			{
				Destroy(gameObject);
			}

			transform.Translate(new Vector3(scrollingSpeed, 0f, 0f));
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			gameManager.isPlayerAlive = false;
		}
	}
}
