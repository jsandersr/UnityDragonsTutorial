using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;


public class FireBall : MonoBehaviour
{
  [SerializeField]
  private Vector2 _startingVelocity;

  [SerializeField]
  private List<AudioClip> _triggerAudioClips;

  [SerializeField]
  private List<AudioClip> _detonateAudioClips;

  private Animator _animator;

  void Start() {
    _animator = GetComponent<Animator>();

    GetComponent<Rigidbody2D>().velocity = _startingVelocity;
    Destroy(gameObject, 10);

    int index = UnityEngine.Random.Range(0, _triggerAudioClips.Count);
    var audioClip = _triggerAudioClips[index];
    var audioSource = GetComponent<AudioSource>();
    audioSource.clip = audioClip;
    audioSource.Play();

    if (_animator != null) {
      _animator.SetBool("IsAlive", true);
    }
  }

  void OnCollisionEnter2D(Collision2D collision) {
    var enemy = collision.collider.GetComponent<Enemy>();
    if (enemy != null) {
      enemy.Die();
    }

    if (_animator != null) {
      _animator.SetBool("IsAlive", false);
    }

    int index = UnityEngine.Random.Range(0, _detonateAudioClips.Count);
    var audioClip = _detonateAudioClips[index];
    var audioSource = GetComponent<AudioSource>();
    audioSource.clip = audioClip;
    audioSource.Play();


    //Destroy(gameObject, 1.0f);
  }
}
