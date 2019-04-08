using UnityEngine;

public class Wave : MonoBehaviour {

    Renderer sea;

	void Start () {
        sea = GetComponent<Renderer>();
	}
	

	void Update () {
        float offset = Time.time * 0.2f;

        if (offset >= 100f)
            offset = 0;

        sea.material.mainTextureOffset = new Vector2(offset, 0);
        sea.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(offset / 2, 0));
        
	}
}
