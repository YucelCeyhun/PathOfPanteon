using UnityEngine;



[RequireComponent(typeof(PlayerAnimations))]
public class PlayerController : MonoBehaviour {

    

    [SerializeField] float MoveSpeed = 1f;
    [SerializeField] float MinDistance = 1f;

    public static PlayerController singleton;
    private PlayerAnimations anim;
    private PlayerCombat playerCombat;
    public float distance = 0;
    private Vector3 Point;

    private void Awake()
    {
        singleton = this;
        anim = GetComponent<PlayerAnimations>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    public void LayerFind(Layer layer, RaycastHit? hit)
    {
        switch (layer)
        {
            case Layer.Walkable:
                DetectPoint(hit.Value.point);
                break;
            case Layer.Enemy:
                distance = 0;
                GameObject target = hit.Value.collider.gameObject;
                EnemyNormalAttack(target);
                break;
            case Layer.Item:
                ItemPickUp pickUp = GetComponent<ItemPickUp>();
                if (Vector3.Distance(transform.position, hit.Value.collider.transform.position) < 2f)
                {
                    pickUp.TakeItem(hit.Value.collider.transform);
                }
                else
                {
                    distance = 0;
                    DetectItem(hit.Value.collider.transform);
                    pickUp.TakeItem(hit.Value.collider.transform);
                }
                
                break;
            default:
                print("Undefined layer");
                break;
        }
    }

    private void EnemyNormalAttack(GameObject hitTarget)
    {
        playerCombat.NormalAttackToTarget(hitTarget);
    }

    private void DetectPoint(Vector3 Point)
    {
        distance = Vector3.Distance(transform.position, Point);
        this.Point = Point;
        anim.RunAnimation(true);
    }

    private void DetectItem(Transform item)
    {
        distance = Vector3.Distance(transform.position, item.transform.position);
        this.Point = item.transform.position;
        anim.RunAnimation(true);
    }


    private void TransPosition(Vector3 Point)
    { 
        transform.LookAt(new Vector3(Point.x, transform.position.y, Point.z));
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        distance = Vector3.Distance(transform.position, Point);
    }

    private void Move()
    {
        if (distance > MinDistance)
        {
            TransPosition(Point);
        }else if (!(distance > MinDistance) && anim.runStatus)
        {
            distance = 0;
            anim.RunAnimation(false);
        }   
    }


}
