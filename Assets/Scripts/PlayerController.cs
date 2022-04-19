using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] PlayerController
 * 플레이어의 움직임과 상태를 관리합니다.
 */
public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rigidbody;
	private Animator animator;

	[ReadOnly]
	public bool isPlayerDead = false;

	[SerializeField]
	private float jumpPower = 0f;

	private bool isPlayerLanded = true;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (isPlayerDead)
		{
			animator.SetTrigger("Die");
			return;
		}

		if (isPlayerLanded)
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				isPlayerLanded = false;
				rigidbody.AddForce(new Vector2(0f, jumpPower));
				animator.SetBool("Jump", true);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isPlayerDead) return;

		if (collision.gameObject.name.Contains("Ground"))
		{
			animator.SetBool("Jump", false);
			isPlayerLanded = true;
		}
	}
}
