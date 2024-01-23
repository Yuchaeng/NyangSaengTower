using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    private void LateUpdate()
    {
        if (_target.transform.position.y >= 2f)
        {
            transform.position = new Vector3(0f, _target.transform.position.y + 0.4f, -10);

        }
        //transform.position = _target.transform.position + cameraPos;
    }
}
