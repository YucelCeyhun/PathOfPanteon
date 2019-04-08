using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerRayCaster))]
public class PlayerMouseEvents : MonoBehaviour {

    PlayerRayCaster PlayerRayCaster;
    public Layer[] layerPriorities = {

        Layer.Item,
        Layer.Enemy,
        Layer.Walkable

    };

    private void MouseLeftClick()
    {
        if (Input.GetMouseButton(0))
        {
            foreach (Layer layer in layerPriorities)
            {
                var hit = PlayerRayCaster.RaycastForLayer(layer);

                if (hit.HasValue)
                {
                    PlayerController.singleton.LayerFind(layer, hit);
                    return;
                }
            }

            PlayerController.singleton.LayerFind(Layer.Unidentified, null);
        }
    }
    
    
    void Start () {
        PlayerRayCaster = GetComponent<PlayerRayCaster>();
	}
	
	
	void Update () {
        MouseLeftClick();
    }
}
