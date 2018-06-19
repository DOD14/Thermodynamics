using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour {

	public void ToggleMe()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
