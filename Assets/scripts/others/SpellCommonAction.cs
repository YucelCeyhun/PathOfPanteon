using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCommonAction : MonoBehaviour {

    public GameObject target;
    public  Vector3 offset;

    void Start()
    {
        transform.position = target.transform.position + offset;
    }
}
