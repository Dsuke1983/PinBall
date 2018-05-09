using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperControllerSh : MonoBehaviour {

	// HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	// 初期の傾き
	private float defaultAngle = 20;

	// 弾いた時の傾き
	private float flickAngle = -20;

	// タッチされた座標
	private Vector2 touchPoint;

	// スクリーンのサイズの半分のサイズを取得する
	private int swHalf = Screen.width / 2;

	// Use this for initialization
	void Start () {
		// HingeJoint コンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		// フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}



	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			foreach (Touch t in Input.touches) {
				if (t.phase == TouchPhase.Began && t.position.x < swHalf && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				} else if (t.phase == TouchPhase.Began && t.position.x > swHalf && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				} else if (t.phase == TouchPhase.Stationary && t.position.x < swHalf && tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
				} else if (t.phase == TouchPhase.Stationary && t.position.x > swHalf && tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
				} else if (t.phase == TouchPhase.Ended && t.position.x < swHalf && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (t.phase == TouchPhase.Ended && t.position.x > swHalf && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (t.phase == TouchPhase.Canceled && t.position.x < swHalf && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				} else if (t.phase == TouchPhase.Canceled && t.position.x > swHalf && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}
	

/*
	// 左矢印キーを押した時左フリッパーを動かす
		if ((Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}

		// 右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}

		// 矢印キーが話された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}
*/

	// フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring joinSpr = this.myHingeJoint.spring;
		joinSpr.targetPosition = angle;
		this.myHingeJoint.spring = joinSpr;
	}
}
