using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	[SerializeField] private GameObject ballPrefab;
	[SerializeField] private Transform arrow;
	private Transform tapPoint;
	private float direction;
	const float power = 10f;

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (tapPoint == null) {
				tapPoint = new GameObject().transform;
			}
		}
		if (Input.GetMouseButton(0)) {
			var aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			tapPoint.transform.position = new Vector3(aTapPoint.x, aTapPoint.y, 0);
			arrow.transform.LookAt(tapPoint);
		}
		if (Input.GetMouseButtonUp(0)) {
			StartCoroutine(Shot());
		}
	}

	private IEnumerator Shot () {
		for (var i=0; i<10; i++) {
			var ball = Instantiate(ballPrefab);
			ball.transform.position = transform.position;
			var r = ball.GetComponent<Rigidbody2D>();
			r.velocity = arrow.transform.forward * power;
			yield return new WaitForSeconds(0.1f);
		}
		yield return null;
	}

}
