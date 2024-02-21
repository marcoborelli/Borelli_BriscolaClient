using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Borelli_BriscolaClient.controller {
    delegate void DoAction(string input);
    internal class Utilities {
        DoAction OnReadString { get; set; }
        public static Utilities Instance { get; private set; }
        private TcpClient Client { get; set; }

        public static void Init(DoAction func, TcpClient socket) {
            if (Instance != null) {
                return;
            }

            Instance = new Utilities(func, socket);
            Task.Run(Instance.ReadLineStream);
        }

        public static void ChangeDelegatedFunction(DoAction func) {
            if (Instance == null) {
                return;
            }

            Instance.OnReadString = func;
        }

        public void WriteLineStream(string toWrite) {
            byte[] bytes = Encoding.ASCII.GetBytes($"{toWrite}\n");

            Client.GetStream().Write(bytes, 0, bytes.Length);
        }

        private void ReadLineStream() {
            while (true) {
                byte[] bytes = new byte[Client.ReceiveBufferSize];
                int numBytes = Client.GetStream().Read(bytes, 0, Client.ReceiveBufferSize);

                //a volte piu' messaggi potrebbero essere concatenati in uno stesso. Per dividerli uso il '\n'
                string res = Encoding.ASCII.GetString(bytes, 0, numBytes).Trim();
                string[] subRes = res.Split('\n');

                for (ushort i = 0; i < subRes.Length; i++) {
                    OnReadString(subRes[i].Trim());
                }
            }
        }


        private Utilities(DoAction func, TcpClient socket) {
            OnReadString = func;
            Client = socket;
        }
    }
}
