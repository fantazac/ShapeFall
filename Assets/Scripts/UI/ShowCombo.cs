using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowCombo : MonoBehaviour
{
    [SerializeField]
    private GameObject _comboBar;

    private TextMesh _combo;
    private PointsStored _pointsStored;

    private void Start()
    {
        _combo = GetComponent<TextMesh>();
        _combo.text = "0";

        _comboBar.GetComponent<CatchOrb>().OnOrbCaught += UpdateCombo;
        _comboBar.GetComponentInChildren<PointsStored>().OnEmptyBar += UpdateCombo;
        _pointsStored = _comboBar.GetComponentInChildren<PointsStored>();
    }

    private void UpdateCombo()
    {
        _combo.text = _pointsStored.OrbsInComboBar.ToString();
    }
}
