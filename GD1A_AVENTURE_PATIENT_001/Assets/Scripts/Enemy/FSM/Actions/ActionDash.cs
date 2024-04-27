using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDash : FSMAction
{
    [Header("Configurations")]
    public GameObject player;

    public bool canMove = true;
    public bool gotHit;
    public bool inversed;

    public float moveSpeed;
    public float dashSpeed;
    public float chargeCooldown;
    public float dashLength = .5f;
    public float idleLenght = .5f;
    public float orbitRange, orbitWidth;
    public float gotHitCounter;
    public float gotHitLength;

    private bool charging;
    private bool idle;

    private float timerCharge;
    private float distance;
    private float activeMoveSpeed;
    private float dashCounter;
    private float idleCounter;

    private int turnDir = 1;
    private Vector2 target;

    public override void Act()
    {
        EnemyDash();
    }

    private void EnemyDash()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (canMove)
        {
            if (distance > orbitRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, activeMoveSpeed * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else if (distance > orbitRange - orbitWidth && distance < orbitRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + (turnDir) * Vector2.Perpendicular(direction), activeMoveSpeed * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, -player.transform.position, activeMoveSpeed * Time.fixedDeltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }

        timerCharge += Time.deltaTime;

        if (timerCharge > chargeCooldown)
        {
            timerCharge = 0f;
            idle = true;
            idleCounter = 0;
        }

        if (idle)
        {
            if (idleCounter <= 0)
            {
                idleCounter = idleLenght;
                target = player.transform.position + (player.transform.position - transform.position);
            }

            idle = false;
        }

        if (idleCounter > 0)
        {
            canMove = false;
            idleCounter -= Time.fixedDeltaTime;

            if (idleCounter < 0)
            {
                charging = true;
            }

            if (charging)
            {
                if (dashCounter <= 0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                }

                charging = false;

            }

            if (dashCounter > 0)
            {
                canMove = false;
                dashCounter -= Time.fixedDeltaTime;

                transform.position = Vector2.MoveTowards(transform.position, target, activeMoveSpeed * Time.fixedDeltaTime);

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                }
            }

            if (dashCounter < 0 && idleCounter < 0)
            {
                canMove = true;
            }
        }
    }
}
