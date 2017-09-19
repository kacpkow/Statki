using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCatchPlayer : MonoBehaviour {

    Vector3 popUpPosition;
    

    // Use this for initialization
    void Start () {
        var popUp = GameObject.Find("PopUp");
        var foo = (CityPopUpController)popUp.GetComponent("CityPopUpController");
        popUpPosition = foo.transform.position;
        Vector3 pos = foo.transform.position;
        Vector3 velocity = new Vector3(1000, 0, 0);
        pos += foo.transform.rotation * velocity;
        foo.transform.position = pos;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            var popUp = GameObject.Find("PopUp");
            var foo = (CityPopUpController)popUp.GetComponent("CityPopUpController");
            
            Vector3 pos = foo.transform.position;
            Vector3 velocity = popUpPosition;
            pos = foo.transform.rotation * velocity;
            foo.transform.position = pos;
        }
    }



    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            var popUp = GameObject.Find("PopUp");
            var cityPopUpController = (CityPopUpController)popUp.GetComponent("CityPopUpController");

            Vector3 pos = cityPopUpController.transform.position;
            Vector3 velocity = new Vector3(1000, 0, 0);
            pos += cityPopUpController.transform.rotation * velocity;
            cityPopUpController.transform.position = pos;
        }
    }
}
