using UnityEngine;
using System.Collections;

public class PointsStored : MonoBehaviour
{
    [SerializeField]
    private int _orbsToCatchBeforePowerUp = 10;

    public int OrbsToCatchBeforePowerUp { get { return _orbsToCatchBeforePowerUp; } }
    public int OrbsInComboBar { get; private set; }

    public delegate void OnComboBarFullHandler();
    public event OnComboBarFullHandler OnComboBarFull;

    private void Start()
    {
        GetComponentInParent<CatchOrb>().OnOrbCaught += AddOrb;
    }

    private void AddOrb()
    {
        OrbsInComboBar++;

        if(OrbsInComboBar % _orbsToCatchBeforePowerUp == 0)
        {
            OnComboBarFull();
        }
    }
}
