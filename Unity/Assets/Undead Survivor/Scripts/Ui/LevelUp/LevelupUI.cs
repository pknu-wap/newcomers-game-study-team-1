using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class LevelupUI : MonoBehaviour
{
    [SerializeField] private GameObject _explainLabel;
    [SerializeField] private GameObject _sound;

    public void Open(uint level) {
        _explainLabel.GetComponent<TextMeshProUGUI>().text = string.Format("{0}lv->{1}lv!", level - 1, level);
        gameObject.SetActive(true);

        TimeController.StopTime();
        _sound.GetComponent<AudioSource>().Play();
    }

    public void Close() {
        TimeController.RestartTime();
        gameObject.SetActive(false);
    }
}
