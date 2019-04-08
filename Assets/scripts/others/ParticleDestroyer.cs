using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

    public float timerOffset;
    private float timer;
	void Start () {
        Destroyer();
    }

    void Destroyer()
    {
        ParticleSystem.MainModule mod = GetComponentInChildren<ParticleSystem>().main;
        timer = mod.startLifetime.constant;
        Destroy(gameObject, timer + timerOffset);
    }
	
	
}
