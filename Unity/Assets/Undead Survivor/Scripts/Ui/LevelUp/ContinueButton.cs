using UnityEngine;
using UnityEngine.UIElements;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    public void OnClick() {
        TimeController.RestartTime();
        UI.SetActive(false);
    }
}
