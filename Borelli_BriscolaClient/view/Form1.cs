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


        private bool IsUsernameOk = false;
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
                labelDebug.Text = $"{DateTime.Now}: {command}\n";

                if (Regex.IsMatch(command, @"^preReg:(\w+,\w+,\w+;)+$")) {
                    labelDebug.Text=$"Entrato in preReg\n{command}";

                    ShowAllTablesInListView(command);
                }

                if (command == "reg:res=ok") {
                    IsUsernameOk = true;
                } else if (command == "reg:res=error") {
                    MessageBox.Show("Esiste già un utente con questo username nella stanza");
                }
                if (IsUsernameOk) {
                    if (command == "reg:state=start") {
                        //TODO
                    } else if (Regex.IsMatch(command, @"^reg:update=(\w+;)+$")) {
                        ShowInfoTableInListView(command);
                    }
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

            //reg:table=<id>
            Utilities.Instance.WriteLineStream($"reg:table={lvTables.SelectedItems[0].SubItems[0].Text}");
            Utilities.Instance.WriteLineStream($"reg:username={PlayerName}");
        }

        private void ResetListView() {
            lvTables.Columns.Clear();
            lvTables.Items.Clear();
            lvTables.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Utilities.Instance.WriteLineStream("chiudi");
        }
    }
}
