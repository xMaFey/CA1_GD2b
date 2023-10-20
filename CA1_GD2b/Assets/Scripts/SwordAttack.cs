using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public Collider2D swordColliderHorizontal;
    

    public enum AttackDirection
    {
        right, left, up, down
    }

    public AttackDirection attackDirection;

    // Start is called before the first frame update
    public void Start()
    {

    }



    public void Attack()
    {
        print("Funguju");
        switch(attackDirection)
        {
            case AttackDirection.right:
                AttackRight();
                break;
            case AttackDirection.left:
                AttackLeft();
                break;
        }

    }

    private void AttackRight()
    {   
        print("Attack Right");
        swordColliderHorizontal.enabled = true;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void AttackLeft()
    {
        print("Attack Left");
        swordColliderHorizontal.enabled = true;
        transform.eulerAngles = new Vector3(0, 0, 180);
    }

    private void AttackUp()
    {

    }

    private void AttackDown()
    {

    }

    public void StopAttack()
    {
        swordColliderHorizontal.enabled = false;
    }
}
