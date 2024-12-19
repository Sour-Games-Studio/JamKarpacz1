using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 moveDirection;
    private Rigidbody rb;
    private MeleeAttack meleeAttack;

    private RangedAttack rangedAttack;
    private float dashDistance = 5f;
    public Transform Center;



    public float health = 6;
    private float maxHealth;
    private bool isInvincible = false;
    private bool canDash = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meleeAttack = GetComponent<MeleeAttack>();
        rangedAttack = GetComponent<RangedAttack>();
        maxHealth = health;
    }

    void Update()
    {
        ProcessInputs();


        //print(Input.GetAxis("Fire1"));

        if (Input.GetAxis("Fire1")>0)
        {
            //Debug.Log(transform.rotation);
            meleeAttack.TryAttack(ReturnAngle());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Debug.Log(transform.rotation);
            rangedAttack.TryAttack(ReturnAngle());
        }

        //Debug.Log(health);

    }

    void FixedUpdate()
    {
        Vector3 movement = moveDirection * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + movement);
        
    }

    void ProcessInputs()
    {
        Vector3 inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = new Vector3(inputs.x, 0, inputs.z);

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            Dash(moveDirection);
            StartCoroutine(DashCooldown());
            StartCoroutine(InvincibilityFrames(1.5f));
        }
        
    }

    void Dash(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * dashDistance, ForceMode.Impulse);
    }
    
private float ReturnAngle()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    
        Vector3 lookDirection = mousePos - transform.position;
        //print(transform.position + "center");
        //print(mousePos + "mouse");
        float angle = Mathf.Atan2(lookDirection.z, lookDirection.x) * Mathf.Rad2Deg;
    
        //Debug.Log("Angle: " + angle);
        if (mousePos.x < transform.position.x) // Left side
        {
            angle = RemapLeftSideAngles(angle);
        }
        else // Right side
        {
            angle = Mathf.Clamp(angle, -90f, 90f);
        }
    
        //transform.rotation = Quaternion.Euler(0, angle, 0);
        return angle;
    }

private float RemapLeftSideAngles(float angle)
{
    if (angle >= -180f && angle <= -90f)
    {
        return Mathf.Lerp(-180f, -90f, (angle + 180f) / 90f);
    }
    else if (angle > -90f && angle <= 0f)
    {
        return Mathf.Lerp(-90f, 0f, (angle + 90f) / 90f);
    }
    else if (angle > 0f && angle <= 90f)
    {
        return Mathf.Lerp(0f, 90f, angle / 90f);
    }
    else if (angle > 90f && angle <= 180f)
    {
        return Mathf.Lerp(90f, 180f, (angle - 90f) / 90f);
    }
    return angle;
}

// private void OnTriggerEnter(Collider other)
// {
//     Debug.Log("Got damaged");
//     if (CompareTag("Bullet"))
//     {
//         health -= 1;
//     }
//     Debug.Log(health + "health after triggerenter");
// }

public void TakeDamagePlayer(float damage)
{
    if(!isInvincible){
        health -= damage;
        //Debug.Log("Player took " + damage + " damage");
        //Debug.Log(health + "health after takedamage");
        StartCoroutine(InvincibilityFrames(2f));
    }
    if (health < 1)
    {
        Destroy(this.gameObject);
        //play game over screen
    }
}
    private IEnumerator InvincibilityFrames(float seconds)
    {
        //Debug.Log("Player is invincible");
        isInvincible = true;
        yield return new WaitForSeconds(seconds); // 1 second of invincibility
        isInvincible = false;
        //Debug.Log("Player is no longer invincible");
    }

    private IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(1.5f); // 2 second cooldown
        canDash = true;
    }

    void updateHealth(float healthGained)
    {
        if (health + healthGained > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healthGained;
        }
    }

    void updateMeleeDamage(float damageGained)
    {
        meleeAttack.attackDamage += damageGained;
    }
    void updateRangedDamage(float damageGained)
    {
        rangedAttack.attackDamage += damageGained;
    }
    void updateSpeed(float speedGained)
    {
        moveSpeed += speedGained;
    }   
}