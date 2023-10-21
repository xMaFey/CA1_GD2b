using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    public Collider2D swordCollider;
    
    public float swordDamage = 3;

    public enum AttackDirection
    {
        right, left, up, down
    }

    public Transform swordColliderFlip;

    public AttackDirection attackDirection;

    public void Attack()
    {
        switch(attackDirection)
        {
            case AttackDirection.right:
                AttackRight();
                break;
            case AttackDirection.left:
                AttackLeft();
                break;
            case AttackDirection.up:
                AttackUp();
                break;
            case AttackDirection.down:
                AttackDown();
                break;
        }

    }

    private void AttackRight()
    {   
        print("Attack Right");
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 0);
    }

    private void AttackLeft()
    {
        print("Attack Left");
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 180);
    }

    private void AttackUp()
    {
        print("Attack Up");
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 90);
    }

    private void AttackDown()
    {
        print("Attack Down");
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 270);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Enter");
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(swordDamage);
        }

    }
}
