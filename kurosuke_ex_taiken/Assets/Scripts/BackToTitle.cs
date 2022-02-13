using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip BackSE;
    private GameObject BGM;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        BGM = GameObject.Find("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickBackToTitleButton()
    {
        StartCoroutine("backToTitle");
        SceneManager.LoadScene("Title");
    }
    private IEnumerator backToTitle()
    {
        Destroy(BGM);
        audioSource.PlayOneShot(BackSE);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Title");
    }
}
