using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        public GameObject xPrefab;
        public GameObject oPrefab;

        public List<MovesAndScores> rootsChildrenScores;

        public TextMeshProUGUI statusMessage;
        public TextMeshProUGUI restartMessage;


        Node[,] grid = new Node[3, 3];

        void Update()
        {
            if (!IsGameOver())
            {
                if (Input.GetKeyDown("z") && IsValidMove(0, 0))
                {
                    Instantiate(xPrefab, new Vector3(0,0,0), Quaternion.Euler(90,0,0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 0, y = 0, player = 1};
                    //player = 1 means that it is the player and not the computer
                    grid[node.x, node.y] = node; //Inserting this Node into the grid
                    CallMinimax(0, 1);

                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }

                }

                if (Input.GetKeyDown("a") && IsValidMove(0, 1))
                {
                    Instantiate(xPrefab, new Vector3(0, 1, 0), Quaternion.Euler(90, 0, 0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 0, y = 1, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);

                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown("q") && IsValidMove(0, 2))
                {
                    Instantiate(xPrefab, new Vector3(0, 2, 0), Quaternion.Euler(90, 0, 0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 0, y = 2, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);

                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Keypad2) && IsValidMove(1, 0))
                {
                    Instantiate(xPrefab, new Vector3(1, 0, 0), Quaternion.Euler(90, 0, 0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 1, y = 0, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);
                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Keypad5) && IsValidMove(1, 1))
                {
                    Instantiate(xPrefab, new Vector3(1, 1, 0), Quaternion.Euler(90, 0, 0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 1, y = 1, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);
                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Keypad8) && IsValidMove(1, 2))
                {
                    Instantiate(xPrefab, new Vector3(1, 2, 0), Quaternion.Euler(90, 0, 0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 1, y = 2, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);
                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Keypad3) && IsValidMove(2, 0))
                {
                    Instantiate(xPrefab, new Vector3(2, 0, 0), Quaternion.Euler(90, 0, 0));
                    
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 2, y = 0, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);
                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 1), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Keypad6) && IsValidMove(2, 1))
                {
                    Instantiate(xPrefab, new Vector3(2, 1, 0), Quaternion.Euler(90, 0, 0));
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 2, y = 1, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);
                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }

                if (Input.GetKeyDown(KeyCode.Keypad9) && IsValidMove(2, 2))
                {
                    Instantiate(xPrefab, new Vector3(2, 2, 0), Quaternion.Euler(90, 0, 0));
                    
                    //When the user adds a new 'X' to the grid, a node with those coordinates is added to the list of nodes
                    Node node = new Node {x = 2, y = 2, player = 1};
                    grid[node.x, node.y] = node;
                    CallMinimax(0, 1);
                    Node best = ReturnBestMove();
                    if (IsValidMove(best.x, best.y))
                    {
                        Instantiate(oPrefab, new Vector3(best.x, best.y, 0), Quaternion.identity);
                        best.player = 2;
                        grid[best.x, best.y] = best;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game");
            }

        }

        private bool IsGameOver()
        {
            if (GetMoves().Capacity == 0)
            {
                statusMessage.text = "It's a draw!";
                restartMessage.text = "Press (R) to try again!";
                Debug.Log("It's a draw!");
                return true;
            }
            if (HasOWon())
            {
                statusMessage.text = "You Won!";
                restartMessage.text = "Press (R) to try again!";
                Debug.Log("You Won!");
                return true;
            }
            if (HasXWon())
            {
                statusMessage.text = "You Lost!";
                restartMessage.text = "Press (R) to try again!";
                Debug.Log("You lost!");
                return true;
            }
            return false;
        }

        public bool HasOWon()
        {
            //check to see if the positions you're about to check actually exist in the grid
            if (grid[0, 0] != null && grid[1, 1] != null && grid[2, 2] != null)
            {
                //check to see if there is a diagonal win for the O player
                if (grid[0, 0].player == grid[1, 1].player && grid[0, 0].player == grid[2, 2].player && grid[0, 0].player == 1)
                    return true;
            }
            if (grid[0, 2] != null && grid[1, 1] != null && grid[2, 0] != null)
            {
                //diagonal win
                if (grid[0, 2].player == grid[1, 1].player && grid[0, 2].player == grid[2, 0].player && grid[0, 2].player == 1)
                    return true;
            }
            //Column Wins
            for (int i = 0; i < 3; ++i)
            {
                if (grid[i, 0] != null && grid[i, 1] != null && grid[i, 2] != null)
                {
                    if (grid[i, 0].player == grid[i, 1].player && grid[i, 0].player == grid[i, 2].player && grid[i, 0].player == 1)
                        return true;
                }
                if (grid[0, i] != null && grid[1, i] != null && grid[2, i] != null)
                {
                    if (grid[0, i].player == grid[1, i].player && grid[0, i].player == grid[2, i].player && grid[0, i].player == 1)
                        return true;
                }
            }
            return false; //there are no winning solutions on the board for O
        }

        public bool HasXWon()
        {
            if (grid[0, 0] != null && grid[1, 1] != null && grid[2, 2] != null)
            {
                if (grid[0, 0].player == grid[1, 1].player && grid[0, 0].player == grid[2, 2].player && grid[0, 0].player == 2)
                    return true;
            }
            if (grid[0, 2] != null && grid[1, 1] != null && grid[2, 0] != null)
            {
                if (grid[0, 2].player == grid[1, 1].player && grid[0, 2].player == grid[2, 0].player && grid[0, 2].player == 2)
                    return true;
            }

            for (int i = 0; i < 3; ++i)
            {
                if (grid[i, 0] != null && grid[i, 1] != null && grid[i, 2] != null)
                {
                    if (grid[i, 0].player == grid[i, 1].player && grid[i, 0].player == grid[i, 2].player && grid[i, 0].player == 2)
                        return true;
                }
                if (grid[0, i] != null && grid[1, i] != null && grid[2, i] != null)
                {
                    if (grid[0, i].player == grid[1, i].player && grid[0, i].player == grid[2, i].player && grid[0, i].player == 2)
                        return true;
                }
            }
            return false; //there are no winning solutions on the board for X
        }


        //returns a list of MNodes, each Node being a position that is empty and available
        List<Node> GetMoves()
        {
            List<Node> result = new List<Node>();
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (grid[row, col] == null)
                    {
                        Node newNode = new Node {x = row, y = col};
                        result.Add(newNode); //if the space is empty, add it to the list of results
                    }
                }
            }
            return result;
        }

        public Node ReturnBestMove()
        {
            int MAX = -100000;
            int best = -1;

            //iterates through rootsChildrenScores to get the best move
            for (int i = 0; i < rootsChildrenScores.Count; i++)
            {
                //also makes sure that the position in the grid is not occupied
                if (MAX < rootsChildrenScores[i].score && IsValidMove(rootsChildrenScores[i].point.x, rootsChildrenScores[i].point.y))
                {
                    MAX = rootsChildrenScores[i].score;
                    best = i;
                }
            }
            if (best > -1)
                return rootsChildrenScores[best].point;
            Node blank = new Node {x = 0, y = 0};
            return blank;
        }

        public bool IsValidMove(int x, int y)
        {
            if (grid[x, y] == null)
                return true;
            return false;
        }

        //returns the minimum element of the list passed to it
        public int ReturnMin(List<int> list)
        {
            int min = 100000;
            int index = -1;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] < min)
                {
                    min = list[i];
                    index = i;
                }
            }
            return list[index];
        }

        //returns the maximum element of the list passed to it
        public int ReturnMax(List<int> list)
        {
            int max = -100000;
            int index = -1;
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i] > max)
                {
                    max = list[i];
                    index = i;
                }
            }
            return list[index];
        }

        //calls the minimax function with a given depth and turn
        public void CallMinimax(int depth, int turn)
        {
            rootsChildrenScores = new List<MovesAndScores>();
            Minimax(depth, turn);
        }

        public int Minimax(int depth, int turn)
        {

            if (HasXWon()) return +1; //+1 for a player win
            if (HasOWon()) return -1; //-1 for a computer win

            List<Node> pointsAvailable = GetMoves();
            if (pointsAvailable.Capacity == 0) return 0;

            List<int> scores = new List<int>();

            for (int i = 0; i < pointsAvailable.Count; i++)
            {
                Node point = pointsAvailable[i];

                //Select the highest from the minimax call on X's turn
                if (turn == 1)
                {
                    Node x = new Node {x = point.x, y = point.y, player = 2};
                    grid[point.x, point.y] = x;

                    int currentScore = Minimax(depth + 1, 2);
                    scores.Add(currentScore);

                    if (depth == 0)
                    {
                        MovesAndScores m = new MovesAndScores(currentScore, point);
                        m.point = point;
                        m.score = currentScore;
                        rootsChildrenScores.Add(m);
                    }

                }
                //Select the lowest from the minimax call on O's turn
                else if (turn == 2)
                {
                    Node o = new Node {x = point.x, y = point.y, player = 1};
                    grid[point.x, point.y] = o;
                    int currentScore = Minimax(depth + 1, 1);
                    scores.Add(currentScore);
                }
                grid[point.x, point.y] = null; //reset the point
            }
            return turn == 1 ? ReturnMax(scores) : ReturnMin(scores);
        }
    }
}
