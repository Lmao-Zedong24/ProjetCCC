using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [SerializeField] float zoomOutSpeedDegreePerSecond = 2;
    [SerializeField] float zoomInSpeedDegreePerSecond = 5;
    [SerializeField] float defaultFOVDegree = 10;
    [SerializeField] float zoomOutFOVDegree = 25;

    Vector3 _localPos;
    float   _targetFOV;
    bool    _isZoom;

    HashSet<GameObject> _collidingGOs;

    void Awake()
    {
        _collidingGOs = new HashSet<GameObject>();
        _targetFOV = defaultFOVDegree;
        _isZoom = false;

        _localPos = transform.localPosition;
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
        transform.position = transform.parent.position + _localPos;


        if (!_isZoom)
            return;

        bool zoomCondition = _targetFOV == zoomOutFOVDegree ?   _virtualCamera.m_Lens.FieldOfView < _targetFOV :
                                                                _virtualCamera.m_Lens.FieldOfView > _targetFOV;

        if (zoomCondition)
            _virtualCamera.m_Lens.FieldOfView += (_targetFOV == zoomOutFOVDegree? zoomOutSpeedDegreePerSecond : -zoomInSpeedDegreePerSecond) * Time.deltaTime;
        else
            _isZoom = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.GetMask("Player"))
            return;

        if (_collidingGOs.Count == 0)
        {
            _targetFOV = defaultFOVDegree;
            _isZoom = true;
        }

        _collidingGOs.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.GetMask("Player"))
            return;

        _collidingGOs.Remove(other.gameObject);

        if (_collidingGOs.Count == 0)
        {
            _targetFOV = zoomOutFOVDegree;
            _isZoom = true;
        }
    }
}
