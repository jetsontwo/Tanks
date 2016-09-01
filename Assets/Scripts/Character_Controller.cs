using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	void Move(GameObject go, float moveVert, float Rotate)
    {
        go.transform.Translate(new Vector3(moveVert, 0, 0) * Time.deltaTime);
    }



   
}
