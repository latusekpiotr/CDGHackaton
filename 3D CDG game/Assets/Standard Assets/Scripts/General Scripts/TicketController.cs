using UnityEngine;
using System.Collections;

public class TicketController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        rigidbody.velocity = new Vector3(Random.Range(1, 2), Random.Range(1, 2), 0);
        transform.rotation = Quaternion.Euler(270, Random.Range(0, 359), 90);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 velo = rigidbody.velocity;
        velo += new Vector3(0.1f * Random.Range(-1, 1), 0.1f * Random.Range(-1, 1), 0);
        rigidbody.velocity = velo;
	}
}
