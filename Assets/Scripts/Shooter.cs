using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  public GameObject ProjectilePrefab;

  void Start() {
    
  }

  void Update() {
    if (Input.GetButtonDown("Fire2")) {
      var width = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
      var offset = width / 2;
      Vector3 newPos = transform.position;
      newPos.x += offset;

      var projectile = Instantiate(ProjectilePrefab,
        newPos, ProjectilePrefab.transform.rotation);
    }
  }
}
