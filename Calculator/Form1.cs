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

namespace Calculator
{
    public partial class Form1 : Form
    {
        Button clickedButton;
        double numberFirst, numberSecond, numberResult;
        string mathOperator;
        bool isFirstNumberPlaced, doesNumberLabelNeedToBeClear;
        Journal journal;
        Loger loger;
        public Form1()
        {
            InitializeComponent();
            mathOperator = "";
            isFirstNumberPlaced = false;
            doesNumberLabelNeedToBeClear = false;
            journal = new Journal(panel1);
            loger = new Loger(logfileAddressTextBox);
        }

        private void SaveNewLogfileAddressClick(object sender, EventArgs e)
        {
            loger.ChangeLogfileAddress(logfileAddressTextBox.Text);
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            try
            {
                clickedButton = (Button)sender;
                switch (clickedButton.Text)
                {
                    //ВВОД
                    case "0":
                        ClearAfterActions();
                        if (numberLabel.Text != "0" && numberLabel.Text.Length <= 21)
                            numberLabel.Text += "0";
                        isFirstNumberPlaced = false;
                        break;
                    case "1":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "1";
                        }
                        isFirstNumberPlaced = false;
                        break;
                    case "2":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "2";
                        }
                        isFirstNumberPlaced = false;
                        break;
                    case "3":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "3";
                        }
                        isFirstNumberPlaced = false;
                        break;
                    case "4":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "4";
                        }
                        isFirstNumberPlaced = false;
                        break;
                    case "5":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "5";
                        }
                        break;
                    case "6":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "6";
                        }
                        isFirstNumberPlaced = false;
                        break;
                    case "7":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "7";
                        }
                        break;
                    case "8":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "8";
                        }
                        break;
                    case "9":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21)
                        {
                            if (numberLabel.Text == "0") numberLabel.Text = "";
                            numberLabel.Text += "9";
                        }
                        isFirstNumberPlaced = false;
                        break;
                    case ",":
                        ClearAfterActions();
                        if (numberLabel.Text.Length <= 21 && !(numberLabel.Text.Contains(',')))
                            numberLabel.Text += ",";
                        isFirstNumberPlaced = false;
                        break;
                    case "+/-":
                        ClearAfterActions();
                        if (numberLabel.Text.Trim('-').Length <= 22)
                        {
                            if (numberLabel.Text.ElementAt(0) == '-')
                                numberLabel.Text = numberLabel.Text.Remove(0, 1);
                            else if (numberLabel.Text != "0")
                                numberLabel.Text = numberLabel.Text.Insert(0, "-");
                        }
                        break;
                    //ОЧИСТКА
                    //полная очистка
                    case "C":
                        numberFirst = 0;
                        numberSecond = 0;
                        numberResult = 0;
                        mathOperator = "";
                        mathExpressionLabel.Text = "";
                        numberLabel.Text = "0";
                        isFirstNumberPlaced = false;
                        journal = new Journal(panel1);
                        loger.AddToLogfile("C is pressed");
                        break;
                    //mathOperation и secondNumber остаются нетронутыми
                    case "CE":
                        numberFirst = 0;
                        numberResult = 0;
                        mathExpressionLabel.Text = "";
                        numberLabel.Text = "0";
                        isFirstNumberPlaced = false;
                        loger.AddToLogfile("CE is pressed");
                        break;
                    case "⌫":
                        if (numberLabel.Text.Trim('-').Length == 1)
                            numberLabel.Text = "0";
                        else
                            numberLabel.Text = numberLabel.Text.Remove(numberLabel.Text.Length - 1);
                        doesNumberLabelNeedToBeClear = false;
                        break;
                    //СЧЕТ
                    case "=":
                        switch (mathOperator)
                        {
                            case "":
                                mathOperator = "=";
                                numberFirst = Convert.ToDouble(numberLabel.Text);
                                mathExpressionLabel.Text = numberFirst + " =";
                                numberResult = numberFirst;
                                numberLabel.Text = numberResult.ToString();
                                doesNumberLabelNeedToBeClear = true;
                                break;
                            case "=":
                                numberFirst = Convert.ToDouble(numberLabel.Text);
                                mathExpressionLabel.Text = numberFirst + " =";
                                numberResult = numberFirst;
                                numberLabel.Text = numberResult.ToString();
                                doesNumberLabelNeedToBeClear = true;
                                break;
                            case "+":
                                if (!doesNumberLabelNeedToBeClear)
                                    numberSecond = Convert.ToDouble(numberLabel.Text);
                                mathExpressionLabel.Text = numberFirst + " + " + numberSecond + " =";
                                numberResult = numberFirst + numberSecond;
                                numberLabel.Text = numberResult.ToString();
                                numberFirst = numberResult;
                                doesNumberLabelNeedToBeClear = true;
                                break;
                            case "-":
                                if (!doesNumberLabelNeedToBeClear)
                                    numberSecond = Convert.ToDouble(numberLabel.Text);
                                mathExpressionLabel.Text = numberFirst + " - " + numberSecond + " =";
                                numberResult = numberFirst - numberSecond;
                                numberLabel.Text = numberResult.ToString();
                                numberFirst = numberResult;
                                doesNumberLabelNeedToBeClear = true;
                                break;
                            case "×":
                                if (!doesNumberLabelNeedToBeClear)
                                    numberSecond = Convert.ToDouble(numberLabel.Text);
                                mathExpressionLabel.Text = numberFirst + " × " + numberSecond + " =";
                                numberResult = numberFirst * numberSecond;
                                numberLabel.Text = numberResult.ToString();
                                numberFirst = numberResult;
                                doesNumberLabelNeedToBeClear = true;
                                break;
                            case "÷":
                                if (!doesNumberLabelNeedToBeClear)
                                    numberSecond = Convert.ToDouble(numberLabel.Text);
                                mathExpressionLabel.Text = numberFirst + " ÷ " + numberSecond + " =";
                                if (Math.Abs(0.0 - numberSecond) < 0.001)
                                {
                                    numberLabel.Text = "Ошибка. На ноль делить нельзя";
                                }
                                else
                                {
                                    numberResult = numberFirst / numberSecond;
                                    numberFirst = numberResult;
                                    numberLabel.Text = numberResult.ToString();
                                }
                                doesNumberLabelNeedToBeClear = true;
                                break;

                        }
                        journal.Update(mathExpressionLabel.Text, numberLabel.Text);
                        loger.AddToLogfile(mathExpressionLabel.Text + " " + numberLabel.Text);
                        break;
                    case "+":
                        if (!isFirstNumberPlaced || mathOperator != "+")
                        {
                            numberFirst = Convert.ToDouble(numberLabel.Text);
                            numberSecond = numberFirst;
                            mathExpressionLabel.Text = numberFirst + " + ";
                            isFirstNumberPlaced = true;
                            mathOperator = "+";
                            doesNumberLabelNeedToBeClear = true;
                        }
                        break;
                    case "-":
                        if (!isFirstNumberPlaced || mathOperator != "-")
                        {
                            numberFirst = Convert.ToDouble(numberLabel.Text);
                            numberSecond = numberFirst;
                            mathExpressionLabel.Text = numberFirst + " - ";
                            isFirstNumberPlaced = true;
                            mathOperator = "-";
                            doesNumberLabelNeedToBeClear = true;
                        }
                        break;
                    case "×":
                        if (!isFirstNumberPlaced || mathOperator != "×")
                        {
                            numberFirst = Convert.ToDouble(numberLabel.Text);
                            numberSecond = numberFirst;
                            mathExpressionLabel.Text = numberFirst + " × ";
                            isFirstNumberPlaced = true;
                            mathOperator = "×";
                            doesNumberLabelNeedToBeClear = true;
                        }
                        break;
                    case "÷":
                        if (!isFirstNumberPlaced || mathOperator != "÷")
                        {
                            numberFirst = Convert.ToDouble(numberLabel.Text);
                            numberSecond = numberFirst;
                            mathExpressionLabel.Text = numberFirst + " ÷ ";
                            isFirstNumberPlaced = true;
                            mathOperator = "÷";
                            doesNumberLabelNeedToBeClear = true;
                        }
                        break;
                }
                FontResize();
            }
            catch (Exception ex) { }
        }
        private void ClearAfterActions()
        {
            if (doesNumberLabelNeedToBeClear)
            {
                numberLabel.Text = "0";
                doesNumberLabelNeedToBeClear = false;
            }
        }
        private void FontResize()
        {
            if (numberLabel.Text.Length <= 11)
                numberLabel.Font = new Font("Univers Else", 24, FontStyle.Bold);
            else
                numberLabel.Font = new Font("Univers Else", 12, FontStyle.Bold);
        }

    }
}
