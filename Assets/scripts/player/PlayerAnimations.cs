using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    private Animator playerAnimator;
    private float normalMainSpeed;

    private bool runstatus;
    public bool runStatus
    {
        get
        {
            return runstatus;
        }
    }
 
    void Start () {

        playerAnimator = GetComponent<Animator>();
        normalMainSpeed = playerAnimator.GetFloat("normalAttackSpeed");
    }
	
    public void RunAnimation(bool status)
    {
        playerAnimator.SetBool("Run", status);
        runstatus = status;
    }

    public void PlayerNormalAttack(float attackSpeed)
    {
        float multiplySpeed = Calculator.SpeedMultiply(attackSpeed, normalMainSpeed);
        playerAnimator.SetFloat("normalAttackSpeed", multiplySpeed);
        playerAnimator.SetTrigger("NormalAttack");
        RunAnimation(false);
    }
}
