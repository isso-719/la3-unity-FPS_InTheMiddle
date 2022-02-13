using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public Camera playerCamera;
    int killedEnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    void Shot()
    {
        int distance = 10;
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = playerCamera.ScreenPointToRay(center);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            Debug.Log("ぶつかったオブジェクトの名前: " + hitInfo.collider.name);
            Debug.Log("ぶつかったオブジェクトの名前: " + hitInfo.distance);
            Debug.Log("ぶつかったオブジェクトの名前: " + hitInfo.point);
        }

        if (hitInfo.collider.tag == "Enemy")
        {
            killedEnemyCount++;
            Debug.Log("倒した敵: " + killedEnemyCount);

            if (hitInfo.collider.name == "Red")
            {
                Renderer redRenderer = hitInfo.collider.gameObject.GetComponent<Renderer>();
                redRenderer.material.color = Color.red;
            } else
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }
}
