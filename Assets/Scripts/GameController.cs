using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    //Points
    public TMPro.TextMeshProUGUI pointsText;
    public int points = 0;
    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Scene1");
        Time.timeScale = 1;
    }
}
