using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonKiller : MonoBehaviour
{
  void Update() {
    if (transform.position.y > 6
    || transform.position.y < -5.6) {
      SceneManager.LoadScene(0);
    }

  }

  private void OnCollisionEnter2D(Collision2D collision) {
    SceneManager.LoadScene(0);
  }
}
