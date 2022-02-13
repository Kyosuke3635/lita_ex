using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextStage : MonoBehaviour
{
    public static int stage;
    private int next_stage;
    private AudioSource audioSource;
    public AudioClip NextStageSE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Stage1")
        {
            stage = 1;
        }
        if (SceneManager.GetActiveScene().name == "Stage2")
        {
            stage = 2;
        }
        if (SceneManager.GetActiveScene().name == "Stage3")
        {
            stage = 3;
        }
    }

    public void OnClickNextStageButton()
    {
        next_stage = stage + 1;
        StartCoroutine("nextStage");
        
    }
    private IEnumerator nextStage()
    {
        audioSource.PlayOneShot(NextStageSE);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Stage"+ next_stage);
    }
}
