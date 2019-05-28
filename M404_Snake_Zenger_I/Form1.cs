using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Name: Ivan Zenger
/// Klasse: Inf2018.1b
/// Datum: 26.05.2019
/// </summary>

namespace M404_Snake_Zenger_I
{
    public partial class Form1 : Form
    {
        private int moveSnakeX; //Für den X Wert, der Schlange (addieren, suptrahieren, lassen wie er ist) 
        private int moveSnakeY; //Für den Y Wert, der Schlange (addieren, suptrahieren, lassen wie er ist) 
        private int canvasHeight; //Für die Spielfeld höhe
        private int canvasWidth; //Für die Spielfeld breite
        private int snakeAddValue; //Anzahl, um wie viel die Schlange verlängert werden soll
        private int scorePoints; //Erreichte Punkte
        private int counterValue = 20; //Wert des Countdowns
        private int countdownIntervalSuptract = 0; //Um wie viel der Interval der Schlange verkleinert werden soll (anzahl des Wertes des Apfels)
        private Direction snakeDirection = Direction.Right; //Richtung der Schlange (Stratrichtung: rechts)
        private string infoContent; //Was in der "Info-leiste" stehen soll
       
        
        List<PictureBox> snake = new List<PictureBox>(); //Schlange (Schlangenteile)
        List<Image> apples = new List<Image>(); //Apfel Bilder
        List<int> appleValue = new List<int>(); //Apfel wert
        List<PictureBox> picApple = new List<PictureBox>(); //Picture Boxen der Äpfel

        private String records; //Werte der Punkteliste
        private string path = Environment.CurrentDirectory + "\\" + "Records.txt"; //Pfad für das File, wo die Scores gespeichert werden



        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Height = 500; //Form Höhe
            this.Width = 820; //Form Breite
            SetStartValues(); //Start werte

        }

       /// <summary>
       /// Hier wird die Schlange verlängert
       /// Die Picturebox Elemente werden der Liste snake hinzugefüght und dem pnlSpiel
       /// </summary>
        private void AddSnakePart() {
            PictureBox part = new PictureBox();
            part.Size = picSnake.Size;
            part.Location = new Point(snake[snake.Count - 1].Location.X, snake[snake.Count - 1].Location.Y); //Übernihmt die Koordinaten des letzen Elementes in der List (snake)
            part.BackColor = Color.Blue;
            part.Tag = snake[snake.Count - 1].Tag;
            snake.Add(part); //hinzufüghen der Liste (snake)
            pnlSpiel.Controls.Add(part); //hinzufüghen des Spielfeldes


        }

        /// <summary>
        /// Diese Enum wird bei der definierung der richtung der Schlange benutzt
        /// </summary>
       private enum Direction{
            Left,Right,Up,Down
       }

    
        /// <summary>
        /// Dieses Enum, wird für die Unterscheidung der verschiedenen Texte in der Info-zeile verwendet
        /// </summary>
        private enum Info{
           start,GameOverBorder, GameOverSelf, GameOverCountdown, GameOverAllApples
        }

        private void lblCountdown_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Hier wird der KLick auf "PunkteEintragen" behandelt
        /// Die Punkte werden in ein File gespeichert und ausgelesen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPunkteEintragen_Click(object sender, EventArgs e)
        {
            path = Environment.CurrentDirectory + "\\" + "Records.txt"; //Pfad zum File
            File.AppendAllText(path, txtPunkte.Text + Environment.NewLine); //Erreichte Punktzahl wird hinzugefüght

            records = File.ReadAllText(path);//Der Inhalt des Files, wird in eine Variable gespeichert
            lblPunkteliste.Text = String.Format(records); //Der Inhalt der Variable "records" (beinhaltet die erreichten Punkte) der lblPunkteliste (Text) hinzugefüght

            btnPunkteEintragen.Enabled = false; //Button wird disabled

        }

