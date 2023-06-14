using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Load_Next_Scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void LoadNextSceneAsync()
    {
        var asyncOperation = SceneManager.LoadSceneAsync("GLI_1", LoadSceneMode.Single);

        while (!asyncOperation.isDone)
        {
            await Task.Yield();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LoadNextSceneAsync();
        }
    }
}
