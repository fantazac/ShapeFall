using UnityEngine;
using System.Collections;

public class PointsStored : MonoBehaviour
{
    [SerializeField]
    private int _orbsToCatchBeforePowerUp = 10;

    private int _orbsInComboBar = 0;

    public int OrbsToCatchBeforePowerUp { get { return _orbsToCatchBeforePowerUp; } }

    public delegate void OnComboBarFullHandler();
    public event OnComboBarFullHandler OnComboBarFull;

    private void Start()
    {
        GetComponentInParent<CatchOrb>().OnOrbCaught += AddOrb;
    }

    private void AddOrb()
    {
        _orbsInComboBar++;

        if(_orbsInComboBar == _orbsToCatchBeforePowerUp)
        {
            OnComboBarFull();
            _orbsInComboBar = 0;
        }
    }

}
