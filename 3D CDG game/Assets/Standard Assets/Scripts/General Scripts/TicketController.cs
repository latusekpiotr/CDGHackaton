using UnityEngine;
using System.Collections;

public class TicketController : MonoBehaviour {
	private float moveRandomFactor = 2f;
	private float positionRandomFactor = 5f;

	// Use this for initialization
	void Awake () {
		transform.position = new Vector3(positionRandomFactor * Random.Range(-10, 10), transform.localPosition.y, positionRandomFactor * Random.Range(-10, 10));
		rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        transform.rotation = Quaternion.Euler(270, Random.Range(0, 359), 90);
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 velo = rigidbody.velocity;
		//velo += new Vector3(moveRandomFactor * Random.Range(-10, 10), 0, moveRandomFactor * Random.Range(-10, 10));
		//velo *= Time.deltaTime;
        //rigidbody.velocity = velo;
	}
}
