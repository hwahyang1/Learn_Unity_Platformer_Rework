using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] CactusManager
 * 선인장의 생성, 이동, 제거를 관리합니다.
 */
public class CactusManager : MonoBehaviour
{
	private GameManager gameManager;

	private Scrolling scrolling;

	public List<GameObject> prefabs = new List<GameObject>();

	[ReadOnly]
	private List<GameObject> gameObjects = new List<GameObject>();

	[ReadOnly]
	private float scrollingSpeed = 0f; // Grounds GameObject의 Scrolling.scrollingSpeed를 따릅니다.

	[SerializeField]
	private float spawnDuration = 0f;
	private float nowDuration = 0f;

	[SerializeField]
	private float spawnX = 0f;

	[SerializeField]
	private float spawnY = 0f;

	[SerializeField]
	private float destroyX = 0f;

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
			if (gameObjects[0].transform.position.x <= destroyX)
			{
				Destroy(gameObjects[0]);
				gameObjects.Remove(gameObjects[0]);
			}

			if (nowDuration >= spawnDuration)
			{
				int randomPrefabIndex = Random.Range(0, prefabs.Count + 1);

				if (randomPrefabIndex < prefabs.Count) // prefabs.Count와 같은 경우, 생성하지 않음
				{
					GameObject newSpawnedObject = Instantiate(prefabs[randomPrefabIndex], new Vector3(spawnX, spawnY, 0f), Quaternion.identity, transform);

					gameObjects.Add(newSpawnedObject);
				}

				nowDuration = 0f;
			}
			else
			{
				nowDuration += Time.deltaTime;
			}

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].transform.Translate(new Vector3(scrollingSpeed, 0f, 0f));
			}
		}
	}

	/*
	 * [Method] DestroyAllCactuses(): void
	 * 스폰되어 있는 모든 선인장을 제거합니다.
	 */
	public void DestroyAllCactuses()
	{
		for (int i = gameObjects.Count - 1; i >= 0; i--) // 안전을 위해 역순제거
		{
			Destroy(gameObjects[i]);
			gameObjects.Remove(gameObjects[i]);
		}
	}
}
