using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {
  public float HeightVariance = 1.0f;

  void Update() {
    transform.position += Vector3.up * Mathf.Sin(Time.time) * Time.deltaTime * HeightVariance;
  }
}
