using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour {

	public static Vector3 GetSpawnPoint() {
        GameObject[] points = GameObject.FindGameObjectsWithTag("SpawnPoint");
        return points[Random.Range(0, points.Length)].transform.position;
    }

    /*
    public static Vector3[] GetStartingPoints()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("SpawnPoint");
    }
     * */
}
