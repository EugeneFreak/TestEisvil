using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f, 1.5f, -3.5f);

    private Transform target;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

	private void LateUpdate()
	{
		this.transform.localPosition = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
	}
}
