using TestGame.Client;
using Client.Objects;
using Object = Client.Objects.Object;

namespace TestGame
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            new TestGame.Client.Client("localhost", 9999).Start();

            DoubleBuffered = true;
            SetDoubleBuffered(panel1);

            new Thread(() =>
            {
                Render();
            }).Start();

        }


        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion

        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        private void Render()
        {

            while (true)
            {
                var buffer = new Bitmap(panel1.Width, panel1.Height);
                using (Graphics g = Graphics.FromImage(buffer))
                {

                    Object.Objects.OfType<Enemy>().ToList().ForEach(e =>
                    {
                        g.FillEllipse(
                            new SolidBrush(Color.Red),
                            new Rectangle(new Point(e.Location.X, e.Location.Y), new Size(10, 10))
                        );
                    });

                    var oldImage = panel1.BackgroundImage;
                    if (panel1.InvokeRequired)
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            panel1.BackgroundImage = buffer;
                        });
                    }
                    else
                    {
                        panel1.BackgroundImage = buffer;
                    }
                    if (oldImage != null)
                    {
                        oldImage.Dispose();
                    }
                }
            }
        }
    }
}