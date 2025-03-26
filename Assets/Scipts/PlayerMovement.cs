using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    public bool isgrounded = true;

    public int CoinCount = 0;
    public int totalCoin = 5;

    public Rigidbody rd;

    void Update()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        rd.velocity = new Vector3(moveHor * moveSpeed, rd.velocity.y, moveVer * moveSpeed);

        if(Input.GetButtonDown("Jump") && isgrounded)
        {
            rd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isgrounded = false;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isgrounded = true;
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
}
