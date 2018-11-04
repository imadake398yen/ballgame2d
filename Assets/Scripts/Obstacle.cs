using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour {

	[SerializeField] Text label;
	private int life;

	private void Start () {
		life = Random.Range(1, 10);
		label.text = life.ToString();
	}

	private void OnCollisionEnter2D (Collision2D other) {
		var ball = other.gameObject.GetComponent<Ball>();
		if (ball != null) {
			life -= 1;
			label.text = life.ToString();
			if (life == 0) Destroy(gameObject);
		}
	}

}
