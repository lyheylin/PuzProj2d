using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {
    [SerializeField] ClickableObjectSO clickableObjectSO;
    public ClickableObjectSO GetClickableObjectSO() {
        return clickableObjectSO;
    }
}
