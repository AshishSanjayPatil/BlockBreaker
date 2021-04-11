using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    AudioClip blockSound;

    private Level level;

    private GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.AddBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayAudioAndDestroy();
    }

    private void PlayAudioAndDestroy()
    {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        gameStatus.AddScore();
        level.RemoveBlock();
        Destroy(this.gameObject);
    }
}
