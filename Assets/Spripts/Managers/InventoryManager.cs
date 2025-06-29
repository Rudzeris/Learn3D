using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    private int count = 0;

    private void Start()
    {
        Messenger.AddListener(GameEvents.ColletableItem, Increase);

    }

    public void Increase()
    {
        count++;
        
        Debug.Log($"Count: {count}");
    }
}