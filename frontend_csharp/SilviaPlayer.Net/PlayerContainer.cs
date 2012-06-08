using System;
using System.Text;
using System.Windows.Forms;
using AxsopocxLib;

namespace SilviaPlayer
{
    public partial class PlayerContainer : UserControl
    {
        private Axsopocx soapPlayer;

        public PlayerContainer()
        {
            InitializeComponent();
        }

        public void CreatePlayer()
        {
            if (soapPlayer != null) return;

            soapPlayer = new Axsopocx();
            soapPlayer.Dock = DockStyle.Fill;
            Controls.Add(soapPlayer);

        }

        public void Play(string url)
        {
            if (soapPlayer == null) return;

            soapPlayer.SopAddress = url;
            soapPlayer.Play();
            //HackSopPlayer(soapPlayer.Handle.ToInt32());
        }


        void HackSopPlayer(int sopHandle)
        {
            hwndSopPlayer = 0;
            Console.WriteLine("###***>>>>>>");
            Win32.EnumChildWindows(sopHandle, new Win32.Callback(EnumChildGetValue), 0);

            if (hwndSopPlayer != 0)
            {
                //Win32.SetParent(hwndSopPlayer, uxRender.Handle.ToInt32());
                Console.WriteLine("###*** hack completed: {0:X}", hwndSopPlayer);
            }
        }

        private int hwndSopPlayer;
        int EnumChildGetValue(int hWnd, int lParam)
        {
            var t1 = new StringBuilder(256); 
            Win32.GetWindowText(hWnd, t1, 256);
            var text = t1.ToString().Trim();

            var t2 = new StringBuilder(256); 
            Win32.GetClassName(hWnd, t2, 256);
            var cls = t2.ToString().Trim();

            Win32.RECT rect; Win32.GetWindowRect(hWnd, out rect);

            Console.WriteLine("###Window: {0:X} '{1}' {2} : {3}",
                              hWnd, text, cls, rect);

            if (string.IsNullOrEmpty(text) && cls == "#32770")
                hwndSopPlayer = hWnd;
            return 1;
        }

        private void uxRender_Resize(object sender, EventArgs e)
        {
            if (hwndSopPlayer == 0) return;
            //Win32.MoveWindow(hwndSopPlayer, 0, 0, uxRender.Width, uxRender.Height, true);
        }
    }
}
