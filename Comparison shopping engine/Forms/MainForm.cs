using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class MainForm : Form
    {

        #region WindowMove

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion


        private void ExitApplicationClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private List<KeyValuePair<MainGroups, Image>> photos;
        private int GroupPanelShowFirstIndex = 0;
        private int GroupCount = Enum.GetNames(typeof(MainGroups)).Length;

        public MainForm()
        {
            InitializeComponent();
            photos = new List<KeyValuePair<MainGroups, Image>>();
            for (var group = MainGroups.Apranga; group <= MainGroups.Vaikai; group++)
            {
                var k = System.AppDomain.CurrentDomain.BaseDirectory;
                var img = Image.FromFile($"../../Resources/Icons/{group}.png");
                photos.Add(new KeyValuePair<MainGroups, Image>(group, img));
            }
            mainGroupPanelPicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            mainGroupPanelPicture2.SizeMode = PictureBoxSizeMode.StretchImage;
            mainGroupPanelPicture3.SizeMode = PictureBoxSizeMode.StretchImage;

            mainGroupPanelPicture1.Click += GroupChosen;
            mainGroupPanelPicture2.Click += GroupChosen;
            mainGroupPanelPicture3.Click += GroupChosen;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangePictures(0);
        }

        private void MoveListToRight(object sender, EventArgs e)
        {
            GroupPanelShowFirstIndex = (GroupPanelShowFirstIndex + 1) % GroupCount;
            ChangePictures(GroupPanelShowFirstIndex);
        }
        private void MoveListToLeft(object sender, EventArgs e)
        {
            GroupPanelShowFirstIndex = (GroupCount + GroupPanelShowFirstIndex - 1) % GroupCount;
            ChangePictures(GroupPanelShowFirstIndex);
        }

        private void ChangePictures(int index)
        {
            mainGroupPanelPicture1.Image = photos[index].Value;
            mainGroupPanelPicture2.Image = photos[(index + 1) % GroupCount].Value;
            mainGroupPanelPicture3.Image = photos[(index + 2) % GroupCount].Value;
            mainGroupPanelPicture1.Tag = photos[index].Key;
            mainGroupPanelPicture2.Tag = photos[(index + 1) % GroupCount].Key;
            mainGroupPanelPicture3.Tag = photos[(index + 2) % GroupCount].Key;
            mainGroupPanelLabel1.Text = photos[index].Key.ToString();
            mainGroupPanelLabel2.Text = photos[(index + 1) % GroupCount].Key.ToString();
            mainGroupPanelLabel3.Text = photos[(index + 2) % GroupCount].Key.ToString();
        }

        private void GroupChosen(object sender, EventArgs e)
        {
            // Console.WriteLine();
            var group = (MainGroups)((PictureBox) sender).Tag;
            var form = new GroupedForm(group);
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Size = this.Size;
            form.Tag = this;
            form.Show();
            this.Hide();

        }

        private bool _placeHolderSet = true;
        private void SearchEnter(object sender, EventArgs e)
        {
            if (_placeHolderSet)
            {
                searchField.Text = "";
                _placeHolderSet = false;
                searchField.ForeColor = Color.Black;
            }
        }

        private void SearchLeave(object sender, EventArgs e)
        {
            if (searchField.Text == "")
            {
                _placeHolderSet = true;
                searchField.Text = "Įveskite ieškomą prekę";
                searchField.ForeColor = Color.Gray;
            }
        }
    }
}
