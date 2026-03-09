using UnityEngine;

public class FarmerLevel : MonoBehaviour
{
    private int _currentExp;
    private int _level = 1;
    private int _maxExp = 50;

    [SerializeField] private GameObject levelUpPanel;

    public void AddExp(int exp)
    {
        _currentExp += exp;
        while (_currentExp >= _maxExp)
        {
            _currentExp -= _maxExp;
            _level++;
            _maxExp = _level * 50;

            TimeController.PauseGame();

            levelUpPanel.SetActive(true);
        }
        
        Debug.Log("레벨: " + _level + " 경험치: " + _currentExp);
    }
    
    public void LevelUp(int index)
    {
        levelUpPanel.SetActive(false);
        TimeController.ResumeGame();
    }
}