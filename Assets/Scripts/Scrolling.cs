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
	[BoxGroup("Prefabs"), SerializeField]
	private List<GameObject> prefabs = new List<GameObject>();
	[BoxGroup("Prefabs"), SerializeField]
	private bool isPrefabsRandom = false;

	[BoxGroup("initLocation"), SerializeField]
	private bool isInitYRandom = false;
	[BoxGroup("initLocation"), SerializeField, HideIf("isInitYRandom")]
	private float initY = 0f;
	[BoxGroup("initLocation"), SerializeField, ShowIf("isInitYRandom")]
	private float maxY = 0f;
	[BoxGroup("initLocation"), SerializeField, ShowIf("isInitYRandom")]
	private float minY = 0f;

	private void Start()
	{
		
	}

	private void Update()
	{
		
	}
}
