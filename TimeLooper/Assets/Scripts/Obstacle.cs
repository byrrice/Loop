using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
	public enum MyEnum
	{
		Up,
		Down,
		Left,
		Right
	}
	public MyEnum Direction;
	[SerializeField] private bool enabled = true;
	private Vector3 startScale;
	private Vector3 startPos;
	// Use this for initialization
	private bool anim = false;
	private int upCoef = 1;
	private int leftCoef = 0;
	[SerializeField] private float animSpeed = .1f;
	private float posMove =   (3.75f) / 2;
	void Start () {
		posMove = animSpeed * posMove;
		startScale = transform.localScale;
		startPos = transform.localPosition;
		if(enabled == false)
		{
			transform.localScale = new Vector3 (transform.localScale.x, 0, transform.localScale.z);
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y - ((10 * posMove) * (1 - startPos.y)), transform.localPosition.z); // to move the object down with the animation, keep it centered
		}
		if (Direction == MyEnum.Up) {
			upCoef = 1;
			leftCoef = 0;
		}
		if (Direction == MyEnum.Down) {
			upCoef = -1;
			leftCoef = 0;
		}
		if (Direction == MyEnum.Left) {
			upCoef = 0;
			leftCoef = -1;
		}
		if (Direction == MyEnum.Right) {
			upCoef = 0;
			leftCoef = 1;
		}	

	}

	// Update is called once per frame
	void Update () {
		if (anim) {
			if (enabled) {
				if (transform.localScale.y > 0) {
					transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - animSpeed, transform.localScale.z);
					transform.localPosition = new Vector3 (transform.localPosition.x - (leftCoef * (posMove)), transform.localPosition.y - (upCoef * (posMove)), transform.localPosition.z);
				} else {
					transform.localScale = new Vector3 (transform.localScale.x, 0, transform.localScale.z);
					transform.localPosition = new Vector3 (transform.localPosition.x - (leftCoef * ((10 * posMove) * (1 - startPos.x))), transform.localPosition.y - (upCoef * ((10 * posMove) * (1 - startPos.y))), transform.localPosition.z);
				}
			} else {
				if (transform.localScale.y < startScale.y) {
					transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + animSpeed, transform.localScale.z);
					transform.localPosition = new Vector3 (transform.localPosition.x + (leftCoef * posMove), transform.localPosition.y + (upCoef * posMove), transform.localPosition.z);
				} else {
					transform.localScale = new Vector3 (transform.localScale.x, startScale.y, transform.localScale.z);
					transform.localPosition = new Vector3 (startPos.x, startPos.y, transform.localPosition.z);
				}
			}
		} else {
			if (enabled == false) {
				if (transform.localScale.y > 0) {
					transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y - animSpeed, transform.localScale.z);
					transform.localPosition = new Vector3 (transform.localPosition.x - (leftCoef * (posMove)), transform.localPosition.y - (upCoef * (posMove)), transform.localPosition.z);
				} else {
					transform.localScale = new Vector3 (transform.localScale.x, 0, transform.localScale.z);
					transform.localPosition = new Vector3 (transform.localPosition.x - (leftCoef * ((10 * posMove) * (1 - startPos.x))), transform.localPosition.y - (upCoef * ((10 * posMove) * (1 - startPos.y))), transform.localPosition.z);
				}
			} else {
				if (transform.localScale.y < startScale.y) {
					transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y + animSpeed, transform.localScale.z);
					transform.localPosition = new Vector3 (transform.localPosition.x + (leftCoef * posMove), transform.localPosition.y + (upCoef * posMove), transform.localPosition.z);
				} else {
					transform.localScale = new Vector3 (transform.localScale.x, startScale.y, transform.localScale.z);
					transform.localPosition = new Vector3 (startPos.x, startPos.y, transform.localPosition.z);
				}
			}
		}

	}
	public void Press()
	{
		//        if (enabled)
		//            transform.localScale = Vector3.zero;
		//        else
		//            transform.localScale = startScale;
		anim = true;
		Debug.Log("Pressed");
	}
	public void Release()
	{
		//        if (enabled)
		//            transform.localScale = startScale;
		//        else
		//            transform.localScale = Vector3.zero;
		anim = false;
		Debug.Log("Released");
	}
}
