using UnityEngine;


[RequireComponent(typeof(PlayerController))]
public class PlayerRayCaster : MonoBehaviour {


    private Camera playerCame;

    float backgroundDistance = 100f;

    
    void Start () {
        playerCame = Camera.main;
    }

    public RaycastHit? RaycastForLayer(Layer layer)
    {
        RaycastHit hit;
        int mask = 1 << (int)layer;
        Ray ray = playerCame.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out hit, backgroundDistance, mask);

        if (hasHit)
            return hit;

        return null;
    }
}
