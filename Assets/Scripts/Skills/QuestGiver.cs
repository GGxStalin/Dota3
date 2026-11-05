using UnityEngine;

public class QuestGiver : MonoBehaviour
{

    public float questZone = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //включить панель квеста
            print("Игрок зашел в зону квеста");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //выключаем панель квеста
            print("Игрок вышел из зоны квеста");
        }
    }
}
