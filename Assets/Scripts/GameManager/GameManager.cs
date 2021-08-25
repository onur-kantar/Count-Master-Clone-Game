using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mainPlayer;
    MoveToDirection mainPlayerMoveToDirection;
    Movement mainPlayerMovement;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject winMenu;
    [SerializeField] GameObject loseMenu;
    private void Start()
    {
        mainPlayerMoveToDirection = mainPlayer.GetComponent<MoveToDirection>();
        mainPlayerMovement = mainPlayer.GetComponent<Movement>();
    }
    public void StartGame()
    {
        mainPlayerMoveToDirection.StartMoveToDirection();
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
        mainPlayerMoveToDirection.StopMoveToDirection();
        mainPlayerMovement.StopMovement();
        winMenu.SetActive(true);
    }
    public void Lose()
    {
        CloseAllMenus();
        mainPlayerMoveToDirection.StopMoveToDirection();
        mainPlayerMovement.StopMovement();
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
