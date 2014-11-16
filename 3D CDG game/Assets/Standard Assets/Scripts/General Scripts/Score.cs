using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int ticketsOnTime = 0;
	public int ticketsMissed = 0;
	public int ticketsInQueue = 0;

	TicketController ticketController;

	// Use this for initialization
	void Awake () {
		ticketController = GameObject.FindGameObjectWithTag("Player").GetComponent<TicketController>();
	}
	
	// Update is called once per frame
	void Update () {
		float sla = 0;
		if (ticketsOnTime + ticketsMissed > 0)
		{
			sla = (float)ticketsOnTime / (ticketsOnTime + ticketsMissed);
		}

		guiText.text = string.Format("Tickets resolved on time: {0}, missed: {1}, SLA: {2:0.0%}, in CDG queue: {3}",
			ticketsOnTime,
			ticketsMissed,
			sla,
		    ticketsInQueue);
	}
}
