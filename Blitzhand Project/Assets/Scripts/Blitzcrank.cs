using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Blitzcrank : MonoBehaviour
{
    private bool isMoving = false;
    public float moveSpeed = 5f;
    public Transform target;
    private Vector3 initialPosition;
    public GameObject hookHand;
    public Transform socket;

    public AudioSource audioData;

    public LineRenderer lineRenderer;
    void Start()
    {
        initialPosition = hookHand.transform.position;
        //lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        UpdateLineRenderer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            MoveToTarget(target.position);
            audioData.Play(0);
        }
        // Line Renderer'ý güncelle
        UpdateLineRenderer();
    }

    public void HookButton()
    {
        if (!isMoving)
        {
            MoveToTarget(target.position);
            audioData.Play(0);
        }

    }
    void MoveToTarget(Vector3 targetPosition)
    {
        isMoving = true;
        StartCoroutine(MoveCoroutine(targetPosition));
    }
    IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        while (Vector3.Distance(hookHand.transform.position, targetPosition) > 0.1f)
        {
            hookHand.transform.position = Vector3.MoveTowards(hookHand.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Hedefe ulaþýldýðýnda geri dön
        ReturnToInitialPosition();
    }

    void ReturnToInitialPosition()
    {
        StartCoroutine(ReturnCoroutine(initialPosition));
    }

    IEnumerator ReturnCoroutine(Vector3 initialPosition)
    {
        while (Vector3.Distance(hookHand.transform.position, initialPosition) > 0.1f)
        {
            hookHand.transform.position = Vector3.MoveTowards(hookHand.transform.position, initialPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    void UpdateLineRenderer()
    {
        if (hookHand != null && socket !=null)
        {
            // Line Renderer'ýn baþlangýç ve bitiþ noktalarýný güncelle
            lineRenderer.SetPosition(0, socket.position);
            lineRenderer.SetPosition(1, hookHand.transform.position);
        }
    }


}
