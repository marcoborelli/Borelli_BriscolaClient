using System;
using System.Net.Sockets;
using System.Windows.Forms;
using Borelli_BriscolaClient.controller;
using System.Text.RegularExpressions;
using System.IO;

namespace Borelli_BriscolaClient.view {
    public partial class Form1 : Form {
        private TcpClient Client { get; set; }


        private string Ip { get; set; }
        private short Port { get; set; }
        private bool IsInRoom { get; set; }

        private string PlayerName { get; set; }
        Game fGame;

        public Form1() {
            InitializeComponent();

            InitIpAndPort();

            labelInfo.Text = $"{Ip}:{Port}";

            try {
                Client = new TcpClient(Ip, Port);
            } catch {
                MessageBox.Show($"Non è stato possibile connettersi all'host '{Ip}' sulla porta '{Port}'");
                Environment.Exit(1);
            }

            cbRoomNum.SelectedIndex = 0;
            IsInRoom = false;
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
                    fGame = new Game(PlayerName);

                    fGame.FormClosed += ResetValue;

                    this.Visible = false;
                    fGame.Show();
                } else if (Regex.IsMatch(command, @"^reg:update=(\w+;)+$")) {
                    IsInRoom = true;
                    ChangeFormState();

                    ShowInfoTableInListView(command);
                } else if (command == "reg:addTableRes=error") {
                    MessageBox.Show("Errore nella creazione del tavolo: controllare che il numero di partecipanti sia valido e che il nome della stanza sia unico");
                } else if (command == "reg:addTableRes=ok") {
                    PlayerName = tbName.Text.Trim();
                    JoinRoom(PlayerName, tbRoomName.Text); //se un utente crea una stanza viene automaticamente aggiunto

                    tbRoomName.Text = String.Empty; //reset dei dati
                    cbRoomNum.SelectedIndex = 0;
                } else if (command == "reg:error") {
                    MessageBox.Show("C'è stato un errore durante la creazione del tavolo");

                    IsInRoom = false;
                    ChangeFormState();
                    bUpdateList_Click(null, null);
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

        private void bCreateRoom_Click(object sender, EventArgs e) {
            if (IsInRoom)
                return;

            if (String.IsNullOrWhiteSpace(tbRoomName.Text) || String.IsNullOrWhiteSpace(cbRoomNum.Text)) {
                MessageBox.Show("Inserire prima dei valori validi per creare una stanza");
                return;
            }

            if (String.IsNullOrEmpty(tbName.Text)) {
                MessageBox.Show("Inserire prima uno username");
                return;
            }

            Utilities.Instance.WriteLineStream($"reg:createTable={tbRoomName.Text};numPart={cbRoomNum.Text}");
        }

        private void lvTables_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (IsInRoom)
                return;


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

        private void bJoinRoom_Click(object sender, EventArgs e) {
            lvTables_MouseDoubleClick(null, null);
        }

        private void bUpdateList_Click(object sender, EventArgs e) {
            Utilities.Instance.WriteLineStream("preReg:update");
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

        private void ResetValue(object sender, FormClosedEventArgs e) {
            this.Visible = true;
            Utilities.ChangeDelegatedFunction(GetNewCommand);

            if (!fGame.PlayAgain) {
                IsInRoom = false;
                ChangeFormState();
                bUpdateList_Click(null, null);
            }
        }

        private void ChangeFormState() {
            panel2.Enabled = tbName.Enabled = bJoinRoom.Enabled = bUpdateList.Visible =!IsInRoom;
        }

        private void InitIpAndPort() {
            if (!File.Exists("conf")) {
                using (StreamWriter write = new StreamWriter("conf")) {
                    write.WriteLine("127.0.0.1;5000");
                }
            }

            using (StreamReader read = new StreamReader("conf")) {
                string[] fields = read.ReadLine().Split(';');

                Ip = fields[0];
                Port = short.Parse(fields[1]);
            }
        }
    }
}
