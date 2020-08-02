using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

  public float Speed = 1.0f;
  private Enemy _enemy;

  private void Awake() {
    _enemy = GetComponent<Enemy>();
    var collider = GetComponent<Collider2D>();
  }

  void Update() {
    transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

    if (transform.position.x < -14.0f) {
      transform.position += Vector3.right * 30;
      ShowRandomSprite();

      if (_enemy == null) {
        return;
      }

      _enemy.Respawn();
    }
  }

  private void ShowRandomSprite() {
    int index = UnityEngine.Random.Range(0, 3);
    int childCount = transform.childCount;

    for (int i = 0; i < childCount; ++i) {
      Transform child = transform.GetChild(i);
      child.gameObject.SetActive(i == index);
    }
  }

  private void onEnable() {
    ShowRandomSprite();
  }
}
