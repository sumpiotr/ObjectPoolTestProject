using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [SerializeField]
    private Text InfoText;

    [SerializeField]
    private Text StartButtonText;
    private void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        if (!PointsInfo.info.endScene) 
        {
            InfoText.text = "Space Shooter";
            StartButtonText.text = "Play";
        }
        else 
        {
            InfoText.text = $"You gain {PointsInfo.info.points} points";
            StartButtonText.text = "Play Again";
        }
    }
    public void OnPlayButtonClick() 
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonCLick() 
    {
        Application.Quit();
    }

}
