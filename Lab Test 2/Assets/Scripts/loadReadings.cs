using UnityEngine;
using System.Collections.Generic;

public class loadReadings : MonoBehaviour {
    public GameObject readingPrefab;

    public GameObject locationText;
    public GameObject dateText;
    public GameObject categoryText;
    public GameObject measureText;

    public List<GameObject> spawnedReadingsList;


    // Use this for initialization
    void Start () {
        List<Reading> readings = Request.getReadings();
        foreach(Reading r in readings){
            GameObject newReading = Instantiate(readingPrefab);
            newReading.GetComponentInChildren<readingPrefab>().setup(this, r, locationText, dateText, categoryText, measureText);
            spawnedReadingsList.Add(newReading);
        }
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
