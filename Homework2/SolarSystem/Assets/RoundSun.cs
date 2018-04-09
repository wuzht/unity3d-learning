using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSun : MonoBehaviour {
	
	public Transform sun;
	public Transform moon;
	public Transform mercury;//水星
	public Transform venus;//金星
	public Transform earth;//地球
	public Transform mars;//火星
	public Transform jupiter;//木星
	public Transform saturn;//土星
	public Transform uranus;//天王星
	public Transform neptune;//海王星

	// Use this for initialization
	void Start () {
		sun.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		mercury.RotateAround (sun.position, new Vector3(0, 5, 1), 20 * Time.deltaTime);
		mercury.Rotate ( new Vector3(0, 5, 1) * 5 * Time.deltaTime);

		venus.RotateAround (sun.position, new Vector3(0, 2, 1), 15 * Time.deltaTime);
		venus.Rotate (new Vector3(0, 2, 1) * Time.deltaTime);

		earth.RotateAround (sun.position, Vector3.up, 10 * Time.deltaTime);
		earth.Rotate (Vector3.up * 30 * Time.deltaTime);
		moon.transform.RotateAround (earth.position, Vector3.up, 359 * Time.deltaTime);

		mars.RotateAround (sun.position, new Vector3(0, 12, 5), 9 * Time.deltaTime);
		mars.Rotate (new Vector3(0, 12, 5) * 40 * Time.deltaTime);

		jupiter.RotateAround (sun.position, new Vector3(0, 10, 3), 8 * Time.deltaTime);
		jupiter.Rotate (new Vector3(0, 10, 3) * 30 * Time.deltaTime);

		saturn.RotateAround (sun.position, new Vector3(0, 3, 1), 7 * Time.deltaTime);
		saturn.Rotate (new Vector3(0, 3, 1) * 20 * Time.deltaTime);

		uranus.RotateAround (sun.position, new Vector3(0, 10, 1), 6 * Time.deltaTime);
		uranus.Rotate (new Vector3(0, 10, 1) * 20 * Time.deltaTime);

		neptune.RotateAround (sun.position, new Vector3(0, 8, 1), 5 * Time.deltaTime);
		neptune.Rotate (new Vector3(0, 8, 1) * 30 * Time.deltaTime);
	}
}
