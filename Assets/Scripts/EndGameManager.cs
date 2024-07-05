using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//Responsible to check if ending game with win or lose
public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    private float lastFruitTimer;

    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    private int _endGameTimer = 5;
    private int _loseGameTimer = 10;

    private void OnEnable()
    {
        Fruit.OnCombine += CheckWinGame;
        FruitSpawner.OnOutOfFruit += CheckLoseGame;
    }

    private void OnDisable()
    {
        Fruit.OnCombine -= CheckWinGame;
        FruitSpawner.OnOutOfFruit -= CheckLoseGame;
    }

    private void CheckWinGame(bool isWinGame)
    {
        if (isWinGame)
        {
            Debug.Log("Win the game");
            Instantiate(winScreen);
            StartCoroutine(RestartGame());
        }
    }

    //Refactoring as the condition for losing the game is quite confusing for now.
    private void CheckLoseGame()
    {
        StartCoroutine(LoseGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(_endGameTimer);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(_loseGameTimer);
        if (!GameObject.Find(winScreen.name))
        {
            Instantiate(loseScreen);
            StartCoroutine(RestartGame());
        }
    }
}
