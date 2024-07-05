
using UnityEngine;


public class Fruit : MonoBehaviour
{
    
    [SerializeField]
    private GameObject nextFruit;
    private int _fruitID;
    
    public delegate void Combine(bool toNothing);
    public static event Combine OnCombine;

    private void Start()
    {
        _fruitID = GetInstanceID();
    }
    

    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckCombining(other);
    }

    private void CheckCombining(Collision2D other)
    {
        Fruit otherFruit = other.gameObject.GetComponent<Fruit>();
        
        if(otherFruit == null) {return;}
        
        if (otherFruit.nextFruit == this.nextFruit)
        {
            Vector3 inBetweenPosition = (transform.position + other.transform.position) / 2;
            CombineToNewFruitAtLocation(inBetweenPosition, otherFruit);
        }
        
    }
    
    private void CombineToNewFruitAtLocation(Vector3 newFruitPosition, Fruit otherFruit)
    {
        bool toNothing = false;
        if (_fruitID > otherFruit._fruitID)
        {
            if (nextFruit != null)
            {
                Instantiate(nextFruit, newFruitPosition, Quaternion.identity);
               
            }
            else
            {
                toNothing = true;
            }
                OnCombine(toNothing);
        }
        Destroy(this.gameObject);
    }
    
}
