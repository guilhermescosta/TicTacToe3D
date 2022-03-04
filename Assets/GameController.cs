using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;


public class GameController : NetworkBehaviour
{

    public int actualPlayer;    //   1 = O     2 = X
    
    public Material circleMaterial;

    public Material crossMaterial;

   // [SyncVar]
   // public int pos1,pos2,pos3,pos4,pos5,pos6,pos7,pos8,pos9;
    
    public int[] gridArray;   //0 a 7   
    
    
    public GameObject[] gridPosition;

    public Text victoryText;
    public GameObject victoryCanvas;

    public LineRenderer endLine;  // utilizado para marcar a linha sobre a posição vencedora. ! Distorce conforme a resolução !


    [Command(requiresAuthority = false)]
    public void CmdUpdateGrid(int player, int grid) 
    {
        RpcUpdateGrid(player, grid);
    }

    [ClientRpc]
    void RpcUpdateGrid(int player, int grid)
    {
        Debug.Log("Jogador "+player + " grid "+ grid);

        if (player == 1)
        {
            gridPosition[grid].GetComponent<Renderer>().material = circleMaterial;
            gridArray[grid] = 1;
            actualPlayer = 2;
        }
        else if (player == 2) 
        {
            gridPosition[grid].GetComponent<Renderer>().material = crossMaterial;
            gridArray[grid] = 2;
            actualPlayer = 1;
        }

        //CmdCheckGame();
        
    }

  
    // Start is called before the first frame update
    void Start()
    {
        actualPlayer = 1;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    [Command(requiresAuthority = false)]
    public void CmdCheckGame()
    {
        RpcCheckGame();
    }

    [ClientRpc]
    public void RpcCheckGame() 
    {
        // linha X
        if (gridArray[0] == 1 && gridArray[1] == 1 && gridArray[2] == 1)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;
            Debug.Log("fim de jogo X venceu");
        }

        else if (gridArray[3] == 1 && gridArray[4] == 1 && gridArray[5] == 1)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo X venceu");

        }
        else if (gridArray[6] == 1 && gridArray[7] == 1 && gridArray[8] == 1)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo X venceu");
        }

        //coluna X
        else if (gridArray[0] == 1 && gridArray[3] == 1 && gridArray[6] == 1)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo X venceu");
        }
            
        else if (gridArray[1] == 1 && gridArray[4] == 1 && gridArray[7] == 1) 
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo X venceu");
        }
        else if (gridArray[2] == 1 && gridArray[5] == 1 && gridArray[8] == 1)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo X venceu");
        }

        //diagonal x

        else if (gridArray[0] == 1 && gridArray[5] == 1 && gridArray[8] == 1) 
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo X venceu");
        }
        else if (gridArray[2] == 1 && gridArray[4] == 1 && gridArray[6] == 1)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 1 é o Vencedor!!!";
            Time.timeScale = 0;
            Debug.Log("fim de jogo X venceu");
        }


        // linha o
        if (gridArray[0] == 2 && gridArray[1] == 2 && gridArray[2] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }

        else if (gridArray[3] == 2 && gridArray[4] == 2 && gridArray[5] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");

        }
        else if (gridArray[6] == 2 && gridArray[7] == 2 && gridArray[8] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }

        //coluna O
        else if (gridArray[0] == 2 && gridArray[3] == 2 && gridArray[6] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }

        else if (gridArray[1] == 2 && gridArray[4] == 2 && gridArray[7] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }
        else if (gridArray[2] == 2 && gridArray[5] == 2 && gridArray[8] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }

        //diagonal O

        else if (gridArray[0] == 2 && gridArray[5] == 2 && gridArray[8] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }
        else if (gridArray[2] == 2 && gridArray[4] == 2 && gridArray[6] == 2)
        {
            victoryCanvas.SetActive(true);
            victoryText.text = "Fim de Jogo\n  Jogador 2 é o Vencedor!!!";
            Time.timeScale = 0;

            Debug.Log("fim de jogo O venceu");
        }

    }    

    void Result() 
    {

    }

}
