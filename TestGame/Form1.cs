using TestGame.Client;

namespace TestGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            new TestGame.Client.Client("localhost", 9999).Start();
        }
    }
}