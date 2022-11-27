using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CTeiler
{
    /// <summary>
    /// Die Klasse CTeiler
    /// Diese Erbt von der Klasse Form
    /// </summary>
    public partial class CTeiler : Form
    {
        //  Der Mini- und Maximale einzugebene Wert als Konstanten
        public const int nMaxWert = 1000;
        public const int nMinWert = 1;

        /// <summary>
        /// Der Konstruktor
        /// </summary>
        public CTeiler()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Schliesst die Applikation
        /// Der User muss allerdings noch bestätigen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSchliessen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Wollen Sie die Applikation wirklich schliessen?", "Schliessen", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Applikation wird geschlossen");
                System.Windows.Forms.Application.Exit();
            }
        }

        /// <summary>
        /// Führt die Berechnung aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBerechne_Click(object sender, EventArgs e)
        {
            // Aufrufen der Methode ValidInput
            (bool bValid, int nEingabe) = ValidInput(nMinWert, nMaxWert, txtEingabe);
            if (!bValid)
                return;

            //  Teiler bestimmen lassen
            string strTeilresultat = BestimmeTeiler(nEingabe, nMinWert, nMaxWert);

            //  Resultat zurückgeben
            SetzeResultat(strTeilresultat, lblResultat);
        }

        /// <summary>
        /// Prüft die Eingabe auf folgendes
        /// 1.  NOT NULL
        /// 2.  Nicht Alphanummerisch
        /// 3.  Ganzzahl
        /// </summary>
        /// <param name="nMinimumWert"></param>
        /// <param name="nMaximumWert"></param>
        /// <param name="oField"></param>
        /// <returns></returns>
        private (bool, int) ValidInput(int nMinimumWert, int nMaximumWert, TextBox oField)
        {
            //  Textfeld auslesen
            string strEingabe = txtEingabe.Text.Trim();

            //  Variablen deklarieren / definieren
            int nEingabe = 0;
            double dEingabe = 0.0;
            string strWarningErroMessage = "";
            bool bEingabe_Is_NULL = string.IsNullOrEmpty(strEingabe);               //  Prüfen ob der Wert NULL ist
            bool bEingabe_Is_Parsable = int.TryParse(strEingabe, out nEingabe);     //  Prüfen ob in Integer geparsed werden kann
            bool bEingabe_Is_Double = double.TryParse(strEingabe, out dEingabe);    //  Wird nur für dEingabe gebraucht
            bool bValid = false;
          
            //  Prüfen ob kein Alphanummerischer Wert und kein NULL
            if(bEingabe_Is_NULL == false && bEingabe_Is_Double)   //  Nummerisch und NOT NULL
            {
                //  Prüfen ob Nachkommastellen
                if(dEingabe != ((int)dEingabe)) //  Keine Ganzzahl
                {
                    strWarningErroMessage = $"Ungültiger Wert: '{strEingabe}'.\rBitte nummerische, ganzzahligen Wert eingeben!";
                    bValid = false;
                }
                else
                {
                    //  Prüfen, ob innerhalb der Range
                    if(nEingabe >= nMinimumWert && nEingabe < nMaximumWert)    //  In der Range
                    {
                        bValid = true;
                    }
                    else                                                      //  Ausserhalb der Range
                    {
                        strWarningErroMessage = $"Ungültiger Wert: '{strEingabe}'.\rBitte nummerische, ganzzahligen Wert eingeben!";
                        bValid =false;
                    }
                }
            }
            else    //  Alphanummerisch oder NULL
            {
                //  Prüfen, was genau falsch ist
                if(bEingabe_Is_NULL)            //  NULL Value
                    strWarningErroMessage = $"Eingabe leer!\rBitte nummerische, ganzzahligen Wert eingeben!";
                else
                    if(!bEingabe_Is_Parsable)   //    Alphanummerischer Wert
                        strWarningErroMessage = $"Ungültiger Wert: '{strEingabe}'.\rBitte nummerische, ganzzahligen Wert eingeben!";

                //  In jedem Fall ist die Validität false
                bValid = false;
            }

            //  Warnung / Error Ausgeben
            if(bValid == false)
            {
                WarningErrorMessage(strWarningErroMessage, oField);
            }

            //  Zürückgeben der Validität und Eingabewertes als Integer
            return (bValid, nEingabe);
        }

        /// <summary>
        /// Gibt erst die Fehlermeldung aus und leert danach das Eingabefeld und legt den Focus daraus
        /// </summary>
        /// <param name="strMessage"></param>
        /// <param name="oField"></param>
        private void WarningErrorMessage(string strMessage, TextBox oField)
        {
            MessageBox.Show(strMessage, "Benutzereingabe", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            oField.Clear();
            oField.Focus();
        }

        /// <summary>
        /// Bestimmt den Teiler des Übergebenen Wertes.
        /// Als String werden alle Werte mit einem Einleitungstext und die Resultate dann
        /// mit Zeilenumbruch zurückgegeben
        /// </summary>
        /// <param name="nWert"></param>
        /// <param name="nMinimumWert"></param>
        /// <param name="nMaximumWert"></param>
        /// <returns></returns>
        private string BestimmeTeiler(int nWert, int nMinimumWert, int nMaximumWert)
        {
            //  Den Rückgabe String deklarieren und mit dem Text bereits definieren
            string strWert = $"Die ganzzahligen Teiler von {nWert} sind:";

            //  Counter setzen
            /*
             * Hier war angedacht gewesen, das ganze zu optimieren.
             * Doch da auch ungerade Werte vorkommen können (Teiler von 30 ist auch 3)
            */
            int nCounter = 1;

            //  Durchlaufen und Teiler bestimmen.
            for (int nLaufnummer = nMinimumWert; nLaufnummer < nWert; nLaufnummer = nLaufnummer + nCounter)
            {
                //  Wenn Modulo 0 zurückgibt ist es ein Teiler
                if (nWert % nLaufnummer == 0)
                {
                    string cTeiler = nLaufnummer.ToString();
                    strWert = strWert + Environment.NewLine + cTeiler;
                }
            }

            //  Konkatinierter String zurückgeben
            return strWert;
        }

        /// <summary>
        /// Wert auf das Übergebene Label setzen
        /// </summary>
        /// <param name="strWert"></param>
        /// <param name="oLabel"></param>
        private void SetzeResultat(string strWert, Label oLabel)
        {
            oLabel.Text = strWert;
        }

    }
}
