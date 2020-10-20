using UnityEngine;

public class PlayerModel
{
    private int _hitPoint;
    private int _maxHitPoint;
    public PlayerModel(int maxHitPoint)
    {
        _maxHitPoint = maxHitPoint;
        _hitPoint = maxHitPoint;
    }
    public int GetHitPoint()
    {
        return _hitPoint;
    }
    public void ChangeHitPoint(int hpChange)
    {
        if (hpChange < 0)
        {
            _hitPoint += hpChange;
            if (_hitPoint <= 0)
            {
                _hitPoint = 0;
            }
        }
        else
        {
            if (_hitPoint < _maxHitPoint)
            {
                _hitPoint += hpChange;
                if (_hitPoint > _maxHitPoint)
                {
                    _hitPoint = _maxHitPoint;

                }
            }
        }
    }
}