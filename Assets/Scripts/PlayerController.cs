using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] PlayerController
 * 플레이어의 움직임을 제어합니다.
 */
public class PlayerController : MonoBehaviour
{
	private GameManager gameManager;
	private SoundManager soundManager;

	private Animator animator;
	private Rigidbody2D rigidbody2D;

	[ReadOnly]
	private bool isPlayerLanded = true;

	[SerializeField]
	private float jumpPower = 0f;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (gameManager.isPlayerAlive)
		{
			if (isPlayerLanded)
			{
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
				{
					rigidbody2D.AddForce(new Vector2(0f, jumpPower));
				}
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (gameManager.isPlayerAlive)
		{
			if (collision.gameObject.name == "Ground Collider")
			{
				soundManager.PlayLand();

				animator.SetBool("Jump", false);
				isPlayerLanded = true;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (gameManager.isPlayerAlive)
		{
			if (collision.gameObject.name == "Ground Collider")
			{
				soundManager.PlayJump();

				animator.SetBool("Jump", true);
				isPlayerLanded = false;
			}
		}
	}
}
