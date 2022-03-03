using UnityEngine;

namespace Mirror.Examples.NetworkRoom
{ 
    public class GameController : NetworkBehaviour
    {
        
        public uint[] actualPlayer;    //
     
        public GameObject[] players;    // 
        
        public int[] gridArray;   //0 a 8   

        public LineRenderer endLine;
        
      
        public uint player1;
      
        public uint player2;
      
        public uint playerTurn;

        // Start is called before the first frame update
        void Start()
        {
           
            actualPlayer = new uint[2];
            players = new GameObject[2];

            players = GameObject.FindGameObjectsWithTag("Player");

           
            
            for (int x = 0; x < players.Length; x++) 
            {
               Debug.Log("NETID: "+players[x].GetComponent<PlayerController>().netId);
                actualPlayer[x] = players[x].GetComponent<PlayerController>().netId;
            }

            player1 = actualPlayer[0];          
            player2 = actualPlayer[1];

            playerTurn = player1;
        }


        public void ChangePlayer()
        {
            players = GameObject.FindGameObjectsWithTag("Player");  
            if (playerTurn==player1)
            {
                CheckGame();
                playerTurn = player2;
            }
            else
            {
                CheckGame();
                playerTurn = player1;
            }

        }

        // Update is called once per frame
        void Update()
        {


        }
        
        public void CheckGame()
        {
            // linha X
            if (gridArray[0] == 1 && gridArray[1] == 1 && gridArray[2] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, 0, 31));
                endLine.SetPosition(1, new Vector3(0, 0, 31));
                Debug.Log("fim de jogo X venceu");
            }

            else if (gridArray[3] == 1 && gridArray[4] == 1 && gridArray[5] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, -1.5f, 31));
                endLine.SetPosition(1, new Vector3(0, -1.5f, 31));
                Debug.Log("fim de jogo X venceu");

            }
            else if (gridArray[6] == 1 && gridArray[7] == 1 && gridArray[8] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, -3, 31));
                endLine.SetPosition(1, new Vector3(0, -3, 31));
                Debug.Log("fim de jogo X venceu");
            }

            //coluna X
            else if (gridArray[0] == 1 && gridArray[3] == 1 && gridArray[6] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(0.5f, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(0.5f, -0.5f, 31));
                Debug.Log("fim de jogo X venceu");
            }

            else if (gridArray[1] == 1 && gridArray[4] == 1 && gridArray[7] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(2, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(2, -0.5f, 31));
                Debug.Log("fim de jogo X venceu");
            }
            else if (gridArray[2] == 1 && gridArray[5] == 1 && gridArray[8] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(3.5f, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(3.5f, -0.5f, 31));
                Debug.Log("fim de jogo X venceu");
            }

            //diagonal x

            else if (gridArray[0] == 1 && gridArray[5] == 1 && gridArray[8] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(0, -0.5f, 31));
                Debug.Log("fim de jogo X venceu");
            }
            else if (gridArray[2] == 1 && gridArray[4] == 1 && gridArray[6] == 1)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(0, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(4, -0.5f, 31));
                Debug.Log("fim de jogo X venceu");
            }


            // linha o
            if (gridArray[0] == 2 && gridArray[1] == 2 && gridArray[2] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, 0, 31));
                endLine.SetPosition(1, new Vector3(0, 0, 31));
                Debug.Log("fim de jogo O venceu");
            }

            else if (gridArray[3] == 2 && gridArray[4] == 2 && gridArray[5] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, -1.5f, 31));
                endLine.SetPosition(1, new Vector3(0, -1.5f, 31));
                Debug.Log("fim de jogo O venceu");

            }
            else if (gridArray[6] == 2 && gridArray[7] == 2 && gridArray[8] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, -3, 31));
                endLine.SetPosition(1, new Vector3(0, -3, 31));
                Debug.Log("fim de jogo O venceu");
            }

            //coluna O
            else if (gridArray[0] == 2 && gridArray[3] == 2 && gridArray[6] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(0.5f, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(0.5f, -0.5f, 31));
                Debug.Log("fim de jogo O venceu");
            }

            else if (gridArray[1] == 2 && gridArray[4] == 2 && gridArray[7] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(2, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(2, -0.5f, 31));
                Debug.Log("fim de jogo O venceu");
            }
            else if (gridArray[2] == 2 && gridArray[5] == 2 && gridArray[8] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(3.5f, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(3.5f, -0.5f, 31));
                Debug.Log("fim de jogo O venceu");
            }

            //diagonal x

            else if (gridArray[0] == 2 && gridArray[5] == 2 && gridArray[8] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(4, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(0, -0.5f, 31));
                Debug.Log("fim de jogo O venceu");
            }
            else if (gridArray[2] == 2 && gridArray[4] == 2 && gridArray[6] == 2)
            {
                endLine.enabled = true;
                endLine.SetPosition(0, new Vector3(0, -3.5f, 31));
                endLine.SetPosition(1, new Vector3(4, -0.5f, 31));
                Debug.Log("fim de jogo O venceu");
            }

        }
    }
}
