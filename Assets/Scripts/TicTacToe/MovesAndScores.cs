namespace Assets.Scripts.TicTacToe
{
    public class MovesAndScores
    {
        public int score;
        public Node point;

        public MovesAndScores(int score, Node point)
        {
            this.score = score;
            this.point = point;
        }
    }
}
