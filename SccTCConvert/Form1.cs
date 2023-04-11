namespace SccTCConvert
{
    public partial class Form1 : Form
    {

        static string[] filelines = Array.Empty<string>();
        string[] outputFileLines;
        static int tcBase = 10;


        public Form1()
        {
            InitializeComponent();
            this.Text = "29.94 to 23.976 SCC convert";
            CB_baseTC.SelectedIndex = 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OpenSCC_BTN_Click(object sender, EventArgs e)
        {
            string filename = "";

            // Sert a ouvrir un fichier SCC puis a lire toutes les lignes. Chaque ligne sera contenue dans une case du array de string "filelines".

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse SCC File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "scc",
                Filter = "scc files (*.scc)|*.scc",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                filelines = File.ReadAllLines(filename);
            }
        }

        private void SaveSCC_BTN_Click(object sender, EventArgs e)
        {

            string filename = "";

            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse SCC File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "scc",
                Filter = "scc files (*.scc)|*.scc",
                FilterIndex = 2,
                RestoreDirectory = true,

            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                File.WriteAllLines(filename, outputFileLines);
            }
        }

        private void btn_23to29_Click(object sender, EventArgs e)
        {
            string filename;

            if (filelines.Length > 0)
            {
                // Cette partie extrait un timecode, appelle la fonction pour convertir le timecode, puis le rentre dans le array d'output.
                outputFileLines = new string[filelines.Length];
                int heures;
                int minutes;
                int secondes;
                int frames;
                string nouveauTC;

                outputFileLines[0] = filelines[0];
                outputFileLines[1] = filelines[1];

                for (int i = 2; i < filelines.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        heures = Int32.Parse(filelines[i].Substring(0, 2));
                        minutes = Int32.Parse(filelines[i].Substring(3, 2));
                        secondes = Int32.Parse(filelines[i].Substring(6, 2));
                        frames = Int32.Parse(filelines[i].Substring(9, 2));

                        nouveauTC = convertirTC(heures, minutes, secondes, frames);
                        outputFileLines[i] = nouveauTC + filelines[i].Substring(11);

                    }
                    else
                    {
                        outputFileLines[i] = filelines[i];
                    }


                }

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Browse SCC File",

                    CheckFileExists = false,
                    CheckPathExists = false,

                    DefaultExt = "scc",
                    Filter = "scc files (*.scc)|*.scc",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    File.WriteAllLines(filename, outputFileLines);
                }
            }
            else
            {
                MessageBox.Show("You must open a SCC file before converting.");
            }

        }

        public string convertirTC(int heures, int minutes, int secondes, int frames)
        {
            string nvTC = "";
            int totalFramesAvant = ((heures - tcBase) * 60 * 60 * 30) + (minutes * 60 * 30) + (secondes * 30) + frames;

            int framesASoustraire = (((((heures - tcBase) * 60) + minutes) * 2) - ((((heures - tcBase) * 6) + (minutes / 10)) * 2));
            int totalFramesApres = totalFramesAvant - framesASoustraire;

            int nvHeures = ((totalFramesApres / 60) / 60) / 30;
            int nvMinutes = ((totalFramesApres - (nvHeures * 60 * 60 * 30)) / 60) / 30;
            int nvSecondes = (totalFramesApres - (nvHeures * 60 * 60 * 30) - (nvMinutes * 60 * 30)) / 30;
            int nvFrames = (totalFramesApres - (nvHeures * 60 * 60 * 30) - (nvMinutes * 60 * 30) - (nvSecondes * 30));

            nvFrames = (int)Math.Round(((decimal)nvFrames / 5) * 4);
            nvHeures = nvHeures + tcBase;

            nvTC = nvHeures.ToString("00") + ":" + nvMinutes.ToString("00") + ":" + nvSecondes.ToString("00") + ":" + nvFrames.ToString("00");

            return nvTC;
        }

        private void CB_baseTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcBase = CB_baseTC.SelectedIndex;
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            if (filelines.Length>0)
            {

            }
            else
            {
                MessageBox.Show("Vous devez d'abord ouvrir un fichier.");
            }
            //MessageBox.Show(filelines[0] + Environment.NewLine + filelines[2]);
            ///filelines[0].Substring(0,
        }*/


    }
}