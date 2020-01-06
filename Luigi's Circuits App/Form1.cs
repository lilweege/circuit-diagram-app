using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luigi_s_Circuits_App
{
    public partial class Form1 : Form
    {
        /*
            Written by: Luigi Quattrociocchi
            Written for: Mr. Kolch
            Subject: TEJ 3M1
            Date: 31 March 2019
            Description: Parallel and Series Circuit App
        */



        // Declare variables 

        // "dynamic" variables
        TextBox tb = new TextBox();
        PictureBox pb = new PictureBox();
        List<TextBox> DynamicTBList = new List<TextBox> { };
        List<PictureBox> DynamicPBList = new List<PictureBox> { };

        double d;

        int numresistors;
        int tmpresistors;
        int errors;

        // calculation variables
        double[] voltage = new double[100];
        double[] current = new double[100];
        double[] resistance = new double[100];
        double voltageTotal;
        double currentTotal;
        double resistanceTotal;
        double marginerror = 0.2;

        int VoltsMin;
        int VoltsMax;
        int AmpsMin;
        int AmpsMax;
        int OhmsMin;
        int OhmsMax; 

        // unit conversion variables
        List<string> units = new List<string> { "Nano", "Micro", "Milli", "Centi", "", "Hecto", "Kilo", "Mega", "Giga" };
        List<string> unitsymb = new List<string> { "n", "µ", "m", "c", "", "h", "k", "M", "G" };
        List<double> unitindex = new List<double> { Math.Pow(10, -9), Math.Pow(10, -6), Math.Pow(10, -3), Math.Pow(10, -2), Math.Pow(10, 0), Math.Pow(10, 2), Math.Pow(10, 3), Math.Pow(10, 6), Math.Pow(10, 9) };
        double voltagemultiplier = Math.Pow(10, 0);
        double resistancemultiplier = Math.Pow(10, 0);
        double currentmultiplier = Math.Pow(10, 0);
        
        // bools for "status" of form
        bool expmode = false;
        bool diagram = true;
        bool parallel = true;
        bool series = false;
        
        // for solvable case (placeholdes)
        Random rng = new Random();
        int rxPHolder;
        int ryPHolder;
        int tmprandom;
        bool solvable;
        bool Vshown;
        bool Ishown;


        public Form1()
        {
            InitializeComponent();
        }

        private void LQbuttonGenerate_Click(object sender, EventArgs e) // This function generates a circuit, makes sure it's solvable, draws the circuit diagram
        {
            // error detection for random value boxes
            if (LQtextBoxVoltageMin.Text != "" && LQtextBoxVoltageMax.Text != "" && LQtextBoxCurrentMin.Text != "" && LQtextBoxCurrentMax.Text != "" && LQtextBoxResistanceMin.Text != "" && LQtextBoxResistanceMax.Text != "" && double.TryParse(LQtextBoxVoltageMin.Text, out d) && double.TryParse(LQtextBoxVoltageMax.Text, out d) && double.TryParse(LQtextBoxCurrentMin.Text, out d) && double.TryParse(LQtextBoxCurrentMax.Text, out d) && double.TryParse(LQtextBoxResistanceMin.Text, out d) && double.TryParse(LQtextBoxResistanceMax.Text, out d))
            {
                // round values
                VoltsMin = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxVoltageMin.Text)));
                VoltsMax = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxVoltageMax.Text)));
                AmpsMin = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxCurrentMin.Text)));
                AmpsMax = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxCurrentMax.Text)));
                OhmsMin = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxResistanceMin.Text)));
                OhmsMax = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxResistanceMax.Text)));
                if (VoltsMin > VoltsMax || AmpsMin > AmpsMax || OhmsMin > OhmsMax)
                {
                    // error if min > max
                    MessageBox.Show("Min must not be larger than Max", "Random Value Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (VoltsMax >= 1000 || AmpsMax >= 1000 || OhmsMax >= 1000)
                {
                    // error if max > 1000
                    MessageBox.Show("Values must be less than 1000, change unit instead", "Random Value Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    // push values to text boxes
                    LQtextBoxVoltageMin.Text = VoltsMin.ToString();
                    LQtextBoxVoltageMax.Text = VoltsMax.ToString();
                    LQtextBoxCurrentMin.Text = AmpsMin.ToString();
                    LQtextBoxCurrentMax.Text = AmpsMax.ToString();
                    LQtextBoxResistanceMin.Text = OhmsMin.ToString();
                    LQtextBoxResistanceMax.Text = OhmsMax.ToString();
                }
            }
            else
            {
                // error if non-int value
                MessageBox.Show("Enter a valid integer", "Random Value Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // error detection for num resistors box
            if (LQtextBoxNumResistors.Text != "" && double.TryParse(LQtextBoxNumResistors.Text, out d))
            {
                numresistors = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxNumResistors.Text)));
                LQtextBoxNumResistors.Text = numresistors.ToString();
                tmpresistors = numresistors;
            }

            // error cases for num resistors
            if (numresistors <= 1)
            {
                MessageBox.Show("Resistors must be an integer greater than 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!expmode && numresistors > 99)
                {
                    MessageBox.Show("Number of resistors exceeded limit of 99, go to experimental mode for more resistors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // get rid of all generated elements
                    for (int i = 0; i < DynamicTBList.Count(); i++)
                    {
                        DynamicTBList[i].Dispose();
                    }
                    DynamicTBList.Clear();

                    for (int i = 0; i < DynamicPBList.Count(); i++)
                    {
                        DynamicPBList[i].Dispose();
                    }
                    DynamicPBList.Clear();

                    // reset all values
                    for (int i = 0; i < voltage.Length; i++)
                    {
                        voltage[i] = 0;
                        current[i] = 0;
                        resistance[i] = 0;
                    }
                    voltageTotal = 0;
                    currentTotal = 0;
                    resistanceTotal = 0;

                    LQbuttonCheckAnswers.Enabled = true;
                    LQbuttonShowAnswers.Enabled = true;

                    if (parallel)
                    {
                        // calculations for parallel case

                        voltageTotal = rng.Next(VoltsMin, VoltsMax + 1) / voltagemultiplier;
                        for (int i = 1; i < numresistors + 1; i++)
                        {
                            voltage[i] = voltageTotal;
                            resistance[i] = rng.Next(OhmsMin, OhmsMax + 1) / resistancemultiplier;
                            current[i] = Math.Round(((voltage[i] * voltagemultiplier) / (resistance[i] * resistancemultiplier)), 2) / currentmultiplier;
                            currentTotal += current[i];
                            resistanceTotal += 1 / resistance[i];
                            if (diagram)
                            {
                                // create circuit diagram for parallel (dynamically)
                                pb = new PictureBox
                                {
                                    Image = Properties.Resources.ParallelResistor,
                                    Size = new Size(31, 295)
                                };
                                if (numresistors > 15)
                                {
                                    pb.Location = new Point(2 * 28 + 477 * (i - 1) / 15, 30);

                                    PictureBox topline = new PictureBox
                                    {
                                        Image = Properties.Resources.Line,
                                        Size = new Size(32, 5),
                                        Location = new Point(42 + 477 * (i - 1) / 15, 25)
                                    };
                                    LQpanelDiagram.Controls.Add(topline);
                                    DynamicPBList.Add(topline);
                                    topline.BringToFront();
                                    PictureBox botline = new PictureBox
                                    {
                                        Image = Properties.Resources.Line,
                                        Size = new Size(32, 5),
                                        Location = new Point(42 + 477 * (i - 1) / 15, 325)
                                    };
                                    LQpanelDiagram.Controls.Add(botline);
                                    DynamicPBList.Add(botline);
                                    botline.BringToFront();
                                }
                                else
                                {
                                    pb.Location = new Point(28 + 477 * (i - 1) / (numresistors), 30);
                                    if (i == 1)
                                    {
                                        pb.Location = new Point(504, 30);
                                    }
                                }
                                LQpanelDiagram.Controls.Add(pb);
                                DynamicPBList.Add(pb);
                                pb.BringToFront();
                            }
                        }
//                        currentTotal = Math.Round(current.Sum(), 2);
                        resistanceTotal = Math.Round(1 / resistanceTotal, 2);
                    }

                    if (series)
                    {
                        // calculations for series

                        currentTotal = rng.Next(AmpsMin, AmpsMax + 1) / currentmultiplier;
                        for (int i = 1; i < numresistors + 1; i++)
                        {
                            current[i] = currentTotal;
                            voltage[i] = rng.Next(VoltsMin, VoltsMax + 1) / voltagemultiplier;
                            resistance[i] = Math.Round(((voltage[i] * voltagemultiplier) / (current[i] * currentmultiplier)) / resistancemultiplier, 2);

                            if (diagram)
                            {
                                // create circuit diagram for series
                                pb = new PictureBox
                                {
                                    Image = Properties.Resources.SeriesResistor,
                                    Size = new Size(100, 31)
                                };
                                if (numresistors > 11)
                                {
                                    if (i == 1)
                                    {

                                        PictureBox linecover = new PictureBox
                                        {
                                            Size = new Size(31, 295),
                                            Location = new Point(504, 30)
                                        };
                                        LQpanelDiagram.Controls.Add(linecover);
                                        DynamicPBList.Add(linecover);
                                        linecover.BringToFront();

                                        PictureBox topline = new PictureBox
                                        {
                                            Image = Properties.Resources.Line,
                                            Size = new Size(32, 5),
                                            Location = new Point(-61 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(numresistors) / 2) + 1) / 6, 25)
                                        };
                                        LQpanelDiagram.Controls.Add(topline);
                                        DynamicPBList.Add(topline);
                                        topline.BringToFront();

                                        PictureBox botline = new PictureBox
                                        {
                                            Image = Properties.Resources.Line,
                                            Size = new Size(32, 5),
                                            Location = new Point(-61 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(numresistors) / 2) + 1) / 6, 325)
                                        };

                                        if (numresistors % 2 == 0)
                                        {
                                            botline.Location = new Point(-128 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(numresistors) / 2) + 1) / 6, 325);
                                            botline.Size = new Size(99, 5);
                                        }
                                        LQpanelDiagram.Controls.Add(botline);
                                        DynamicPBList.Add(botline);
                                        botline.BringToFront();

                                        pb.Image = Properties.Resources.ParallelResistor;
                                        pb.Size = new Size(31, 295);
                                        pb.Location = new Point(-47 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(numresistors) / 2) + 1) / 6, 30);
                                    }
                                    else if (i % 2 == 0)
                                    {
                                        pb.Location = new Point(-47 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(i + 1) / 2)) / 6, 12);
                                    }
                                    else
                                    {
                                        pb.Location = new Point(-47 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(i - 1) / 2)) / 6, 312);
                                    }
                                }
                                else
                                {
                                    if (i == 1)
                                    {
                                        pb.Image = Properties.Resources.ParallelResistor;
                                        pb.Size = new Size(31, 295);
                                        pb.Location = new Point(504, 30);
                                    }
                                    else if (i % 2 == 0)
                                    {
                                        pb.Location = new Point(-47 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(i + 1) / 2)) / (numresistors / 2 + 1), 12);
                                    }
                                    else
                                    {
                                        pb.Location = new Point(-47 + 542 * Convert.ToInt32(Math.Floor(Convert.ToDouble(i - 1) / 2)) / ((numresistors - 1) / 2 + 1), 312);
                                    }
                                }
                                DynamicPBList.Add(pb);
                                LQpanelDiagram.Controls.Add(pb);
                                pb.BringToFront();
                            }
                        }
                        voltageTotal = Math.Round(voltage.Sum(), 2);
                        resistanceTotal = Math.Round(resistance.Sum(), 2);
                    }

                    // change size (if show diagram toggled)
                    if (diagram)
                    {
                        Size = new Size(825, 650);
                    }
                    else
                    {
                        Size = new Size(825, 288);
                    }


                    // create cases for shown and hidden values to make sure always solvable by user
                    solvable = false;
                    bool oneintwo = Convert.ToBoolean(rng.Next(0, 2)); // this is for chosing one of two cases (although there are many more) of given values

                    // while loop makes sure solvable case is always true, else repeat
                    while (!solvable)
                    {

                        Vshown = false;
                        Ishown = false;

                        for (int i = 0; i < DynamicTBList.Count(); i++)
                        {
                            DynamicTBList[i].Dispose();
                        }
                        DynamicTBList.Clear();

                        if (!oneintwo)
                        {
                            ryPHolder = rng.Next(1, numresistors + 2);
                            tmprandom = rng.Next(1, numresistors + 2);
                        }

                        for (int y = 0; y <= numresistors + 1; y++)
                        {
                            if (oneintwo)
                            {
                                rxPHolder = rng.Next(1, 4);

                                while ((Vshown && rxPHolder == 1) || (Ishown && rxPHolder == 2))
                                {
                                    rxPHolder = rng.Next(1, 4);
                                }
                            }

                            for (int x = 0; x < 4; x++)
                            {

                                tb = new TextBox
                                {
                                    Size = new Size(50, 10),
                                    Location = new Point(575 + 55 * x, 12 + 30 * y),
                                    Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
                                };

                                if (x == 0)
                                {
                                    if (y > numresistors)
                                    {
                                        tb.Text = "Total";
                                    }
                                    else if (y >= 1)
                                    {
                                        tb.Text = "R" + y;
                                    }
                                    if (parallel)
                                    {
                                        tb.BackColor = Color.PaleTurquoise;
                                    }
                                    else
                                    {
                                        tb.BackColor = Color.Pink;
                                    }
                                    tb.ReadOnly = true;
                                }
                                else if (y == 0)
                                {
                                    switch (x)
                                    {
                                        case 1: tb.Text = unitsymb[unitindex.IndexOf(voltagemultiplier)] + "V"; break;
                                        case 2: tb.Text = unitsymb[unitindex.IndexOf(currentmultiplier)] + "A"; break;
                                        case 3: tb.Text = unitsymb[unitindex.IndexOf(resistancemultiplier)] + "Ω"; break;
                                    }
                                    if (parallel)
                                    {
                                        tb.BackColor = Color.PaleTurquoise;
                                    }
                                    else
                                    {
                                        tb.BackColor = Color.Pink;
                                    }
                                    tb.ReadOnly = true;
                                }
                                else
                                {
                                    if (parallel)
                                    {
                                        if (oneintwo)
                                        {
                                            if (rxPHolder == x)
                                            {
                                                if (y != numresistors + 1)
                                                {
                                                    switch (rxPHolder)
                                                    {
                                                        case 1: tb.Text = voltage[y].ToString(); Vshown = true; break;
                                                        case 2: tb.Text = current[y].ToString(); break;
                                                        case 3: tb.Text = resistance[y].ToString(); break;
                                                    }
                                                }
                                                else
                                                {
                                                    switch (rxPHolder)
                                                    {
                                                        case 1: tb.Text = voltageTotal.ToString(); Vshown = true; break;
                                                        case 2: tb.Text = currentTotal.ToString(); break;
                                                        case 3: tb.Text = resistanceTotal.ToString(); break;
                                                    }
                                                }
                                            }
                                            
                                            if (!solvable && x == 1 && tb.Text != "")
                                            {
                                                solvable = true;
                                            }
                                        }
                                        else
                                        {
                                            Vshown = true;
                                            if (x != 1)
                                            {
                                                if (ryPHolder != y)
                                                {
                                                    if (y != numresistors + 1)
                                                    {
                                                        if (tmprandom == y)
                                                        {
                                                            switch (x)
                                                            {
                                                                case 2: tb.Text = current[y].ToString(); break;
                                                                case 3: tb.Text = resistance[y].ToString(); break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (x)
                                                            {
                                                                case 3: tb.Text = resistance[y].ToString(); break;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (tmprandom == y)
                                                        {
                                                            switch (x)
                                                            {
                                                                case 2: tb.Text = currentTotal.ToString(); break;
                                                                case 3: tb.Text = resistanceTotal.ToString(); break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (x)
                                                            {
                                                                case 3: tb.Text = resistanceTotal.ToString(); break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (x == 3 && tb.Text != "" && DynamicTBList[DynamicTBList.Count() - 1].Text != "")
                                            {
                                                solvable = true;
                                            }
                                        }
                                    }

                                    if (series)
                                    {
                                        if (oneintwo)
                                        {
                                            if (rxPHolder == x)
                                            {
                                                if (y != numresistors + 1)
                                                {
                                                    switch (rxPHolder)
                                                    {
                                                        case 1: tb.Text = voltage[y].ToString(); break;
                                                        case 2: tb.Text = current[y].ToString(); Ishown = true; break;
                                                        case 3: tb.Text = resistance[y].ToString(); break;
                                                    }
                                                }
                                                else
                                                {
                                                    switch (rxPHolder)
                                                    {
                                                        case 1: tb.Text = voltageTotal.ToString(); break;
                                                        case 2: tb.Text = currentTotal.ToString(); Ishown = true; break;
                                                        case 3: tb.Text = resistanceTotal.ToString(); break;
                                                    }
                                                }
                                            }
                                            if (!solvable && x == 2 && tb.Text != "")
                                            {
                                                solvable = true;
                                            }
                                        }
                                        else
                                        {
                                            Ishown = true;
                                            if (x != 2)
                                            {
                                                if (ryPHolder != y)
                                                {
                                                    if (y != numresistors + 1)
                                                    {
                                                        if (tmprandom == y)
                                                        {
                                                            switch (x)
                                                            {
                                                                case 1: tb.Text = voltage[y].ToString(); break;
                                                                case 3: tb.Text = resistance[y].ToString(); break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (x)
                                                            {
                                                                case 3: tb.Text = resistance[y].ToString(); break;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (tmprandom == y)
                                                        {
                                                            switch (x)
                                                            {
                                                                case 1: tb.Text = voltageTotal.ToString(); break;
                                                                case 3: tb.Text = resistanceTotal.ToString(); break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            switch (x)
                                                            {
                                                                case 3: tb.Text = resistanceTotal.ToString(); break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (x == 3 && tb.Text != "" && DynamicTBList[DynamicTBList.Count() - 2].Text != "")
                                            {
                                                solvable = true;
                                            }
                                        }
                                    }
                                }
                                DynamicTBList.Add(tb);
                            }
                        }
//                    solvable = true;
                    }
                    for (int i = 0; i <= DynamicTBList.Count - 1; i++)
                    {
                        Controls.Add(DynamicTBList[i]);
                    }
                }
            }
        }

        private void LQbuttonShowAnswers_Click(object sender, EventArgs e) // This function pushes correct answers from variables (arrays) to generated text boxes
        {
            int i = 0; // counter for Dynamic text boxes to match against correct values
            for (int y = 0; y <= tmpresistors + 1; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (x != 0 && y != 0 && y != tmpresistors + 1)
                    {
                        switch (x)
                        {
                            case 1: DynamicTBList[i].Text = voltage[y].ToString(); break;
                            case 2: DynamicTBList[i].Text = current[y].ToString(); break;
                            case 3: DynamicTBList[i].Text = resistance[y].ToString(); break;
                        }
                    }
                    else if (y == tmpresistors + 1)
                    {
                        switch (x)
                        {
                            case 1: DynamicTBList[i].Text = voltageTotal.ToString(); break;
                            case 2: DynamicTBList[i].Text = currentTotal.ToString(); break;
                            case 3: DynamicTBList[i].Text = resistanceTotal.ToString(); break;
                        }
                        //tb.Text = "(" + x + ", " + y + ")";
                    }
                    if (x != 0 && y != 0)
                    {
                        DynamicTBList[i].BackColor = Color.PaleGreen;
                    }
                    i++;
                }
            }
        }

        private void LQbuttonCheckAnswers_Click(object sender, EventArgs e) // This function checks current text box string against variables
        {
            errors = 0;
            int i = 0;
            for (int y = 0; y <= tmpresistors + 1; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // error detection
                    if (DynamicTBList[i].Text != "" && double.TryParse(DynamicTBList[i].Text, out d))
                    {
                        if (y != 0 && y != tmpresistors + 1)
                        {
                            // check if text box matches variable
                            if ((x == 1 && DynamicTBList[i].Text != voltage[y].ToString()) || (x == 2 && DynamicTBList[i].Text != current[y].ToString()) || (x == 3 && DynamicTBList[i].Text != resistance[y].ToString()))
                            {
                                // check if text box is within margin of error
                                if (x == 1 && (double.Parse(DynamicTBList[i].Text) <= voltage[y] + marginerror && double.Parse(DynamicTBList[i].Text) >= voltage[y] - marginerror) || (x == 2 && (double.Parse(DynamicTBList[i].Text) <= current[y] + marginerror && double.Parse(DynamicTBList[i].Text) >= current[y] - marginerror)) || (x == 3 && (double.Parse(DynamicTBList[i].Text) <= resistance[y] + marginerror && double.Parse(DynamicTBList[i].Text) >= resistance[y] - marginerror)))
                                {
                                    DynamicTBList[i].BackColor = Color.Yellow;
                                }
                                else
                                {
                                    // add an error
                                    errors++;
                                    DynamicTBList[i].BackColor = Color.Salmon;
                                }
                            }
                            else
                            {
                                if (x != 0)
                                {
                                    // correct
                                    DynamicTBList[i].BackColor = Color.PaleGreen;
                                }
                            }
                        }
                        else if (y == tmpresistors + 1)
                        {
                            if ((x == 1 && DynamicTBList[i].Text != voltageTotal.ToString()) || (x == 2 && DynamicTBList[i].Text != currentTotal.ToString()) || (x == 3 && DynamicTBList[i].Text != resistanceTotal.ToString()))
                            {
                                if (x == 1 && (double.Parse(DynamicTBList[i].Text) <= voltageTotal + marginerror && double.Parse(DynamicTBList[i].Text) >= voltageTotal - marginerror) || (x == 2 && (double.Parse(DynamicTBList[i].Text) <= currentTotal + marginerror && double.Parse(DynamicTBList[i].Text) >= currentTotal - marginerror)) || (x == 3 && (double.Parse(DynamicTBList[i].Text) <= resistanceTotal + marginerror && double.Parse(DynamicTBList[i].Text) >= resistanceTotal - marginerror)))
                                {
                                    DynamicTBList[i].BackColor = Color.Yellow;
                                }
                                else
                                {
                                    errors++;
                                    DynamicTBList[i].BackColor = Color.Salmon;
                                }
                            }
                            else
                            {
                                if (x != 0)
                                {
                                    DynamicTBList[i].BackColor = Color.PaleGreen;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (x != 0 && y != 0)
                        {
                            errors++;
                            DynamicTBList[i].BackColor = Color.Salmon;
                        }
                    }
                i++;
                }
            }

            if (errors == 0)
            {
                MessageBox.Show("All answers are correct", "Correct", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect Values, you have " + errors + " errors", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LQbuttonIncrementResistors_Click(object sender, EventArgs e) // Increments number of resistors
        {
            if (double.TryParse(LQtextBoxNumResistors.Text, out d))
            {
                numresistors = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxNumResistors.Text)));
                numresistors++;
                LQtextBoxNumResistors.Text = numresistors.ToString();
            }
        }

        private void LQbuttonDecrementResistors_Click(object sender, EventArgs e) // Decrements number of resistors
        {
            if (double.TryParse(LQtextBoxNumResistors.Text, out d))
            {
                if (numresistors > 0)
                {
                    numresistors = Convert.ToInt32(Math.Round(double.Parse(LQtextBoxNumResistors.Text)));
                    numresistors--;
                }
                else
                {
                    numresistors = 0;
                }
                LQtextBoxNumResistors.Text = numresistors.ToString();
            }
        }

        private void LQtrackBarMarginError_Scroll(object sender, EventArgs e) // Bar changes margin of error variable
        {
            marginerror = Convert.ToDouble(LQtrackBarMarginError.Value) / 10;
            LQlabelMarginError.Text = "Margin of error (" + marginerror + ")";
        }

        private void LQbuttonCycleUnitVolts_Click(object sender, EventArgs e) // Cycles generated voltage unit
        {
            if (voltagemultiplier == unitindex[8]) // checks if voltage multiplier is at the top of the unitindex list
            {
                voltagemultiplier = unitindex[0]; // sets voltagemultiplier to value at the bottom of list
            }
            else
            {
                voltagemultiplier = unitindex[unitindex.IndexOf(voltagemultiplier) + 1]; // increments voltagemultiplier by one (up)
            }
            if (voltagemultiplier != unitindex[4])
            {
                LQbuttonCycleUnitVolts.Text = units[unitindex.IndexOf(voltagemultiplier)] + "volts";
            }
            else
            {
                LQbuttonCycleUnitVolts.Text = units[unitindex.IndexOf(voltagemultiplier)] + "Volts";
            }
        }

        private void LQbuttonCycleUnitAmps_Click(object sender, EventArgs e) // Cycles generated current unit
        {
            if (currentmultiplier == unitindex[8]) // checks if current multiplier is at the top of the unitindex list
            {
                currentmultiplier = unitindex[0]; // sets current multiplier to value at the bottom of list
            }
            else
            {
                currentmultiplier = unitindex[unitindex.IndexOf(currentmultiplier) + 1]; // increments resistance multiplier by one (up)
            }
            if (currentmultiplier != unitindex[4])
            {
                LQbuttonCycleUnitAmps.Text = units[unitindex.IndexOf(currentmultiplier)] + "amps";
            }
            else
            {
                LQbuttonCycleUnitAmps.Text = units[unitindex.IndexOf(currentmultiplier)] + "Amps";
            }
        }

        private void LQbuttonCycleUnitOhms_Click(object sender, EventArgs e) // Cycles generated resistance unit
        {
            if (resistancemultiplier == unitindex[8]) // checks if resistance multiplier is at the top of the unitindex list
            {
                resistancemultiplier = unitindex[0]; // sets resistance multiplier to value at the bottom of list
            }
            else
            {
                resistancemultiplier = unitindex[unitindex.IndexOf(resistancemultiplier) + 1]; // increments resistance multiplier by one (up)
            }
            if (resistancemultiplier != unitindex[4])
            {
                LQbuttonCycleUnitOhms.Text = units[unitindex.IndexOf(resistancemultiplier)] + "ohms";
            }
            else
            {
                LQbuttonCycleUnitOhms.Text = units[unitindex.IndexOf(resistancemultiplier)] + "Ohms";
            }
        }

        private void LQbuttonCircuitType_Click(object sender, EventArgs e) // Cycles circuit type (Parallel/Series)
        {
            if (parallel)
            {
                // change color scheme
                LQtextBoxVoltageMin.BackColor = Color.Pink;
                LQtextBoxVoltageMax.BackColor = Color.Pink;
                LQtextBoxCurrentMin.BackColor = Color.Pink;
                LQtextBoxCurrentMax.BackColor = Color.Pink;
                LQtextBoxResistanceMin.BackColor = Color.Pink;
                LQtextBoxResistanceMax.BackColor = Color.Pink;
                LQtextBoxNumResistors.BackColor = Color.Pink;
                BackColor = Color.PaleTurquoise;
                // change circuit type status
                series = true;
                parallel = false;
                LQbuttonCircuitType.Text = "Series";
                LQtextBoxCurrentMin.Enabled = true;
                LQtextBoxCurrentMax.Enabled = true;
                LQtextBoxResistanceMin.Enabled = false;
                LQtextBoxResistanceMax.Enabled = false;
            }
            else if (series)
            {
                // change color scheme
                LQtextBoxVoltageMin.BackColor = Color.PaleTurquoise;
                LQtextBoxVoltageMax.BackColor = Color.PaleTurquoise;
                LQtextBoxCurrentMin.BackColor = Color.PaleTurquoise;
                LQtextBoxCurrentMax.BackColor = Color.PaleTurquoise;
                LQtextBoxResistanceMin.BackColor = Color.PaleTurquoise;
                LQtextBoxResistanceMax.BackColor = Color.PaleTurquoise;
                LQtextBoxNumResistors.BackColor = Color.PaleTurquoise;
                BackColor = Color.Pink;
                // change circuit type status
                series = false;
                parallel = true;
                LQbuttonCircuitType.Text = "Parallel";
                LQtextBoxCurrentMin.Enabled = false;
                LQtextBoxCurrentMax.Enabled = false;
                LQtextBoxResistanceMin.Enabled = true;
                LQtextBoxResistanceMax.Enabled = true;
            }
        }

        private void LQbuttonExperimental_Click(object sender, EventArgs e) // Enables "Experimental Mode"
        {
            // safety warning message
            if (!expmode && MessageBox.Show("Experimental Mode sets array limit from 100 to 100M\nUse at your own risk, PC crashes are not uncommon depending on hardware\nDisabling the diagram is recommended\n\nProceed?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // sets experimental mode flag
                expmode = true;

                // clear existing diagram/boxes
                for (int i = 0; i < DynamicTBList.Count(); i++)
                {
                    DynamicTBList[i].Dispose();
                }
                DynamicTBList.Clear();

                for (int i = 0; i < DynamicPBList.Count(); i++)
                {
                    DynamicPBList[i].Dispose();
                }
                DynamicPBList.Clear();

                // change array size (cause lag)
                voltage = new double[99999999];
                current = new double[99999999];
                resistance = new double[99999999];

                if (diagram)
                {
                    Size = new Size(Size.Width, 650);
                }
                else
                {
                    Size = new Size(Size.Width, 288);
                }
                LQbuttonExperimental.Text = "Force Quit";

            }
            else if (expmode)
            {
                // turn into an exit button
                Close();
            }
        }

        private void LQbuttonReset_Click(object sender, EventArgs e) // Reset the form to initial state (mostly)
        {
            expmode = false;
            diagram = true;
            LQpanelDiagram.Visible = true;
            LQbuttonCheckAnswers.Enabled = false;
            LQbuttonShowAnswers.Enabled = false;
            LQbuttonToggleDiagram.Text = "Turn Off Diagram";
            Size = new Size(585, 650);

            for (int i = 0; i < voltage.Length; i++)
            {
                voltage[i] = 0;
                current[i] = 0;
                resistance[i] = 0;
            }
            voltageTotal = 0;
            currentTotal = 0;
            resistanceTotal = 0;

            numresistors = 3;
            LQtextBoxNumResistors.Text = numresistors.ToString();

            parallel = true;
            series = false;
            LQbuttonCircuitType.Text = "Parallel";
            LQtextBoxCurrentMin.Enabled = false;
            LQtextBoxCurrentMax.Enabled = false;
            LQtextBoxResistanceMin.Enabled = true;
            LQtextBoxResistanceMax.Enabled = true;

            voltagemultiplier = Math.Pow(10, 0);
            resistancemultiplier = Math.Pow(10, 0);
            currentmultiplier = Math.Pow(10, 0);
            LQbuttonCycleUnitVolts.Text = "Volts";
            LQbuttonCycleUnitAmps.Text = "Amps";
            LQbuttonCycleUnitOhms.Text = "Ohms";

            VoltsMin = 1;
            VoltsMax = 10;
            AmpsMin = 1;
            AmpsMax = 10;
            OhmsMin = 1;
            OhmsMax = 10;
            LQtextBoxVoltageMin.Text = VoltsMin.ToString();
            LQtextBoxVoltageMax.Text = VoltsMax.ToString();
            LQtextBoxCurrentMin.Text = AmpsMin.ToString();
            LQtextBoxCurrentMax.Text = AmpsMax.ToString();
            LQtextBoxResistanceMin.Text = OhmsMin.ToString();
            LQtextBoxResistanceMax.Text = OhmsMax.ToString();

            LQtrackBarMarginError.Value = 2;
            LQlabelMarginError.Text = "Margin of error (0.2)";
            marginerror = 0.2;

            LQtextBoxNumResistors.BackColor = Color.PaleTurquoise;
            LQtextBoxVoltageMin.BackColor = Color.PaleTurquoise;
            LQtextBoxVoltageMax.BackColor = Color.PaleTurquoise;
            LQtextBoxCurrentMin.BackColor = Color.PaleTurquoise;
            LQtextBoxCurrentMax.BackColor = Color.PaleTurquoise;
            LQtextBoxResistanceMin.BackColor = Color.PaleTurquoise;
            LQtextBoxResistanceMax.BackColor = Color.PaleTurquoise;
            BackColor = Color.Pink;

            Size = new Size(585, 650);

            for (int i = 0; i < DynamicPBList.Count(); i++)
            {
                DynamicPBList[i].Dispose();
            }
            DynamicPBList.Clear();

            for (int i = 0; i < DynamicTBList.Count(); i++)
            {
                DynamicTBList[i].Dispose();
            }
            DynamicTBList.Clear();
        }

        private void LQbuttonToggleDiagram_Click(object sender, EventArgs e) // Enables/Disables the circuit diagram
        {
            if (diagram)
            {
                diagram = false;
                LQpanelDiagram.Visible = false;
                LQbuttonToggleDiagram.Text = "Turn On Diagram";
                Size = new Size(Size.Width, 288);

                for (int i = 0; i < DynamicPBList.Count(); i++)
                {
                    DynamicPBList[i].Visible = false;
                }
            }
            else
            {
                diagram = true;
                LQpanelDiagram.Visible = true;
                LQbuttonToggleDiagram.Text = "Turn Off Diagram";
                Size = new Size(Size.Width, 650);

                for (int i = 0; i < DynamicPBList.Count(); i++)
                {
                    DynamicPBList[i].Visible = true;
                }
            }
        }
    }
}