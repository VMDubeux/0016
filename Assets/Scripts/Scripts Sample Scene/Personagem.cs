using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Personagem : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 190f; //Apliquei Serialize
    [SerializeField] public float vidaPlayer = 5f; //Apliquei Serialize
    public Canvas canvas;
    public shoot arma;
    public bool moveUp; //Criei variável lógica
    public bool moveDown; //Criei variável lógica
    public bool moveLeft; //Criei variável lógica
    public bool moveRight; //Criei variável lógica
    public bool speedUp; //Criei variável lógica
    public Vector2 limitMove;

    void Update()
    {
        MovementKeys(); //Criei método (1)

        //Retirei os códigos abaixo para realizar testes, com Debug.Log:
        /*float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float transform.position += new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;*/
    }

    void FixedUpdate() //Criei o procedimento FixedUpdate
    {
        Vector3 position = transform.position;
        float moveAmount = moveSpeed * Time.deltaTime;
        
        moveAmount = SuperSpeed(moveAmount); //Criei método (4)

        Vector3 move = Vector3.zero;

        move = MoveConditionals(moveAmount, move); //Criei método (2)
        move = Magnitude(moveAmount, move); //Criei método (3)

        position += move;

        transform.position = position;
    }

    private float SuperSpeed(float moveAmount) //Método (4)
    {
        if (speedUp)
        {
            moveAmount *= 2;
        }

        return moveAmount;
    }

    void MovementKeys() //Método (1)
    {
        moveUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        speedUp = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
       
    }

    private Vector3 MoveConditionals(float moveAmount, Vector3 move) //Método (2)
    {
        if (moveUp && transform.position.y <= limitMove.y)
        {

            move.y += moveAmount;
        }

        if (moveDown && transform.position.y >= -limitMove.y)
        {
            move.y -= moveAmount;
        }

        if (moveLeft && transform.position.x >= -limitMove.x)
        {
            move.x -= moveAmount;
        }

        if (moveRight && transform.position.x <= limitMove.x)
        {
            move.x += moveAmount;
        }

        return move;
    }

    private static Vector3 Magnitude(float moveAmount, Vector3 move) //Método (3)
    {
        float moveMagnitude = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.y, 2));
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        return move;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TiroEnemy")
        {
            vidaPlayer--;
            if (arma.quantidadeArmas != 1)
            {
                arma.quantidadeArmas--;
            }
        }

        if (vidaPlayer == 0 || other.tag == "Inimigo")
        {
            Destroy(gameObject);
            canvas.gameObject.SetActive(true);

        }
    }
}
