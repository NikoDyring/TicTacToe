﻿using System;
using UnityEngine;

namespace Assets.Scripts.TicTacToe
{
    public class MinMax : MonoBehaviour
    {
        /// <summary>
        /// For Reference ive used this:
        /// https://www.geeksforgeeks.org/minimax-algorithm-in-game-theory-set-3-tic-tac-toe-ai-finding-optimal-move/
        /// though beware there are errors in that code so it cant be used copy-paste style.
        /// ive fixed some of the errors, the AI is mostly unbeatable but in some fringe cases it makes odd choices.
        /// </summary>
        static char player = 'x', opponent = 'o';
        private static int[,] results = new int[3,3];
        static Boolean isMovesLeft(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i, j] == '_')
                    return true;
            return false;
        }
        static int evaluate(char[,] b)
        {
            // Checking for Rows for X or O victory. 
            for (int row = 0; row < 3; row++)
            {
                if (b[row, 0] == b[row, 1] &&
                    b[row, 1] == b[row, 2])
                {
                    if (b[row, 0] == player)
                        return +10;
                    else if (b[row, 0] == opponent)
                        return -10;
                }
            }

            // Checking for Columns for X or O victory. 
            for (int col = 0; col < 3; col++)
            {
                if (b[0, col] == b[1, col] &&
                    b[1, col] == b[2, col])
                {
                    if (b[0, col] == player)
                        return +10;

                    else if (b[0, col] == opponent)
                        return -10;
                }
            }

            // Checking for Diagonals for X or O victory. 
            if (b[0, 0] == b[1, 1] && b[1, 1] == b[2, 2])
            {
                if (b[0, 0] == player)
                    return +10;
                else if (b[0, 0] == opponent)
                    return -10;
            }

            if (b[0, 2] == b[1, 1] && b[1, 1] == b[2, 0])
            {
                if (b[0, 2] == player)
                    return +10;
                else if (b[0, 2] == opponent)
                    return -10;
            }

            // Else if none of them have won then return 0 
            return 0;
        }
        static int minimax(char[,] board, int depth, Boolean isMax, int alpha, int beta)
        {
            int score = evaluate(board);

            // If Maximizer has won the game  
            // return his/her evaluated score 
            if (score == 10)
                return score-depth;

            // If Minimizer has won the game  
            // return his/her evaluated score 
            if (score == -10)
                return score-depth;

            // If there are no more moves and  
            // no winner then it is a tie 
            if (isMovesLeft(board) == false)
                return 0;

            // If this maximizer's move 
            if (isMax)
            {
                int best = -1000;

                // Traverse all cells 
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty 
                        if (board[i, j] == '_')
                        {
                            // Make the move 
                            board[i, j] = player;

                            // Call minimax recursively and choose 
                            // the maximum value 
                            best = Math.Max(best, minimax(board,
                                            depth + 1, false,alpha,beta));
                            alpha = Math.Max(alpha, best);
                            // Undo the move 
                            board[i, j] = '_';

                            if (beta <= alpha)
                            {
                                break;
                            }
                        }
                    }
                }
                return best;
            }

            // If this minimizer's move 
            else
            {
                int best = 1000;

                // Traverse all cells 
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Check if cell is empty 
                        if (board[i, j] == '_')
                        {
                            // Make the move 
                            board[i, j] = opponent;

                            // Call minimax recursively and choose 
                            // the minimum value 
                            best = Math.Min(best, minimax(board,
                                            depth + 1, true, alpha,beta));
                            beta = Math.Min(beta, best);
                            
                            // Undo the move 
                            board[i, j] = '_';
                            if (beta <= alpha)
                            {
                                break;
                            }
                        }
                    }
                }
                return best;
            }
        }

        public static Node FindBestMove(Node[,] Nodeboard)
        {
            char[,] board = ConvertNodeToChar(Nodeboard);

            int bestVal = -1000;
            Node bestMove = new Node();
            bestMove.x = -1;
            bestMove.y = -1;

            // Traverse all cells, evaluate minimax function  
            // for all empty cells. And return the cell  
            // with optimal value. 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Check if cell is empty 
                    if (board[i, j] == '_')
                    {
                        // Make the move 
                        board[i, j] = player;

                        // compute evaluation function for this 
                        // move. 
                        int moveVal = minimax(board, 0, false,Int32.MinValue, Int32.MaxValue);

                        // Undo the move 
                        board[i, j] = '_';

                        // If the value of the current move is 
                        // more than the best value, then update 
                        // best/ 
                        results[i, j] = moveVal;
                        if (moveVal > bestVal)
                        {
                            bestMove.x = i;
                            bestMove.y = j;
                            bestVal = moveVal;
                        }
                    }
                }
            }
            Debug.Log($"l1 :{results[0,2]},{results[1, 2]},{results[2, 2]} \n" + 
                      $"l2: {results[0, 1]},{results[1, 1]},{results[2, 1]} \n" +
                      $"l3: {results[0, 0]},{results[1, 0]},{results[2, 0]}");

            Debug.Log($"The value of the best Move is : {bestVal} x: {bestMove.x} y: {bestMove.y} ");

            return bestMove;
        }

        private static char[,] ConvertNodeToChar(Node[,] node)
        {
           char[,] board = new char[3,3];
           for (int i = 0; i < 3; i++)
           {
               for (int j = 0; j < 3; j++)
               {
                   if (node[i, j] == null)
                   {
                       board[i, j] = '_';
                       continue;
                   }
                   if (node[i,j].player == 1)
                   {
                       board[i, j] = 'x';
                   }

                   if (node[i, j].player == 2)
                   {
                       board[i, j] = 'o';
                   }
                   
                   
               }
           }

           return board;

        }
    }
}