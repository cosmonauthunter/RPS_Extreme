using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDisableHealthBar1 : MonoBehaviour {

	public void DisableSelf()
    {
        Animator animPlayer = this.GetComponent<Animator>();
        animPlayer.enabled = false; // stop the first animation }
    }
}
