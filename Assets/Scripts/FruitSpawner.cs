using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

//Responsible for spawning the fruit
public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnableFruits;
    [FormerlySerializedAs("numberOfFruit")] [SerializeField] private int numberOfFruitLeft;
    public int NumberOfFruitLeft
    {
        get => numberOfFruitLeft;
        private set => numberOfFruitLeft = value;
    }

    public delegate void OutOfFruit();
    public static event OutOfFruit OnOutOfFruit;

    public delegate void FruitSpawn(int numberOfFruitLeft);
    public static event FruitSpawn OnFruitSpawn;
    
    

    public void DropFruit(Vector2 spawnPosition)
    {
        // It should be instatly know when the fruit is 1 and is call to minus it. Then it can instantly know from that call
        //That the fruit is out at that moment. Not from calling it another time to know that it is null

        if (spawnableFruits.Count == 1)
        {
            OnOutOfFruit();
        }

        if (spawnableFruits.Count >= 1)
        {
            numberOfFruitLeft--;
            OnFruitSpawn(numberOfFruitLeft);
            int fruitIndex = 0; 
            Instantiate(spawnableFruits[fruitIndex], spawnPosition, Quaternion.identity);
            spawnableFruits.Remove(spawnableFruits[fruitIndex]);
        }
        
    }
    
    
    
}
