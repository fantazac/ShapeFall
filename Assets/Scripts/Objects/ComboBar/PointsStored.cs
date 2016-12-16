using UnityEngine;
using System.Collections;

public class PointsStored : MonoBehaviour
{
    [SerializeField]
    private GameObject _catchBar;

    [SerializeField]
    private int _orbsToCatchBeforePowerUp = 10;

    public int OrbsToCatchBeforePowerUp { get { return _orbsToCatchBeforePowerUp; } }
    public int OrbsInComboBar { get; private set; }

    public delegate void OnComboBarFullHandler();
    public event OnComboBarFullHandler OnComboBarFull;

    public delegate void OnEmptyBarHandler();
    public event OnEmptyBarHandler OnEmptyBar;

    private void Start()
    {
        GetComponentInParent<CatchOrb>().OnOrbCaught += AddOrb;
        _catchBar.GetComponent<CatchShape>().OnInvalidShapeCaught += ResetCombo;
    }

    private void AddOrb()
    {
        OrbsInComboBar++;

        if(OrbsInComboBar % _orbsToCatchBeforePowerUp == 0)
        {
            OnComboBarFull();
        }
    }

    private void ResetCombo()
    {
        OrbsInComboBar = 0;
        OnEmptyBar();
    }
}