        /// <summary>
        /// Diese Methode wird immer ausgeführt, nach dem Interfal des tmrSnake timers
        /// Hier wird die Bewegung der Schlange, Kollision Überprüfung, Äpfel behandelt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrSnake_Tick(object sender, EventArgs e)
        {
         
            
            //Es wird jedes einzelne Element in der Liste snake behandelt
            //Es wird von hinten begonnen
            for (int i = snake.Count - 1; i >= 0; i--) {
                //Wen der Kopf der Schlange dran kommt (0 == Kopf)
                if(i == 0){
                   
                    
                    canvasWidth = pnlSpiel.Size.Width; //Breite des Spielfeldes
                    canvasHeight = pnlSpiel.Size.Height; //Höhe des Spielfeldes
                    
                    //Setzten der X und Y Koordinaten (Für die Richtung)
                    picSnake.Location = new Point(picSnake.Location.X + moveSnakeX,
                        picSnake.Location.Y + moveSnakeY);
                    

                    //Hier werden die Schlangekopf-Bilder dem Kopfzugewiesen (Jeh nach richtung)
                    
                    if (snakeDirection == Direction.Up) 
                    {
                        picSnake.Tag = "Up";
                        
                        picSnake.Image = Properties.Resources.SchlangenKopfOben; //Schlangen-Bild aus den Resources
                    }else if (snakeDirection == Direction.Down)
                    {
                        picSnake.Tag = "Down";
                        picSnake.Image = Properties.Resources.SchlangenKopfUnten; //Schlangen-Bild aus den Resources
                    }
                    else if (snakeDirection == Direction.Left)
                    {
                        picSnake.Tag = "Left";
                        picSnake.Image = Properties.Resources.SchlangenKopfLinks; //Schlangen-Bild aus den Resources
                    }
                    else if (snakeDirection == Direction.Right)
                    {
                        picSnake.Tag = "Right";
                        picSnake.Image = Properties.Resources.SchlangenKopfRechts; //Schlangen-Bild aus den Resources
                    }

                    picSnake.SizeMode = PictureBoxSizeMode.StretchImage; //Damit das Bil auf die Grösse der Picturebox, gestreckt wird
                    picSnake.BackColor = Color.Transparent;
                    
                    
                    
                    //Hier wird geschaut ob die Schlange mit einem Apfel übereinander kommt (Ob Schlange einen Apfel isst)
                    //Jeder Element der Liste picApple, wird überprüft
                    for (int j = 0; j < picApple.Count; j++)
                    {
                        if (snake[i].Bounds.IntersectsWith(picApple[j].Bounds))
                        {
                            
                            snakeAddValue += appleValue[j]; //Der Wert, um wie viel die Schlang noch verlängert werdne soll, wir um den Wert des Apfels addiert
                            
                            pnlSpiel.Controls.Remove(picApple[j]); //Apfel, wir vom Spielfeld entfernt
                            scorePoints += appleValue[j]; //Punkte werden erhöht
                            countdownIntervalSuptract =  appleValue[j]; //tmrSnake wir verkleinert (Schlange wird kleiner) um den wert des Apfels
                            picApple.RemoveAt(j); //Apfel, wird von der Liste entfernt
                            appleValue.RemoveAt(j); //Der Wert des Apfel, wird aus der Liste entfernt
                            txtPunkte.Text = Convert.ToString(scorePoints); //Die bissher erreichten Punkte, werden dem Textfeld, txtPunkte (Text) zugewiesen
                            
                            //Hier wierd überprüft, ob es noch Äpfel auf dem Spielfeld hat
                            if (picApple.Count <= 0)
                            {
                                SetInfo(Info.GameOverAllApples); //Info wird Aktualisiert
                                EndGame(); //Spiel wird beendet
                            }


                        }

                        snake[i] = picSnake; //Schlangenkopf, wird der ersten Position un der^snake liste hinzugefüght
                    }
                    
                    //Pro Timer Tick, wird die Schlange üb ein Körperteil erweiternt (Wen snakeAddValue nicht 0 ist)
                    if (snakeAddValue > 0) {
                        AddSnakePart();
                        snakeAddValue -= 1;
                    }
                    
                    //Überprüft Kollision auf die Wände 
                    if (snake[i].Location.X <= 0 || snake[i].Location.X >= canvasWidth - snake[i].Width || snake[i].Location.Y <= 0 || snake[i].Location.Y >= (canvasHeight - snake[i].Height)) {
                        SetInfo(Info.GameOverBorder);
                        EndGame();
                        }

                    //Überprüft Kollision auf sich selber
                    for (int j = 1; j < snake.Count - 1; j++) {
                        if (snake[i].Location.X == snake[j].Location.X && snake[i].Location.Y == snake[j].Location.Y) {
                            SetInfo(Info.GameOverSelf);
                            EndGame();
                        }
                    }
                }
                else //Restlicher Schlangenkörper
                {


                    //Schlangenerlement, bekommt die Koordinaten, des Elementes, welches vohr im ist
                    snake[i].Location = new Point(snake[i - 1].Location.X, snake[i - 1].Location.Y);
                    if (i == snake.Count - 1)
                    {

                        try
                        {

                            if (snake[i - 1].Tag.Equals("Up"))
                            {
                                snake[i].Image = Properties.Resources.SchlangenEndeUnten;
                                snake[i].Tag = "Up"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }
                            else if (snake[i - 1].Tag.Equals("Down"))
                            {
                                snake[i].Image = Properties.Resources.SchlangenEndeOben;
                                snake[i].Tag = "Down"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }
                            else if (snake[i - 1].Tag.Equals("Left"))
                            {
                                snake[i].Image = Properties.Resources.SchlangenEndeRechts;
                                snake[i].Tag = "Left"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }
                            else if (snake[i - 1].Tag.Equals("Right"))
                            {
                                snake[i].Image = Properties.Resources.SchlangenEndeLinks;
                                snake[i].Tag = "Right"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }

                            snake[i].SizeMode = PictureBoxSizeMode.StretchImage; //Damit das Bild auf die Grösse der Picturebox, gestreckt wird
                            snake[i].BackColor = Color.Transparent;
                            snake[i].ForeColor = Color.Transparent;
                        }
                        catch (NullReferenceException)
                        {
                            //Es wurde bei der Schlange kein gesetzter Tag gefunden 
                            //Dem Schlangenteil, wir ein Bild zugewiesen
                            snake[i].BackColor = Color.Orange;
                        }
                    }
                    else
                    {


                        try
                        {

                            if (snake[i - 1].Tag.Equals("Up"))
                            {
                                if (snake[i].Tag.Equals("Right")) //Wen die Schlange von Rechts kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeLinks_Oben; //Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeVertikal;
                                  
                                }
                                else if(snake[i].Tag.Equals("Left"))//Wen die Schlange von Links kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeRechts_Oben;//Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeVertikal;
                                 
                                }
                                else
                                {
                                    snake[i].Image = Properties.Resources.SchlangeVertikal;
                                    
                                }
                                snake[i].Tag = "Up"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }
                            else if (snake[i - 1].Tag.Equals("Down"))
                            {
                                if (snake[i].Tag.Equals("Right"))//Wen die Schlange von Rechts kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeLinks_Unten;//Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeVertikal;
                                    
                                }
                                else if(snake[i].Tag.Equals("Left"))//Wen die Schlange von Links kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeRechts_Unten;//Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeVertikal;
                                   
                                }
                                else
                                {
                                    snake[i].Image = Properties.Resources.SchlangeVertikal;
                                    
                                }
                                snake[i].Tag = "Down"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }
                            else if (snake[i - 1].Tag.Equals("Left"))
                            {
                                if (snake[i].Tag.Equals("Down"))//Wen die Schlange von Unten kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeLinks_Oben;//Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeHorizontal;
                                    
                                }
                                else if(snake[i].Tag.Equals("Up"))//Wen die Schlange von Oben kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeLinks_Unten;
                                    snake[i].Image = Properties.Resources.SchlangeHorizontal;
                                  
                                }
                                else
                                {
                                    snake[i].Image = Properties.Resources.SchlangeHorizontal;
                                    
                                }
                                snake[i].Tag = "Left"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }
                            else if (snake[i - 1].Tag.Equals("Right"))
                            {
                                if (snake[i].Tag.Equals("Down"))//Wen die Schlange von Unten kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeRechts_Oben;//Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeHorizontal;
                                   
                                }
                                else if(snake[i].Tag.Equals("Up"))//Wen die Schlange von Oben kommt
                                {
                                    snake[i + 1].Image = Properties.Resources.SchlangeRechts_Unten;//Dem Element hinter dem momentanen (i) wird das Bild gesetzt (Schlangen Kurve)
                                    snake[i].Image = Properties.Resources.SchlangeHorizontal;
                                   
                                }
                                else
                                {
                                    snake[i].Image = Properties.Resources.SchlangeHorizontal;
                                    
                                }
                                snake[i].Tag = "Right"; //Der Tag, des Momentanen Schlangenelement wird mit der entsprechenden Richtung gesetzt
                            }

                            snake[i].SizeMode = PictureBoxSizeMode.StretchImage; //Damit das Bild auf die Grösse der Picturebox, gestreckt wird
                            snake[i].BackColor = Color.Transparent;
                            snake[i].ForeColor = Color.Transparent;
                        }
                        catch (NullReferenceException)
                        {
                            //Es wurde bei der Schlange kein gesetzter Tag gefunden 
                            //Dem Schlangenteil, wir ein Bild zugewiesen
                            snake[i].BackColor = Color.Blue;
                        }
                    }
                }
            }
           
        }


        /// <summary>
        /// Wen der Start-Button gedrückt wird
        /// Hier wird das Spiel gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Die Buttons werden Disabled
            btnReset.Enabled = false;
            btnStart.Enabled = false;
            btnPunkteEintragen.Enabled = false;

            //Spielfeld, wird resetet
            ResetGame(); 
            
            RandomizeApples(); //Äpfel werden gemischt 
            SetApples(); //Äpfel werdne auf das Spielfeld gesetzt

            //Zum start werden drei Körperteile hinzugefüght
            AddSnakePart();
            AddSnakePart();
            AddSnakePart();
             
            //Timer werdne gestartet
            tmrCountdown.Start();
            tmrSnake.Start();
           
        }

        /// <summary>
        /// Hier werden die Start werte gesetzt
        /// </summary>
        private void SetStartValues()
        {
            records = File.ReadAllText(path);
            lblPunkteliste.Text = String.Format(records);
            
            txtCountdown.Text = Convert.ToString(counterValue);
            txtPunkte.Text = Convert.ToString(0);
            
            tmrSnake.Interval = 150;
            SetInfo(Info.start);
            snakeAddValue = 0;
            
            moveSnakeX = picSnake.Width;
            moveSnakeY = 0;
            
            scorePoints = 0;
            counterValue = 20;
            
            snakeDirection = Direction.Right;
            picSnake.Location = new Point((pnlSpiel.Width / 2) - (picSnake.Width / 2), (pnlSpiel.Height / 2) - (picSnake.Height / 2));
            picSnake.Image = Properties.Resources.SchlangenKopfRechts;
            picSnake.SizeMode = PictureBoxSizeMode.StretchImage; //Damit das Bild auf die Grösse der Picturebox, gestreckt wird
            picSnake.BackColor = Color.Transparent;
            picSnake.Tag = "Right";
            snake.Add(picSnake);
        }

        /// <summary>
        /// Hier wird auf die die Eingabe des Spielers verwaltet (Knöpfe welche gedrpckt werden)
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (tmrSnake.Enabled) //Wen der tmrSnake Timer nicht gestoppt werden
            {

                if (Form.ModifierKeys == Keys.None && keyData == Keys.Left) //Pfeiltaste Links
                {
                    if (snakeDirection != Direction.Right && snakeDirection != Direction.Left) //Wen die Schlange nach Rechts fährt oder Wen die Schlange nicht bereits nach link steuert
                    {
                        MoveSnake(Direction.Left);
                        return true;
                    }
                   
                }
                else if (Form.ModifierKeys == Keys.None && keyData == Keys.Right) //Pfeiltaste Rechsts
                {
                    if (snakeDirection != Direction.Left && snakeDirection != Direction.Right) //Wen die Schlange nach Rechts fährt oder Wen die Schlange nicht bereits nach link steuert
                    {
                        MoveSnake(Direction.Right);
                    }

                    return true;
                }
                else if (Form.ModifierKeys == Keys.None && keyData == Keys.Up) //Pfreiltaste nach Oben
                {
                    if (snakeDirection != Direction.Down && snakeDirection != Direction.Up) //Wen die Schlange nach Rechts fährt oder Wen die Schlange nicht bereits nach link steuert
                    {
                        MoveSnake(Direction.Up);
                    }

                    return true;
                }
                else if (Form.ModifierKeys == Keys.None && keyData == Keys.Down) //Pfeiltaste nach unten
                {
                    if (snakeDirection != Direction.Up && snakeDirection != Direction.Down) //Wen die Schlange nach Rechts fährt oder Wen die Schlange nicht bereits nach link steuert
                    {
                        MoveSnake(Direction.Down);
                        return true;
                    }
                }
            }
            else {

            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Hird werden die Richtungsänderungen der Schlange behandelt
        /// </summary>
        /// <param name="moveDirection"></param>
        private void MoveSnake(Direction moveDirection)
        {
        
        
            //moveDirection: in welche Richtung, die Schlange steuern möchte
            switch (moveDirection)
            {
                case Direction.Left://Nach Links
                        moveSnakeX = -picSnake.Width; //addition der X Koordinate, wird Negativ
                        moveSnakeY = 0; //addition der Y Koordinate wird auf 0 gesetzt
                        snakeDirection = moveDirection; //Die Akutuelle Richtung der Schlange wird auf Left gesetzt
                        break;
                
                case Direction.Right://Nach Rechts
                        moveSnakeX = picSnake.Width; //addition der Y Koordinate, wird Positiv
                        moveSnakeY = 0;//addition der Y Koordinate wird auf 0 gesetzt
                        snakeDirection = moveDirection;//Die Akutuelle Richtung der Schlange wird auf Right gesetzt
                        break;

                case Direction.Up://Nach Rauf
                        moveSnakeX = 0;//addition der X Koordinate wird auf 0 gesetzt
                        moveSnakeY = -picSnake.Height; //addition der X Koordinate, wird Negativ
                        snakeDirection = moveDirection;//Die Akutuelle Richtung der Schlange wird auf Up gesetzt
                        break;

                case Direction.Down://Nach unten
                        moveSnakeX = 0;//addition der X Koordinate wird auf 0 gesetzt
                        moveSnakeY = picSnake.Height; //addition der Y Koordinate, wird Positiv
                        snakeDirection = moveDirection;//Die Akutuelle Richtung der Schlange wird auf Down gesetzt
                        break;

            }
         
        }

        /// <summary>
        /// Hier werden die Äpfel (Bilder) gemischt und in die Liste apples gespeichert 
        /// </summary>
        private void RandomizeApples() {
            Random rand = new Random();
            int appleNumber; //Wert des Apfels

            Image apple;

            for (int i = 0; i < 10; i++)
            {
                appleNumber = rand.Next(2, 11); //Zufallszahl zwischen 2 und 11
                apple = Image.FromFile(Environment.CurrentDirectory + "\\Picture\\"+"Apfel"+appleNumber+".png"); //Der Pfad wird mit der Zufallszahl zusammen gesetzt, wo sich der Apfel befindet => Die Äpfel werden nicht aus den Resourcen gewählt, da man dabei den Pfad nicht zusammensetzten kan
                appleValue.Add(appleNumber); //Wert de Apfels, wird in die Liste appleValue gespeichet
                apples.Add(apple); //Das Bild des Apfels, wird in die Liste apples gespeichert
            }
        }

        /// <summary>
        /// Hier werden die Äpfel auf dem Spielfel platziert
        /// </summary>
        private void SetApples() {
            Random rand = new Random();
            Boolean isNotBounds = true; //Zur überprüfung, ob die Äpfel sich nicht übereinander stapeln
            int pnlHeight = pnlSpiel.Height; //Höhe des Spielfeldes
            int pnlWidth = pnlSpiel.Width; //Breite des Spieldfeldes


            //Es werdne 10 Äpfel gesetzt
            for (int i = 0; i < 10; i++)
            {
                PictureBox picTempApple;
                do
                {
                    isNotBounds = true;
                    picTempApple = new PictureBox();
                    picTempApple.Image = apples[i]; //Das Bild von stelle i wird Temporär der picTempApple Picturpox hinzugefühgt (Die Liste apples wurde in der Methode RadomizeApples gefühlt)
                    picTempApple.SizeMode = PictureBoxSizeMode.StretchImage; //Damit das Bil auf die Grösse der Picturebox, gestreckt wird
                    picTempApple.Location = new Point(rand.Next(10, pnlWidth - 30), rand.Next(10, pnlHeight - 30)); //Apfel, wird inerhalb des Spielfeldes gesetzt

                    picTempApple.Height = 30; //Höhe des Apfels
                    picTempApple.Width = 30; //Breite des Apfels
                    
                    //Überprüfung, ob der Apfel mit anderen Äpfeln überienander kommt
                    for (int j = 0; j < picApple.Count; j++)
                    {
                        if (picTempApple.Bounds.IntersectsWith(picApple[j].Bounds))
                        {
                            isNotBounds = false;
                        }
                    }

                } while (isNotBounds != true); //Sollaneg es Äpfel hat, welche übereinander kommen

                
                picApple.Add(picTempApple); //Der Apfel, wir der Liste picApple hinzugefüght
                pnlSpiel.Controls.Add(picApple[i]); //Der Apfel wird dem Spielfeld hinzugefüght (pnlSpiel)
            }
        }

        /// <summary>
        /// Hier wird das Spiel beendet
        /// </summary>
        private void EndGame() {
            //Timer stoppen
            tmrSnake.Stop(); 
            tmrCountdown.Stop();
            
            //Buttons Enablen
            btnReset.Enabled = true;
            btnStart.Enabled = true;
            btnPunkteEintragen.Enabled = true;
        }

        //Hier werden die Ticks der tmrCountdown Timers behandel
        private void tmrCountdown_Tick(object sender, EventArgs e)
        {
            txtCountdown.Text = Convert.ToString(counterValue -= 1); //Countdown, wird (jede Sekunde) im 1 Suptrahiert
            if (tmrSnake.Interval > 10)//Wen der Interval des tmrSnake Timer als 10 ist, wird er verkleinert (um den Wert des gegessenen Apfels)
            {
                tmrSnake.Interval -= countdownIntervalSuptract; //wird er verkleinert (um den Wert des gegessenen Apfels)
            }
            //Wen der Countdown kleiner oder gleich 0 ist, soll das Spiel gestoppt werden
            if (counterValue <= 0) {
                SetInfo(Info.GameOverCountdown); //Info wird Aktualisert
                EndGame(); //Spiel wird beendet
            }

            countdownIntervalSuptract = 0; //verkleinerund des Intervals (des tmrSnake Timers) wird auf 0 gesetzt
        }

        //Wen das der Button btnReset gedrückt wurde
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetGame(); //Methode wird aufgerufen
        }
        
        /// <summary>
        /// Hier werde die Liste, und Spielfelder geleert
        /// </summary>
        private void ResetGame()
        {
            //Entfernen der Äppfel auf dem Spielfeld (pnlSpiel)
            for (int i = 0; i < picApple.Count; i++) {
                pnlSpiel.Controls.Remove(picApple[i]);
            }
            
            //Entfernent der Schlangenelemente auf dem Spielfeld
            for (int i = 1; i < snake.Count; i++)
            {
                pnlSpiel.Controls.Remove(snake[i]);
            }
            
            //Leeren der Listen
            picApple.Clear();
            snake.Clear();
            apples.Clear();
            appleValue.Clear();
            
            //Start werte setzten
            SetStartValues();
     


        }

        /// <summary>
        /// Hier werden der Werd ded lblInfo (Text) Label gehandelt
        /// </summary>
        /// <param name="infoKeyword"></param>
        private void SetInfo(Info infoKeyword)
        {
            switch (infoKeyword){
                case Info.start: //Wen das Spiel gestarten wurde oder Resetet wurde
                    infoContent = "Sammle innerhalb von 20 Sekunden, so viel Äpfel wie möglich";
                    break;
                case Info.GameOverBorder: //Wen die Schlange in die Wand gefahren ist
                    infoContent = "Das Spiel ist vorbei: Du bist in die Wand gefahren";
                    break;
                case Info.GameOverCountdown: //Wen der Countdown abgelaufen ist
                    infoContent = "Das Spiel ist vorbei: Der Countdown sit abgelofen";
                    break;
                case Info.GameOverSelf: //Wen die Schlange in sich selber gefahren ist
                    infoContent = "Das Spiel ist vorbei: Du bist in dich selbst gefahren";
                    break;
                case Info.GameOverAllApples: //Wen alle Äpfel gegesen wurde
                    infoContent = "Das Spiel ist vorbei: Du hast alle Äpfel gegessen";
                    break;
            }

            lblInfo.Text = infoContent; //lblInfo (Text) wird auf den entsprechenden Wert gesetzt
        }

    }


}
