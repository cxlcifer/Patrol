using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _delayBeforeMoving;
    
    private float _currentTime;
    private int _startIndex = 0;
    private int _endIndex = 1;
    private void Update()
    {
        _currentTime += Time.deltaTime;
        var progress = _currentTime * _speed;

        var newPosition = MovingToNextPoint(progress);
        transform.position = newPosition;

        if (transform.position == _points[_endIndex].position)
        {
            if (_currentTime > _delayBeforeMoving)
            {
                _startIndex++;
                _endIndex++;


                if (_endIndex == _points.Count)
                {
                    _endIndex = 0;
                }

                if (_startIndex == _points.Count)
                {
                    _startIndex = 0;
                }

                _currentTime = 0f;
            }
        }
    }

    private Vector3 MovingToNextPoint(float progress)
    {
        var position = Vector3.Lerp(_points[_startIndex].position,_points[_endIndex].position,progress);
        return position;
    }
}
