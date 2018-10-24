using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public Player player;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetCountText();
    }
    public void SetCountText()
    {
        pointText.text = player.points.ToString();
    }
}
