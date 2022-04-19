using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using NaughtyAttributes;

/*
 * [Class] Scrolling
 * 물체의 이동과 제거, 재생성을 관리합니다.
 */
public class Scrolling : MonoBehaviour
{
	private PlayerController playerController;

	[BoxGroup("Prefabs"), SerializeField]
	private List<GameObject> prefabs = new List<GameObject>();
	[BoxGroup("Prefabs"), SerializeField]
	private bool isPrefabsRandom = false;

	[BoxGroup("InitLocation"), SerializeField]
	private bool isInitXFixed = false;
	[BoxGroup("InitLocation"), SerializeField, HideIf("isInitXFixed")]
	private float distanceX = 0f;
	[BoxGroup("InitLocation"), SerializeField, ShowIf("isInitXFixed")]
	private float initX = 0f;
	[BoxGroup("InitLocation"), SerializeField]
	private bool isInitYRandom = false;
	[BoxGroup("InitLocation"), SerializeField, HideIf("isInitYRandom")]
	private float initY = 0f;
	[BoxGroup("InitLocation"), SerializeField, ShowIf("isInitYRandom")]
	private float maxY = 0f;
	[BoxGroup("InitLocation"), SerializeField, ShowIf("isInitYRandom")]
	private float minY = 0f;

	[BoxGroup("Scolling"), SerializeField]
	private List<GameObject> objects = new List<GameObject>();
	[BoxGroup("Scolling"), SerializeField]
	private float scrollingSpeed = 0f;

	[BoxGroup("DestroyLocation"), SerializeField]
	private float destroyX = 0f;

	private void Start()
	{
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	private void FixedUpdate()
	{
		if (playerController.isPlayerDead) return;

		if (objects[0].transform.position.x <= destroyX)
		{
			Destroy(objects[0]);
			objects.Remove(objects[0]);

			int prefabIndex = 0;
			float X = initX;
			float Y = initY;

			if (isPrefabsRandom)
			{
				prefabIndex = Random.Range(0, prefabs.Count);
			}
			if (!isInitXFixed)
			{
				X = objects[objects.Count - 1].transform.position.x + distanceX;
			}
			if (isInitYRandom)
			{
				Y = Random.Range(minY, maxY);
			}

			GameObject spawnedObject = Instantiate(prefabs[prefabIndex], new Vector3(X, Y, 0), Quaternion.identity, transform);
			objects.Add(spawnedObject);
		}

		for (int i=0; i < objects.Count; i++)
		{
			objects[i].transform.Translate(new Vector3(-scrollingSpeed, 0f, 0f));
		}
	}
}
