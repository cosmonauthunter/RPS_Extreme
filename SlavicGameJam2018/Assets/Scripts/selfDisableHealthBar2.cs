using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDisableHealthBar2 : MonoBehaviour {

	public void DisableSelf()
    {
        Animator animPlayer = this.GetComponent<Animator>();
        animPlayer.enabled = false; // stop the first animation }
    }
}
