using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Class] Cactus
 * 선인장의 충돌 이벤트를 관리합니다.
 */
public class Cactus : MonoBehaviour
{
	private PlayerController playerController;

	private void Start()
	{
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		playerController.isPlayerDead = true;

	}
}
