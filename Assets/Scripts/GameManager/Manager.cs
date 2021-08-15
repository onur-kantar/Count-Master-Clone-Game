using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] MoveToDirection mainPlayerMoveToDirection;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;

    public void StartGame()
    {
        mainPlayerMoveToDirection.enabled = true;
        CloseAllMenus();
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Win()
    {
        CloseAllMenus();
        mainPlayerMoveToDirection.enabled = false;
        winMenu.SetActive(true);
    }
    public void Lose()
    {
        CloseAllMenus();
        mainPlayerMoveToDirection.enabled = false;
        loseMenu.SetActive(true);
    }
    void CloseAllMenus()
    {
        foreach (Transform child in menu.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
