using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRIKRig : MonoBehaviour {
    public VRMap _head;
    public VRMap _leftHand;
    public VRMap _rightHand;
    
    public Transform _headConstraint;
    public Vector3 _headBodyOffset;

    void Start() {
        _headBodyOffset = transform.position - _headConstraint.position;
    }

    void LateUpdate() {
        transform.position = _headConstraint.position + _headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(_headConstraint.up, Vector3.up).normalized;

        _head.Map();
        _leftHand.Map();
        _rightHand.Map();
    }
}

[System.Serializable]
public class VRMap {
    public Transform _vrTarget;
    public Transform _rigTarget;
    public Vector3 _trackingPositingOffset;
    public Vector3 _trackingRotationOffset;

    public void Map() {
        _rigTarget.position = _vrTarget.TransformPoint(_trackingPositingOffset);
        _rigTarget.rotation =_vrTarget.rotation * Quaternion.Euler(_trackingRotationOffset);
    }
}
