using UnityEngine;

// Responsible for taking in player controller
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FruitSpawner fruitSpawner;
    
    void Start()
    {
        fruitSpawner = GetComponent<FruitSpawner>();
    }
    
    void Update()
    {
        //There are better way than this is to use input action which I forget how to
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 dropPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // Should have send as event
            fruitSpawner.DropFruit(dropPosition);
            
        }
    }
    
}
