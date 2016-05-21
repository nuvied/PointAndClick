using System;
using UnityEngine;
using DG.Tweening;


public class MoveTo:Interaction
{
	public enum MoveType
	{
		MoveTo,
		RotateTo,
		ScaleTo,
		CopyMarker
	}

	public MoveType moveType;
	public Marker marker;
	public Transform target;
	public float time;


	public override void Interact ()
	{
		if (moveType == MoveType.MoveTo)
			target.DOMove (marker.position, time);
		else if (moveType == MoveType.RotateTo)
				target.DORotate (marker.rotation, time);
			else if (moveType == MoveType.ScaleTo)
					target.DOScale (marker.scale, time);
				else if (moveType == MoveType.CopyMarker)
					{
						target.DOMove (marker.position, time);
						target.DORotate (marker.rotation, time);
						target.DOScale (marker.scale, time);
					}

	}

}


