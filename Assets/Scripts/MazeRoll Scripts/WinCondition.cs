using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public event System.Action OnWinConditionMet; //Event called when the win condition is met

    [SerializeField] private GameObject winScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            winScreen.SetActive(true);
            OnWinConditionMet?.Invoke();
        }
    }
}
