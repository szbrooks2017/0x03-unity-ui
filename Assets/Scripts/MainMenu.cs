using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
public void PlayMaze()
{
    SceneManager.LoadScene("maze");
}
}
