using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/TileSO")]
public class TileSO : ScriptableObject {
    public GameObject prefab;
    public string objectName;
}
