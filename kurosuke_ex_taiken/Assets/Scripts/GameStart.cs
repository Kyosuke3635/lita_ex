using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip GameStartSE;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickGameStartButton()
    {
        //クリック音を鳴らしきるため
        StartCoroutine("gameStart");
       
    }
    private IEnumerator gameStart()
    {
        audioSource.PlayOneShot(GameStartSE);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Stage1");
    }
}
