using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallPoints : MonoBehaviour {

	// ポイントテキスト
	private GameObject pointText;

	// ポイントを設定する
	private int Point = 0;
	private int SmallStarPoint = 10;
	private int LargeStarPoint = 20;
	private int SmallCloudPoint = 30;
	private int LargeCloudPoint = 40;

	// Use this for initialization
	void Start () {
		this.pointText = GameObject.Find ("PointText");
	}
	
	// Update is called once per frame
	void Update () {
		this.pointText.GetComponent<Text> ().text = Point.ToString();
	}

	void OnCollisionEnter(Collision other){

		switch (other.gameObject.tag) {
		case "SmallStarTag":
			Point += SmallStarPoint;
			break;

		case "LargeStarTag":
			Point += LargeStarPoint;
			break;

		case "SmallCloudTag":
			Point += SmallCloudPoint;
			break;

		case "LargeCloudTag":
			Point += LargeCloudPoint;
			break;

		default:
			break;
		}
	}
}
