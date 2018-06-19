using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPool : MonoBehaviour {

	public void ValueChanged(int n)
	{
        EventManager.TriggerEvent ("valueChanged"+ n.ToString());
        Debug.Log("valueChanged" + n.ToString() + " was called");
	}

}
