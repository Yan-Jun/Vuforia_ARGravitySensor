using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoxsGrid : MonoBehaviour {

    public int column;
    public float offsetX, offsetY;
    public GameObject[] boxs;
    private Vector3 startPos;
    private Vector3 movePos;

    private void OnValidate()
    {
        startPos = transform.position;
        movePos = startPos;
        for (int i = 0; i < boxs.Length; i++)
        {

            if (i >= column && column > 0)
                boxs[i].transform.position = movePos + Vector3.right * (offsetX * (i % column)) + Vector3.forward * (offsetY * (i / column));
            else
                boxs[i].transform.position = movePos + Vector3.right * (offsetX * i);
        }
    }

}
