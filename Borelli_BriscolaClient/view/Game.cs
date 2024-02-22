using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Borelli_BriscolaClient.controller;

namespace Borelli_BriscolaClient.view {
    public partial class Game : Form {
        List<Button> Hand = new List<Button>();
        private string PlayerName { get; set; }
        public Game(string playerName) {
            InitializeComponent();
            Hand.AddRange(new Button[] { bCard1, bCard2, bCard3 });

            Hand.ForEach(x => x.MouseClick += BCard_MouseClick);

            PlayerName = playerName;

            Utilities.ChangeDelegatedFunction(GetNewCommand);
        }

        private void BCard_MouseClick(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            Utilities.Instance.WriteLineStream($"play:cardToPlay={btn.Name}");

            btn.Visible = false;
        }

        private void GetNewCommand(string command) {
            this.Invoke(new MethodInvoker(delegate {
                lDebug.Text = $"{DateTime.Now}: '{command}'";
                if (Regex.IsMatch(command, @"^play:briscola=\w+_\w+$")) {
                    lBriscola.Text = command.Split('=')[1];
                } else if (Regex.IsMatch(command, @"^play:cardDrawed=\w+_\w+$")) {
                    GiveToFreeHandButtonCard(command.Split('=')[1]);
                } else if (Regex.IsMatch(command, @"^play:turn=\w+$")) {
                    Hand.ForEach(x => x.Enabled = (command.Split('=')[1] == PlayerName));
                } else if (Regex.IsMatch(command, @"^play:cardPlayed=(\w+_\w+);player=\w+$")) {
                    //other things
                    //Hand.ForEach(x => x.Enabled = true);
                }

                if (Regex.IsMatch(command, @"^end:winner=(\w+;)+$")) {
                    List<string> winners = command.Split('=')[1].Split(';').ToList();

                    MessageBox.Show(winners.Contains(PlayerName) ? "Hai vinto" : "Hai perso");
                }
            }));
            return;
        }

        private void GiveToFreeHandButtonCard(string nameCard) {
            Button free = Hand.First(x => !x.Visible);

            if (free == null) {
                throw new Exception("C'è qualche problemuccio");
            }

            free.BackgroundImage = Image.FromFile($"../../../images/{nameCard}.jpg");
            free.Name = nameCard;
            free.Visible = true;
        }
    }
}
