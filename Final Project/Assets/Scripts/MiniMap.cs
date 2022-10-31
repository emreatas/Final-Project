using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public RectTransform playerInMap;
    public RectTransform map2dEnd;
    public Transform miniMap;
    
    public Transform map3dParent;
    public Transform map3dEnd;

    private Vector3 normalized, mapped;


    void Update()
    {
        normalized = Divide(map3dParent.InverseTransformPoint(this.transform.position), map3dEnd.position - map3dParent.position);

        normalized.y = normalized.z;
        mapped = Multiply(normalized, map2dEnd.localPosition);
        mapped.z = 0;
      // miniMap.localPosition +=new Vector3(this.transform.position.x,this.transform.position.z,1).normalized ;
        playerInMap.localPosition = mapped;
        playerInMap.localEulerAngles = new Vector3(0, 0, this.transform.eulerAngles.y);

    }
    
    private static Vector3 Divide(Vector3 a,Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }

    private static Vector3 Multiply(Vector3 a,Vector3 b)
    {
        return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
    }

}
