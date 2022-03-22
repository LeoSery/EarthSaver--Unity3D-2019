using UnityEngine;
//
#pragma warning disable 0108
#pragma warning disable 0649
//
public class MeteorsSpawner : MonoBehaviour
{
	public bool spawn = false;
	public float meteorSpawnRate = 1;
	public GameObject[] meteorPrefabs;
	private GameObject currentMeteorPrefab;
	public Collider spawnMatrix;
	private int index;
	public Menu menu;

	float t;

    private void Update()
	{
		if (spawn && (Time.time >= t))
		{
			index = Random.Range(0, meteorPrefabs.Length);
			currentMeteorPrefab = meteorPrefabs[index];
				
			CreateMeteor();
			if (Menu.IsGameOver)
				meteorSpawnRate = 1f;
            else 
				meteorSpawnRate += 0.0075f;
			if (meteorSpawnRate > 2) meteorSpawnRate = 2;
				t = Time.time + 1 / meteorSpawnRate;
		}
	}

    private void CreateMeteor()
	{
		if (spawn)
		{
			Vector2 target = Random.insideUnitCircle * 1.2f;
			GameObject g = Instantiate(currentMeteorPrefab, RandomPointInBounds(spawnMatrix.bounds), Quaternion.identity);
			g.GetComponent<Chair>().target = target;
			g.transform.LookAt(target);
		}

	}

	public void StartGame()
	{
		spawn = true;
	}

	public void StopGame()
	{
		spawn = false;
	}

	public static Vector3 RandomPointInBounds(Bounds bounds)
	{
		return new Vector3(
			Random.Range(bounds.min.x, bounds.max.x),
			Random.Range(bounds.min.y, bounds.max.y),
			Random.Range(bounds.min.z, bounds.max.z)
		);
	}
}
