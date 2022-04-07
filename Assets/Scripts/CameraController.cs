using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    public Transform farBackground, middleBackground;

    public float minHeight, maxHeight;

    private Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lerp eklenebilir - geçişlerin daha güzel durması için
        //transform.position = new Vector3(player.position.x,Mathf.Clamp(player.position.y, minHeight, maxHeight),transform.position.z);
        

        farBackground.position = new Vector3(transform.position.x, transform.position.y, 0f);

        middleBackground.position = new Vector3(transform.position.x * 0.5f, transform.position.y * 0.2f, 0f);

    }
    
    private void LateUpdate() {
        /*
        camPos = new Vector3(player.position.x,Mathf.Clamp(player.position.y, minHeight, maxHeight),transform.position.z);
        transform.position = Vector3.Lerp(transform.position, camPos, 0.1f);
        */
        transform.position = new Vector3(player.position.x,Mathf.Clamp(player.position.y, minHeight, maxHeight),transform.position.z);
    }
    
}
