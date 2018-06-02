using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Sequences : MonoBehaviour
{
	[SerializeField]
	private Transform target;

	private void Start()
	{
		var mySequence = DOTween.Sequence();
		mySequence.Append(target.DOMoveY(2, 1));
		//mySequence.Join(target.DORotate(new Vector3(0, 135, 0), 1));
		mySequence.Append(target.DOScaleY(0.2f, 1));
		//mySequence.Insert(0, target.DOMoveX(4, mySequence.Duration()).SetRelative());
		mySequence.SetLoops(4, LoopType.Incremental);
	}
}