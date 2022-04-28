using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] CactusManager
 * 선인장의 생성을 관리합니다.
 */
public class CactusManager : MonoBehaviour
{
	private GameManager gameManager;

	private Scrolling scrolling;

	public List<GameObject> prefabs = new List<GameObject>();

	[ReadOnly]
	private float _scrollingSpeed = 0f; // Grounds GameObject의 Scrolling.scrollingSpeed를 따릅니다.
	public float scrollingSpeed
	{
		get { return _scrollingSpeed; }
		private set { _scrollingSpeed = value; }
	}

	[SerializeField]
	private float spawnDuration = 0f;
	private float nowDuration = 0f;

	[SerializeField]
	private float spawnX = 0f;

	[SerializeField]
	private float spawnY = 0f;

	[SerializeField]
	private float _destroyX = 0f;
	public float destroyX
	{
		get { return _destroyX; }
		private set { _destroyX = value; }
	}

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

		scrolling = GameObject.Find("Grounds").GetComponent<Scrolling>();
	}

	private void FixedUpdate()
	{
		scrollingSpeed = scrolling.scrollingSpeed;

		if (gameManager.isPlayerAlive)
		{
			if (nowDuration >= spawnDuration)
			{
				int randomPrefabIndex = Random.Range(0, prefabs.Count + 1);

				if (randomPrefabIndex < prefabs.Count) // prefabs.Count와 같은 경우, 생성하지 않음
				{
					Instantiate(prefabs[randomPrefabIndex], new Vector3(spawnX, spawnY, 0f), Quaternion.identity, transform);
				}

				nowDuration = 0f;
			}
			else
			{
				nowDuration += Time.deltaTime;
			}
		}
	}
}
