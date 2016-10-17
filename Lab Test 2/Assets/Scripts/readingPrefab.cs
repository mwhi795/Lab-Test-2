using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class readingPrefab : MonoBehaviour {
    Reading reading;

    public GameObject locationText;
    public GameObject dateText;
    public GameObject ecologicalValueText;
    public GameObject historicalSignificanceText;

    public Color originalColor;
    public Color selectedColor;

    public bool selected = false;

    loadReadings setupManager;

    public void setup(loadReadings lr, Reading r, GameObject lt, GameObject dt, GameObject ct, GameObject mt)
    {
        this.reading = r;

        //Move into position
        this.transform.position = new Vector3(r.X, r.Y, r.Z);
        
        //Set the label to be the Location
        this.GetComponentInChildren<TextMesh>().text = r.Location;

        //Set to original color
        this.GetComponent<Renderer>().material.color = originalColor;

        this.locationText = lt;
        this.dateText = dt;
        this.ecologicalValueText = ct;
        this.historicalSignificanceText = mt;

        this.setupManager = lr;

        

    }

    public void revertColor()
    {
        this.GetComponent<Renderer>().material.color = originalColor;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            foreach(GameObject r in this.setupManager.spawnedReadingsList)
            {
                if (r.GetComponent<readingPrefab>().selected)
                {
                    r.GetComponent<readingPrefab>().revertColor();
                    r.GetComponent<readingPrefab>().selected = false;
                }
            }

            //Set all other objects to default color.
            Debug.Log("Mouse Click: " + reading.TreeID.ToString());
            

            originalColor = this.GetComponent<Renderer>().material.color;
            this.GetComponent<Renderer>().material.color = selectedColor;

            //Set Panel Text
            locationText.GetComponent<Text>().text = "Location: " + reading.Location;
            dateText.GetComponent<Text>().text = "Date of Reading: " + reading.WhenReadingRecorded;
            ecologicalValueText.GetComponent<Text>().text = "Safety Category: " +reading.EcologicalValue;
            historicalSignificanceText.GetComponent<Text>().text = "Safety Measure: " + reading.HistoricalSignificance.ToString();

            this.selected = true;
        }
    }


}
