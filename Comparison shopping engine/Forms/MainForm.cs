using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Comparison_shopping_engine.Forms
{
    public partial class MainForm : Form
    {
        private readonly int _groupCount = Enum.GetNames(typeof(MainGroups)).Length;

        private readonly List<KeyValuePair<MainGroups, Image>> _photos;
        private int _groupPanelShowFirstIndex;

        private bool _placeHolderSet = true;

        public MainForm()
        {
            InitializeComponent();
            _photos = new List<KeyValuePair<MainGroups, Image>>();
            for (var group = MainGroups.Apranga; group <= MainGroups.Vaikai; group++)
            {
                var img = Image.FromFile($"../../Resources/Icons/{group}.png");
                _photos.Add(new KeyValuePair<MainGroups, Image>(group, img));
            }

            mainGroupPanelPicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            mainGroupPanelPicture2.SizeMode = PictureBoxSizeMode.StretchImage;
            mainGroupPanelPicture3.SizeMode = PictureBoxSizeMode.StretchImage;

            mainGroupPanelPicture1.Click += GroupChosen;
            mainGroupPanelPicture2.Click += GroupChosen;
            mainGroupPanelPicture3.Click += GroupChosen;
        }

        private void ExitApplicationClick(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangePictures(0);
        }

        private void MoveListToRight(object sender, EventArgs e)
        {
            _groupPanelShowFirstIndex = (_groupPanelShowFirstIndex + 1) % _groupCount;
            ChangePictures(_groupPanelShowFirstIndex);
        }

        private void MoveListToLeft(object sender, EventArgs e)
        {
            _groupPanelShowFirstIndex = (_groupCount + _groupPanelShowFirstIndex - 1) % _groupCount;
            ChangePictures(_groupPanelShowFirstIndex);
        }

        private void ChangePictures(int index)
        {
            mainGroupPanelPicture1.Image = _photos[index].Value;
            mainGroupPanelPicture2.Image = _photos[(index + 1) % _groupCount].Value;
            mainGroupPanelPicture3.Image = _photos[(index + 2) % _groupCount].Value;
            mainGroupPanelPicture1.Tag = _photos[index].Key;
            mainGroupPanelPicture2.Tag = _photos[(index + 1) % _groupCount].Key;
            mainGroupPanelPicture3.Tag = _photos[(index + 2) % _groupCount].Key;
            mainGroupPanelLabel1.Text = _photos[index].Key.ToString();
            mainGroupPanelLabel2.Text = _photos[(index + 1) % _groupCount].Key.ToString();
            mainGroupPanelLabel3.Text = _photos[(index + 2) % _groupCount].Key.ToString();
        }

        private void GroupChosen(object sender, EventArgs e)
        {
            var group = (MainGroups) ((PictureBox) sender).Tag;
            var form = new GroupedForm(group)
            {
                StartPosition = FormStartPosition.Manual, Location = Location, Tag = this
            };
            form.Show();
            Hide();
        }

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
                searchField.Text = @"Įveskite ieškomą prekę";
                searchField.ForeColor = Color.Gray;
            }
        }

        private void Faq(object sender, EventArgs e)
        {
            var form = new FaqForm {StartPosition = FormStartPosition.Manual, Location = Location};
            form.Left += 230;
            form.Top += -50;

            form.ShowDialog();
        }

        private void About(object sender, EventArgs e)
        {
            var form = new AboutForm {StartPosition = FormStartPosition.Manual, Location = Location};
            form.ShowDialog();
        }

        private void Search(object sender, EventArgs e)
        {
            if (Initializer.DoneWithDatabase)
                FetchSearched();
            var form = new SearchForm(_placeHolderSet ? "" : searchField.Text)
            {
                StartPosition = FormStartPosition.Manual, Location = Location, Tag = this
            };
            form.Show();
            Hide();
        }

        private async void FetchSearched()
        {
            var count = Enum.GetNames(typeof(ScrapedSites)).Length;
            for (var site = (ScrapedSites) 0; site < (ScrapedSites) count; site++)
            {
                var l = await Database.Get(searchQuery: searchField.Text.Trim().Replace(' ', '%'),
                    table: site.ToString());
                foreach (var ll in l)
                    if (!Product.productList.Any(product => product.Equals(ll)))
                        Product.productList.Add(ll);
            }
        }

        #region WindowMove

        public const int WmNclbuttondown = 0xA1;
        public const int HtCaption = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WmNclbuttondown, HtCaption, 0);
            }
        }

        #endregion
    }
}