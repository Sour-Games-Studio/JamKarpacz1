using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


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

    public bool canMove = true;

    public int Direction = 0;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        meleeAttack = GetComponent<MeleeAttack>();
        rangedAttack = GetComponent<RangedAttack>();
        moveSpeed = PlayerPrefs.HasKey("moveSpeed") ? PlayerPrefs.GetFloat("moveSpeed") : 4f;
        health = PlayerPrefs.HasKey("health") ? PlayerPrefs.GetFloat("health") : 6f;
        rangedAttack.attackDamage = PlayerPrefs.HasKey("rangedAttackDamage") ? PlayerPrefs.GetFloat("rangedAttackDamage") : 1f;
        meleeAttack.attackDamage = PlayerPrefs.HasKey("meleeAttackDamage") ? PlayerPrefs.GetFloat("meleeAttackDamage") : 2f;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHealth = health;
        if (SceneManager.GetActiveScene().name == "Kacper")
        {
            moveSpeed = 4f;
            health = 6f;
            rangedAttack.attackDamage = 1f;
            meleeAttack.attackDamage = rangedAttack.attackDamage * 2f;
        }
    }

    void Update()
    {
        if (!canMove)
        {
            return;
        }
        ProcessInputs();
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("Kacper2");
        }
        //print(Input.GetAxis("Fire1"));

        if (Input.GetAxis("Fire1")>0)
        {
            //Debug.Log(transform.rotation);
            meleeAttack.TryAttack(ReturnAngle());
            animator.SetBool("IsMeleeing", true);
            print(animator.GetBool("IsMeleeing"));
            StartCoroutine(ResetBools());
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //Debug.Log(transform.rotation);
            rangedAttack.TryAttack(ReturnAngle());
            animator.SetBool("IsRanging", true);
            print(animator.GetBool("IsRanging"));
            StartCoroutine(ResetBools());
        }

        RotateSprite();

        //Debug.Log(health);

    }

    void FixedUpdate()
    {
        Vector3 movement = moveDirection * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + movement);
        
    }

    void RotateSprite(){
        //float angle = ReturnAngle();
        //get movement direction
        animator.SetInteger("Direction",Direction = moveDirection.z > 0 ? 0 : moveDirection.z < 0 ? 2 : moveDirection.x > 0 ? 1 : moveDirection.x < 0 ? 3 : Direction);


        //depending on angle value, choose one of 4 sprites and return value from 0 to 3 when angle is from -180 to 180, but consider i want index 0 to be from- -45 to 45, 1 from 45 to 135, 2 from 135 to 180 and -180 to -135, 3 from -135 to -45
       
        //indek 0 is 0 degrees, 1 is 45 degrees, 2 is 90 degrees, 3 is 135 degrees, 4 is 180 degrees, 5 is 225 degrees, 6 is 270 degrees, 7 is 315 degrees
        Debug.Log(Direction + " direction");
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
        private IEnumerator ResetBools()
    {
        //Debug.Log("Player is invincible");
        animator.SetBool("IsRanging",false);
        yield return new WaitForSeconds(1f); // 1 second of invincibility
        animator.SetBool("IsMeleeing",false);
        //Debug.Log("Player is no longer invincible");
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