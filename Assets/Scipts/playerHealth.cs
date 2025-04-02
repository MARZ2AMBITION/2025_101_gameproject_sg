using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int maxLive = 3;
    public int currentLivews;

    public float invincibleTime = 1.0f;
    public bool isinvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLivews = maxLive;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Misslie"))
        {
            currentLivews--;
            Destroy(other.gameObject);

            if(currentLivews <= 0 )
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);

    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
