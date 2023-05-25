using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Hurt : MonoBehaviour
{
    private Collision coll;
    private Movement move;
    private AnimationScript anim;
    private SpriteRenderer sp;

    public Color fadeColor;
    public float fadeTime;
    public float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        move = GetComponent<Movement>();
        anim = GetComponentInChildren<AnimationScript>();
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HazardTouch();
    }

    public void HazardTouch()
    {
        Sequence s = DOTween.Sequence();

        if (coll.onHazard)
        {
            move.canMove = false;
            anim.SetTrigger("hurt");
            s.AppendCallback(() => FadeSprite());
            StartCoroutine(LoadLevel());
        }

    }
    public void FadeSprite()
    {
        sp.material.DOKill();
        sp.material.DOColor(fadeColor, fadeTime);
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(deathTimer);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
