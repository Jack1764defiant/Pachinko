using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject ball;
    public int upperBound;
    public int lowerBound;
    public Text showBalls;
    public int ballCount;
    // Start is called before the first frame update
    void Start()
    {
        showBalls.text = "Balls: " + ballCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit)){
                Vector3 spawnPos = new Vector3(-1, 29f, raycastHit.point.z);
                if (spawnPos.z < upperBound && spawnPos.z > lowerBound && ballCount >0)
                {
                    Instantiate(ball, spawnPos, ball.transform.rotation);
                    ballCount--;
                    showBalls.text = "Balls: " + ballCount;
                }
            }
        }
    }
}
