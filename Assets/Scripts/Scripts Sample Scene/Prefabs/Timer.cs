using UnityEngine;

public class Timer : MonoBehaviour
{
    /*public float totalTime; // tempo total em segundos
    private float currentTime; // tempo atual em segundos
    private bool isRunning; // indicador se o timer está rodando

  
    private void Start()
    {
        
        StartTimer();
    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            // atualizar o tempo atual
            currentTime += Time.fixedDeltaTime;

            // verificar se o tempo acabou
            if (currentTime >= totalTime)
            {
                // parar o timer
                StopTimer();
                Destroy(gameObject);    

            }
        }
    }

    // método para iniciar o timer
    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
    }

    // método para parar o timer
    public void StopTimer()
    {
        isRunning = false;
    }*/
    private void Update()
    {

        if (transform.position.x < -320)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 315) 
        { 
            Destroy(gameObject); 
        }
        
    }
}