using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenGithub()
    {
        System.Diagnostics.Process.Start("https://github.com/NikoDyring/AI_TicTacToe");
    }

}
