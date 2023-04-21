using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime = 4f; // tempo total em segundos
    private float currentTime = 0f; // tempo atual em segundos
    private bool isRunning = false; // indicador se o timer est� rodando

  
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

    // m�todo para iniciar o timer
    public void StartTimer()
    {
        currentTime = 0f;
        isRunning = true;
    }

    // m�todo para parar o timer
    public void StopTimer()
    {
        isRunning = false;
    }
}