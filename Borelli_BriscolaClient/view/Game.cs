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
        List<Button> OtherPlayers = new List<Button>();

        private string PlayerName { get; set; }
        public bool PlayAgain { get; private set; }
        public Game(string playerName) {
            InitializeComponent();
            Hand.AddRange(new Button[] { bCard1, bCard2, bCard3 });

            Hand.ForEach(x => x.MouseClick += BCard_MouseClick);

            //rivedere
            OtherPlayers.AddRange(new Button[] { bCardPlayedP2, bCardPlayedP1, bCardPlayedP3, bCardPlayedP4 });
            bCardPlayedP1.Name = PlayerName;

            PlayerName = playerName;
            Text = playerName;

            Utilities.ChangeDelegatedFunction(GetNewCommand);

            bCardBack.BackgroundImage = Image.FromFile($"../../../images/back.jpg");
        }

        private void BCard_MouseClick(object sender, MouseEventArgs e) {
            Button btn = (Button)sender;
            Utilities.Instance.WriteLineStream($"play:cardToPlay={btn.Name}");

            btn.Visible = false;

            Hand.ForEach(x => x.Enabled = false); //si impedisce di giocare altre carte

            bCardPlayedP1.BackgroundImage = btn.BackgroundImage;
            bCardPlayedP1.Visible = true;
        }

        private void GetNewCommand(string command) {
            this.Invoke(new MethodInvoker(delegate {
                lDebug.Text = $"'{command}'";
                if (Regex.IsMatch(command, @"^play:players=(\w+;)+$")) {
                    List<string> players = command.Remove(command.Length - 1, 1).Split('=')[1].Split(';').ToList(); //rimuovo il ';' in fondo
                    InitOtherPlayers(players);
                } else if (Regex.IsMatch(command, @"^play:briscola=\w+_\w+$")) {
                    string briscola = command.Split('=')[1];

                    lRemCard.Visible = bCardBack.Visible = bCardBriscola.Visible = lBriscola.Visible = true;
                    lBriscola.Text = briscola;
                    bCardBriscola.BackgroundImage = GetRotatedImage($"../../../images/{briscola}.jpg");
                } else if (Regex.IsMatch(command, @"^play:cardDrawed=\w+_\w+$")) {
                    GiveToFreeHandButtonCard(command.Split('=')[1]);
                } else if (Regex.IsMatch(command, @"^play:turn=\w+$")) {
                    Hand.ForEach(x => x.Enabled = (command.Split('=')[1] == PlayerName));
                } else if (Regex.IsMatch(command, @"^play:cardPlayed=(\w+_\w+);player=(\w+)$")) {
                    string playerName = command.Split(';')[1].Split('=')[1];
                    string nameCard = command.Split('=')[1].Split(';')[0];

                    GiveToPlayerButtonCard(playerName, nameCard);
                } else if (Regex.IsMatch(command, @"^play:handWinner=\w+$")) {
                    bCardPlayedP1.Visible = false; //resetto il tavolo con le carte giocate
                    OtherPlayers.ForEach(x => x.Visible = false);
                } else if (Regex.IsMatch(command, @"^play:cardRemaingNum=([0-9]+)$")) {
                    int remCard = int.Parse(command.Split('=')[1]);

                    if (remCard > 0) {
                        lRemCard.Text = $"{remCard}";
                    } else {
                        lRemCard.Visible = bCardBack.Visible = bCardBriscola.Visible = lBriscola.Visible = false;
                    }
                } else if (Regex.IsMatch(command, @"^play:points=([0-9]+)$")) {
                    byte punti = byte.Parse(command.Split('=')[1]);
                    lPoints.Text = $"PUNTI: {punti}";
                }

                if (Regex.IsMatch(command, @"^end:winner=(\w+;)+$")) {
                    List<string> winners = command.Split('=')[1].Split(';').ToList();

                    MessageBox.Show(winners.Contains(PlayerName) ? "Hai vinto" : "Hai perso");

                    DialogResult result = MessageBox.Show("Desideri giocare ancora?", "CONFERMA", MessageBoxButtons.YesNo);
                    PlayAgain = (result == DialogResult.Yes);
                    Utilities.Instance.WriteLineStream($"end:playAgain={PlayAgain}");
                } else if (command == "end:closeForm") {
                    this.Close();
                }
            }));
            return;
        }

        public void WriteVerticalLable(Label l, string text) {
            l.Text = "";
            for (short i = 0; i < text.Length; i++) {
                l.Text += $"{text[i]}\n";
            }
        }

        private void InitOtherPlayers(List<string> players) {
            /*
                  Player2
             Player3    Player4
                  Player1
            */
            byte ownPosition = (byte)players.IndexOf(PlayerName);

            if (players.Count == 4) {
                lPlayer3.Visible = lPlayer4.Visible = lPlayer2.Visible = true;

                WriteVerticalLable(lPlayer3, players[GetIndexIntoRange((ownPosition - 1), players.Count)]);
                bCardPlayedP3.Name = players[GetIndexIntoRange((ownPosition - 1), players.Count)];

                WriteVerticalLable(lPlayer4, players[GetIndexIntoRange((ownPosition + 1), players.Count)]);
                bCardPlayedP4.Name = players[GetIndexIntoRange((ownPosition + 1), players.Count)];

                lPlayer2.Text = players[GetIndexIntoRange((ownPosition + 2), players.Count)];
                bCardPlayedP2.Name = players[GetIndexIntoRange((ownPosition + 2), players.Count)];
            } else if (players.Count == 2) {
                OtherPlayers.Remove(bCardPlayedP3);
                OtherPlayers.Remove(bCardPlayedP4);

                lPlayer2.Visible = true;
                lPlayer2.Text = players[GetIndexIntoRange((ownPosition + 1), players.Count)];
                bCardPlayedP2.Name = players[GetIndexIntoRange((ownPosition + 1), players.Count)];
            }
        }

        private int GetIndexIntoRange(int ownIndex, int membersCount) { //ottiene la posizione degli altri giocatori rispetto al giocatore che sta giocando su quel client
            if (ownIndex < 0) { //se e' negativo riparto dal massimo e sottraggo quelli di cui andavo sotto
                ownIndex = membersCount + ownIndex;
            }

            return ownIndex < membersCount ? ownIndex : (ownIndex - membersCount);
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

        private void GiveToPlayerButtonCard(string playerName, string card) {
            Button tmp = OtherPlayers.First(x => x.Name == playerName);
            tmp.BackgroundImage = tmp.Size.Height > tmp.Size.Width ? Image.FromFile($"../../../images/{card}.jpg") : GetRotatedImage($"../../../images/{card}.jpg"); //se e' verticale non la ruoto
            tmp.Visible = true;
        }

        private Image GetRotatedImage(string path) {
            Image imm = Image.FromFile(path);
            imm.RotateFlip(RotateFlipType.Rotate90FlipNone);

            return imm;
        }
    }
}
