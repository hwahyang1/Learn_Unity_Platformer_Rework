using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] Scrolling
 * GameObject의 생성, 이동, 제거를 관리합니다.
 */
public class Scrolling : MonoBehaviour
{
	private GameManager gameManager;

	[SerializeField]
	private List<GameObject> prefabs = new List<GameObject>();

	[SerializeField]
	private List<GameObject> gameObjects = new List<GameObject>();

	public float scrollingSpeed = 0f;

	[SerializeField]
	private bool spawnXWithFixedLocation = true;
	[SerializeField, ShowIf("spawnXWithFixedLocation")]
	private float spawnX = 0f;
	[SerializeField, HideIf("spawnXWithFixedLocation")]
	private float distanceX = 0f;


	[SerializeField]
	private bool spawnYWithRandomLocation = false;
	[SerializeField, ShowIf("spawnYWithRandomLocation")]
	private float spawnMaxY = 0f;
	[SerializeField, ShowIf("spawnYWithRandomLocation")]
	private float spawnMinY = 0f;
	[SerializeField, HideIf("spawnYWithRandomLocation")]
	private float spawnY = 0f;

	[SerializeField]
	private float destroyX = 0f;

	private void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	private void FixedUpdate()
	{
		if (gameManager.isPlayerAlive)
		{
			if (gameObjects[0].transform.position.x <= destroyX)
			{
				Destroy(gameObjects[0]);
				gameObjects.Remove(gameObjects[0]);

				float newX = gameObjects[gameObjects.Count - 1].transform.position.x + distanceX;
				if (spawnXWithFixedLocation) newX = spawnX;

				float newY = spawnY;
				if (spawnYWithRandomLocation) newY = Random.Range(spawnMinY, spawnMaxY);

				int randomPrefabIndex = Random.Range(0, prefabs.Count);

				GameObject newSpawnedObject = Instantiate(prefabs[randomPrefabIndex], new Vector3(newX, newY, 0f), Quaternion.identity, transform);

				gameObjects.Add(newSpawnedObject);
			}

			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].transform.Translate(new Vector3(scrollingSpeed, 0f, 0f));
			}
		}
	}
}
