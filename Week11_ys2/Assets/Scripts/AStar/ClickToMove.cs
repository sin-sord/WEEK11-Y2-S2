using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private Seeker seekerAI;
    [SerializeField] LayerMask raycastLayers;

    private void Awake()
    {
        if (seekerAI == null) seekerAI = GetComponent<Seeker>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ThreeDimensionClick(ray);
        }
    }

    private void ThreeDimensionClick(Ray ray)
    {

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, raycastLayers))
        {
            Debug.LogError("Clicked!");
            seekerAI.StartPath(transform.position, hit.point, OnPathComplete);
        }
            
    }

    private void OnPathComplete(Path p)
    {
        
        Debug.Log($"Path calculation finished. Any errors? - {p.errorLog}");
    }
}
