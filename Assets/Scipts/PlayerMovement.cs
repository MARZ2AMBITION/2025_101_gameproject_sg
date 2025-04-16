using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("기본 이동 설정")]
    public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 7f;
    public float trunSpeed = 10f;

    public float fallMutiplier = 2.5f;
    public float lowJumpMultiplier = 2.0f;

    public float coyoteTime = 0.15f;
    public float coyoteTimeCounter;
    public bool realGround = true;

    [Header("글라이더 설정")]
    public GameObject gliderObject;
    public float gilderfFallSpeed = 1.0f;
    public float gildermoveSpeed = 7.0f;
    public float gilderMaxTime = 5.0f;
    public float gilderTimeLeft;
    public bool gilding = true;

    public bool isgrounded = true;

    public int CoinCount = 0;
    public int totalCoin = 5;

    public Rigidbody rd;


    private void Start()
    {
        if(gliderObject != null)
        {
            gliderObject.SetActive(false);
        }

        gilderTimeLeft = gilderMaxTime;

        coyoteTimeCounter = 0;
    }
    void Update()
    {
        UpdataGround(); //코요테 점프

        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        //이동 방향 벡터
        Vector3 movement = new Vector3(moveHor, 0, moveVer); 

        if(movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, trunSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.G) && !isgrounded && gilderTimeLeft > 0)
        {
            if(!gilding)
            {
                Enablegilder();
            }
            gilderTimeLeft -= Time.deltaTime;

            if(gilderTimeLeft <= 0)
            {
                DisableGlider();
            }
     
        }
        else if (gilding)
        {
            DisableGlider();
        }
        if(gilding)
        {
            ApplygilderMovement(moveHor, moveVer);
        }
        else
        {
            if (rd.velocity.y < 0)
            {
                rd.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            else if (rd.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rd.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
            rd.velocity = new Vector3(moveHor * moveSpeed, rd.velocity.y, moveVer * moveSpeed);

        if(rd.velocity.y < 0)
        {
            rd.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        else if(rd.velocity.y > 0&& !Input.GetButton("Jump"))
        {
            rd.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump") && isgrounded)
        {
            rd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isgrounded = false;
            realGround = false;
            coyoteTime = 0;
        }
        if(isgrounded)
        {
            if(gilding)
            {
                DisableGlider();
            }
            gilderTimeLeft = gilderMaxTime;
        }
    }

    void  Enablegilder()
    {
        gilding = true;

        if( gilding != null)
        {
            gliderObject.SetActive(true);
        }
        rd.velocity = new Vector3(rd.velocity.x, -gilderfFallSpeed, rd.velocity.z);
    }
    void DisableGlider()
    {
        gilding = false;

        if (gliderObject != null)
        {
            gliderObject.SetActive(false);
        }
        rd.velocity = new Vector3(rd.velocity.x, 0, rd.velocity.z);
    }

    void ApplygilderMovement(float hor, float Ver)
    {
        Vector3 gliderVelocity = new Vector3(
        hor * gildermoveSpeed,
            -gilderfFallSpeed,
            Ver * gildermoveSpeed
            );
        rd.velocity = gliderVelocity;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            realGround = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            realGround = false; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("coin"))
        {
            CoinCount++;
            Destroy(other.gameObject);
            Debug.Log($"코인수집: {CoinCount}/ {totalCoin}");
        }

        if(other.gameObject.tag == "Door" && CoinCount == totalCoin)
        {
            Debug.Log("게임클리어");
        }
    }

    void UpdataGround()
    {
        if(realGround)
        {
            coyoteTimeCounter = coyoteTime;
            isgrounded = true;
        }
        else
        {
            if (coyoteTimeCounter > 0)
            {
                coyoteTimeCounter -= Time.deltaTime;
                isgrounded = true;

            }
            else
            {
                isgrounded = false;
            }
        }
    }
}
