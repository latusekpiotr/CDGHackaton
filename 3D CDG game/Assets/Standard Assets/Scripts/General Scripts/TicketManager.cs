using UnityEngine;

public class TicketManager : MonoBehaviour
{
    public GameObject ticket;
    public float initialSpawnTime = 10f;
    public float finalSpawnTime = 3f;
    public float spawnTimeDecreaseInterval = 30f;
    public Transform[] spawnPoints;

	private Score score;
	private float spawnTime;
	
    void Awake()
    {
		SetNewSpawnTime(initialSpawnTime);
		InvokeRepeating("DecreaseSpawnTime", spawnTimeDecreaseInterval, spawnTimeDecreaseInterval);
		score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(ticket, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		score.ticketsInQueue += 1;
    }

	void DecreaseSpawnTime()
	{
		if (spawnTime > finalSpawnTime)
		{
			SetNewSpawnTime(--spawnTime);
		}
		else
		{
			CancelInvoke("DecreaseSpawnTime");
		}
	}

	void SetNewSpawnTime(float newSpawnTime)
	{
		CancelInvoke("Spawn");
		spawnTime = newSpawnTime;
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
}