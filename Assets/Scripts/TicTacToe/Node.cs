using System.Runtime.InteropServices.WindowsRuntime;

namespace Assets.Scripts.TicTacToe
{
    public class Node
    {
        public int x;
        public int y;
        public int player;

        public AsChar ToChar()
        {
            return new AsChar(){x = (char)this.x, y = (char)this.y};
        }
    }

    public struct AsChar
    {
        public char x;
        public char y;
    }

}
