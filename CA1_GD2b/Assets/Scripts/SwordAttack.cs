using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    // Variable swordDamage = how much damage will to sword deal
    public float swordDamage = 3;

    // Variables for 4 directions (options) in which the player can attack
    public enum AttackDirection
    {
        right, left, up, down
    }

    // Variables of Objects so I can use them in the script and in other scripts (public)
    public Collider2D swordCollider;   

    public Transform swordColliderFlip;

    public AttackDirection attackDirection;

    // Function Attack gets information from PlayerMovement script and tells it in which direction the player is attacking
    // Every direction has it own case in switch and it triggers the attack function in right direction
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

    // Functions to attack in 4 directions (Right, Left, Up, Down) - it rotates the swordCollider around the player
    // It also sets the swordCollider trigger to true, so it appears
    private void AttackRight()
    {   
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 0);
    }

    private void AttackLeft()
    {
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 180);
    }

    private void AttackUp()
    {
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 90);
    }

    private void AttackDown()
    {
        swordCollider.enabled = true;
        swordColliderFlip.eulerAngles = new Vector3(0, 0, 270);
    }

    // Stop attack sets the sword collider trigger to false so the collider disapears
    public void StopAttack()
    {
        swordCollider.enabled = false;
    }

    // When the collider appear this function checks if there is an object that is tagged as enemy in the collider
    // If yes it call the TakeDamage function in the Enemy script
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Enter");
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(swordDamage);
            AudioManager.audioInstance.PlaySlimeHitSound();
        }

    }
}
