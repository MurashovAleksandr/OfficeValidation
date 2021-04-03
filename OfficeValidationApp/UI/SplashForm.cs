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

        /// <summary>
        /// Status message
        /// </summary>
        public string Message { get { return labelMessage.Text; } set { labelMessage.Invoke((MethodInvoker)(() => { labelMessage.Text = value; })); } }

        /// <summary>
        /// Minimum progress bar value
        /// </summary>
        public int Minimum { get { return progressBar.Minimum; } set { progressBar.Invoke((MethodInvoker)(() => { progressBar.Minimum = value; })); } }

        /// <summary>
        /// Maximum progress bar value
        /// </summary>
        public int Maximum { get { return progressBar.Maximum; } set { progressBar.Invoke((MethodInvoker)(() => { progressBar.Maximum = value; })); } }

        /// <summary>
        /// Progress bar current value
        /// </summary>
        public int Value { get { return progressBar.Value; } set { progressBar.Invoke((MethodInvoker)(() => { progressBar.Value = value; })); } }
    }
}
