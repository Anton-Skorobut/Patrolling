using System;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _points = new();

    [SerializeField]
    private float _speed = 2f;

    [SerializeField]
    private float _waitingTime = 5f;
    
    private Transform _destination;
    private int _index = 0;
    private float _currentTime;

    private void Start()
    {
        SelectDestination();
    }

    private void Update()
    {

        if (_currentTime < _waitingTime)
        {
            _currentTime += Time.deltaTime;
            return;
        }
        var travelDistance = _speed * Time.deltaTime;
        transform.LookAt(_destination);
        var newPosition = Vector3.MoveTowards(transform.position, _destination.position, travelDistance);
        transform.position = newPosition;
        if (transform.position == _destination.position)
        {
            _index++;
            SelectDestination();
            _currentTime = 0f;
        }
    }

    private void SelectDestination()
    {
        if (_index > _points.Count - 1)
        {
            _index = 0;
        }
        _destination = _points[_index].transform;
    }
}
