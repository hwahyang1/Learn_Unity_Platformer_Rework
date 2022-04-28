using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/*
 * [Class] SoundManager
 * 효과음의 재생을 관리합니다.
 */
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
	
	[SerializeField]
	private AudioClip land;
	[SerializeField]
	private AudioClip jump;
	[SerializeField]
	private AudioClip die;
	[SerializeField]
	private AudioClip click;

	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	/*
	 * [Method] PlayLand(): void
	 * 착지 효과음을 재생합니다.
	 */
	public void PlayLand()
	{
		audioSource.PlayOneShot(land);
	}

	/*
	 * [Method] PlayJump(): void
	 * 점프 효과음을 재생합니다.
	 */
	public void PlayJump()
	{
		audioSource.PlayOneShot(jump);
	}

	/*
	 * [Method] PlayDie(): void
	 * 죽는 효과음을 재생합니다.
	 */
	public void PlayDie()
	{
		audioSource.PlayOneShot(die);
	}

	/*
	 * [Method] PlayClick(): void
	 * 버튼 클릭 효과음을 재생합니다.
	 */
	public void PlayClick()
	{
		audioSource.PlayOneShot(click);
	}
}
