using UnityEngine;
using System.Collections;

public class TicketController : MonoBehaviour {
	private float moveRandomFactor = 2f;
	private float positionRandomFactor = 5f;
	public float maxRadius = 50f;
	public float maxDueTime = 120f;
	
	private Score score;				// Reference to the Score script.
	private float t;
	
	void Awake () {
		transform.position = new Vector3(positionRandomFactor * Random.Range(-10, 10), transform.localPosition.y, positionRandomFactor * Random.Range(-10, 10));
		rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        transform.rotation = Quaternion.Euler(270, Random.Range(0, 359), 90);

		score = GameObject.Find("Score").GetComponent<Score>();
		t = Time.time;
	}

	void Update()
	{
		float x = transform.position.x;
		float z = transform.position.z;

		if (Mathf.Sqrt (x * x + z * z) >= maxRadius)
		{
			TicketNotForCDG();
		}

		if (Time.time - t >= maxDueTime)
		{
			TicketMissed();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts) {
			if(collision.gameObject.tag=="Terrain")
			{
				rigidbody.velocity = new Vector3(0, 0, 0);
			}
			else if(collision.gameObject.tag=="Player")
			{
				TicketResolved();
			}
		}
	}
	
	void TicketResolved()
	{
		Destroy (gameObject);
		score.ticketsInQueue -= 1;
		score.ticketsOnTime += 1;
	}

	void TicketMissed()
	{
		Destroy (gameObject);
		score.ticketsInQueue -= 1;
		score.ticketsMissed += 1;
	}

	void TicketNotForCDG()
	{
		Destroy (gameObject);
		score.ticketsInQueue -= 1;
	}
}
