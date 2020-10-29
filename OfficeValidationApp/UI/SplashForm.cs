using System.Windows.Forms;

namespace OfficeValidationApp.UI
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            this.Activate();
        }

        public string Message
        {
            get => labelState.Text;
            set => labelState.Text = value;
        }
    }
}
