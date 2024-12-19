using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ClickableObjectSO")]
public class ClickableObjectSO : ScriptableObject {
    public GameObject prefab;
    public string objectName;
}
