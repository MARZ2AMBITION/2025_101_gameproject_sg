using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cube_Game_Ui : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        TimeText.text = "생존시간 : " + timer.ToString("0.00");

    }
}
