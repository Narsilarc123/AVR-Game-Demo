using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int coinsCollected = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CollectCoin()
    {
        coinsCollected++;
        Debug.Log("Coins collected: " + coinsCollected);
    }
}