using UnityEngine;

public class CameraFollower : MonoBehaviour {

    GameObject Player;
    Vector3 offset;
	
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        offset = Player.transform.position - transform.position;
	}
	
	
	void Update () {
        transform.localPosition = Vector3.MoveTowards(transform.position, Player.transform.position - offset, 5f);
    }
}
