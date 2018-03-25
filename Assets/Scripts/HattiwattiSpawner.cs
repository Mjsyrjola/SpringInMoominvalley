using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HattiwattiSpawner : MonoBehaviour {

    public GameObject hattiwatti;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnWaitMax;
    public float spawnWaitMin;
    public int startWait;
    public bool stop;

	void Start () {
        StartCoroutine(WaitSpawner());
	}

	void Update () {
        spawnWait = Random.Range(spawnWaitMin, spawnWaitMax);
	}

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while(!stop)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, 1);

            Instantiate(hattiwatti, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
