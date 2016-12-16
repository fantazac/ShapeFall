using UnityEngine;
using System.Collections;

public class MoveOrb : MonoBehaviour
{
    [SerializeField]
    private float _timeInAir = 1;

    [SerializeField]
    private float _distanceBelowCatchBar = 4;

    private float _timeInAirCount = 0;
    private float _newXPosition = 0;
    private float _newYPosition = 0;
    private float _lowestYUnderCatchBar = 0;
    private float _horizontalSpeed = 0;
    private float _initialVerticalSpeed = 0;
    private float _verticalAcceleration = 0;
    private Vector3 _startingPosition;
    private float _halfOfTimeInAir = 0;

    public void CalculateTrajectory(GameObject catchBar, GameObject comboBar)
    {
        _halfOfTimeInAir = _timeInAir * 0.5f;
        _lowestYUnderCatchBar = (-catchBar.transform.localScale.y * 0.5f) - _distanceBelowCatchBar;
        _verticalAcceleration = -_lowestYUnderCatchBar / (0.5f * _halfOfTimeInAir * _halfOfTimeInAir);
        _initialVerticalSpeed = -_verticalAcceleration * _halfOfTimeInAir;
        _horizontalSpeed = (comboBar.transform.position.x - transform.position.x) / _timeInAir;
        _startingPosition = transform.position;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            _newXPosition = _startingPosition.x + (_horizontalSpeed * _timeInAirCount);

            _newYPosition = CalculateVerticalPosition();

            transform.position += (Vector3.right * (_newXPosition - transform.position.x))
                + (Vector3.up * (_newYPosition - transform.position.y));
            _timeInAirCount += Time.deltaTime;

            yield return null;
        }
    }

    private float CalculateVerticalPosition()
    {
        return _startingPosition.y + (_initialVerticalSpeed * _timeInAirCount) +
                (0.5f * _verticalAcceleration * _timeInAirCount * _timeInAirCount);
    }
}
