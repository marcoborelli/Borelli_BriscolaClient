using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Borelli_BriscolaClient.controller;
using System.Text.RegularExpressions;

namespace Borelli_BriscolaClient.view {
    public partial class Form1 : Form {
        private TcpClient Client { get; set; }


        //TODO: salvare in un file di testo a parte
        private string Ip { get; set; } = "192.168.1.114";
        private short Port { get; set; } = 5000;

        private string PlayerName { get; set; }

        public Form1() {
            InitializeComponent();
            labelInfo.Text = $"Connesso al socket {Ip}:{Port}";
            Client = new TcpClient(Ip, Port);
        }

        private void Form1_Load(object sender, EventArgs e) {
            Utilities.Init(GetNewCommand, Client);
        }

        private void GetNewCommand(string command) {
            this.Invoke(new MethodInvoker(delegate {
                labelDebug.Text = $"'{command}'";

                if (Regex.IsMatch(command, @"^preReg:(\w+,\w+,\w+;)+$")) {

                    ShowAllTablesInListView(command);
                }

                if (command == "reg:addUserRes=error") {
                    MessageBox.Show("Esiste già un utente con questo username nella stanza");
                } else if (command == "reg:state=start") {
                    Game fGame = new Game(PlayerName);
                    fGame.Show();
                } else if (Regex.IsMatch(command, @"^reg:update=(\w+;)+$")) {
                    ShowInfoTableInListView(command);
                }
            }));
            return;


        }


        private void ShowAllTablesInListView(string str) {
            ResetListView();
            lvTables.Columns.Add("Id");
            lvTables.Columns.Add("Partecipanti");

            //preReg:<id,MaxPart,Part>;...
            string data = str.Split(':')[1];

            string[] tables = data.Split(';');

            for (short i = 0; i < tables.Length; i++) {
                string[] fields = tables[i].Split(',');

                if (fields.Length < 3 || fields[1] == fields[2]) { //se una stanza e' piena non la si visualizza
                    continue;
                }

                lvTables.Items.Add(new ListViewItem(new string[] { fields[0], $"{fields[2]}/{fields[1]}" }));
                //id stanza; numPartecipanti/partecipantiTotali
            }

            lvTables.Refresh();
        }

        private void ShowInfoTableInListView(string str) {
            ResetListView();
            lvTables.Columns.Add("Username");

            //reg:update=<username>;...
            string data = str.Split('=')[1];

            string[] players = data.Split(';');

            for (byte i = 0; i < players.Length; i++) {
                lvTables.Items.Add(new ListViewItem(players[i]));
            }

            lvTables.Refresh();
        }

        private void lvTables_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (lvTables.SelectedItems.Count < 1) {
                return;
            }

            if (String.IsNullOrEmpty(tbName.Text)) {
                MessageBox.Show("Inserire uno username");
                return;
            }

            PlayerName = tbName.Text.Trim();
            JoinRoom(PlayerName, lvTables.SelectedItems[0].SubItems[0].Text);
        }

        private void ResetListView() {
            lvTables.Columns.Clear();
            lvTables.Items.Clear();
            lvTables.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Utilities.Instance.WriteLineStream("chiudi");
        }

        private void JoinRoom(string username, string roomId) {
            //reg:table=<id>
            Utilities.Instance.WriteLineStream($"reg:table={roomId}");
            Utilities.Instance.WriteLineStream($"reg:username={username}");
        }
    }
}
