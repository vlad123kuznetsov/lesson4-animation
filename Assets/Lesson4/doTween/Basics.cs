using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Basics : MonoBehaviour
{
	public Transform cubeA, cubeB;

	private void Start()
	{
		DOTween.Init(false, true, LogBehaviour.ErrorsOnly);

		//SHORTCUTS WAY
		cubeA.DOMove(new Vector3(-2, 2, 0), 1).SetRelative().SetLoops(-1, LoopType.Yoyo);

		//GENERIC WAY
		DOTween.To(() => cubeB.position, x => cubeB.position = x, new Vector3(-2, 2, 0), 1).SetRelative().SetLoops(-1, LoopType.Yoyo);
	}
}