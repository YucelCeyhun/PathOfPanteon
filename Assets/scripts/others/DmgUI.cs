using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgUI : MonoBehaviour {
    private Camera mainCam;

    void Start () {
        mainCam = Camera.main;
        Destroy(gameObject, 1.5f);
	}
	
	void Update () {
        transform.rotation = Quaternion.LookRotation(mainCam.transform.forward);
	}

}
