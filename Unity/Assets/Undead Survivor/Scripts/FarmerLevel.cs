using UnityEngine;

public class FarmerLevel : MonoBehaviour
{
    private float _exp = 0;
    private uint _level = 0;
    private uint _maxExp = 25;

    public void AddExp(float exp) {
        _exp += exp;
        while(_exp >= _maxExp) {
            _exp -= _maxExp;
            _level++;
            _maxExp = _level * 50;
            Debug.Log(string.Format("레벨 업! {0}lv -> {1}lv", _level - 1, _level));
        }

        Debug.Log(string.Format("경험치: {0}, 레벨: {1}", _exp, _level));
    }
}
