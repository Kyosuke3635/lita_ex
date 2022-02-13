using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip RetrySE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRetryButton()
    {
        StartCoroutine("retry");
    }
    private IEnumerator retry()
    {
        audioSource.PlayOneShot(RetrySE);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
