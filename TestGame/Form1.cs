using TestGame.Client;
using Client.Objects;
using Object = Client.Objects.Object;

namespace TestGame
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        public Form1()
        {
            InitializeComponent();
            new TestGame.Client.Client("localhost", 9999).Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var g = panel1.CreateGraphics();

            g.Clear(Color.White);

            Object.Objects.OfType<Player>().ToList().ForEach(x =>
            {
                g.DrawEllipse(
                    new Pen(new SolidBrush(Color.Green)),
                    new Rectangle(new Point(x.Location.X, x.Location.Y), new Size(10,10))
                );
            });

            Object.Objects.OfType<Enemy>().ToList().ForEach(x =>
            {
                g.DrawEllipse(
                    new Pen(new SolidBrush(Color.Red)),
                    new Rectangle(new Point(x.Location.X, x.Location.Y), new Size(10, 10))
                );
            });


        }
    }
}