using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CarMovement : NetworkBehaviour
{ 
    public float acceleration;
    public float steering;
    public Rigidbody2D rb;

    public float accelCooldown, fireRate;
    float accelTimer, fireTimer;
    public bool accelOn = false;
    public bool firingOn = false;
    public GameObject bullet;
    Vector2 shootDirection;


    
    

    public override void OnStartAuthority()
    {
        
        Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
    }


    public void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float h = -Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector2 speed = transform.up * (v * acceleration);
            rb.AddForce(speed);

            float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
            if (direction >= 0.0f)
            {
                rb.rotation += h * steering * (rb.velocity.magnitude / 5.0f);
                //rb.AddTorque((h * steering) * (rb.velocity.magnitude / 10.0f));
            }
            else
            {
                rb.rotation -= h * steering * (rb.velocity.magnitude / 5.0f);
                //rb.AddTorque((-h * steering) * (rb.velocity.magnitude / 10.0f));
            }

            Vector2 forward = new Vector2(0.0f, 0.5f);
            float steeringRightAngle;
            if (rb.angularVelocity > 0)
            {
                steeringRightAngle = -90;
            }
            else
            {
                steeringRightAngle = 90;
            }

            Vector2 rightAngleFromForward = Quaternion.AngleAxis(steeringRightAngle, Vector3.forward) * forward;
            Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(rightAngleFromForward), Color.green);

            float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(rightAngleFromForward.normalized));

            Vector2 relativeForce = (rightAngleFromForward.normalized * -1.0f) * (driftForce * 10.0f);


            Debug.DrawLine((Vector3)rb.position, (Vector3)rb.GetRelativePoint(relativeForce), Color.red);

            rb.AddForce(rb.GetRelativeVector(relativeForce));

            ShiftSkill();
            FireBullet();
        }
    }

    public void ShiftSkill()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && accelOn == false)
        {
            accelTimer = Time.time + accelCooldown;
            acceleration = 10;
            accelOn = true;
            
        }

        if (accelOn == true && Time.time > accelTimer)
        {
            acceleration = 5;
            accelOn = false;
        }
    }

    public void FireBullet()
    {
        if (Input.GetMouseButton(0) && firingOn == false)
        {
            fireTimer = Time.time + fireRate;
            shootDirection = Input.mousePosition;
            
            shootDirection = (Vector2) Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection - (Vector2)transform.position;
            Debug.Log(shootDirection);
            shootDirection.Normalize();
            Debug.Log(shootDirection);
            GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * 50f, shootDirection.y * 50f);
            firingOn = true;
        }

        if (firingOn == true && Time.time > fireTimer)
        {
            firingOn = false;
        }
    }
 }
