namespace CalculatorApp.Mobile
{
    public partial class MainPage : ContentPage
    {
        double InsertedNumber = 0; //الرقم الجديد الذي تم ادخال قيمته
        double ResultNumber = 0;   // المجموع النهائي لحاصل العمليات الحسابية
        string SelectedOperation = ""; //اخر عملية اختارها المستخدم

        public MainPage()
        {
            InitializeComponent();
            PrintVars();
            ConvertStringToNumbers();
            //ConvertStringToNumbers();
        }

        //حدث اخذ قيمة الرقم من الزر 
        private void Numbers_Clicked(object sender, EventArgs e)
        {

            var NumberButton = sender as Button;

            if (NumberButton is null)
            {
                return;
            }

            if (LblMoniter.Text == "0" &&
                NumberButton.Text == "0")
            {
                return;
            }
            else if (LblMoniter.Text == "0")
            {
                LblMoniter.Text = NumberButton.Text;
            }
            else
            {
                LblMoniter.Text = LblMoniter.Text + NumberButton.Text;
            }

            //double.TryParse(LblMoniter.Text, out InsertedNumber);
            InsertedNumber = Convert.ToDouble(LblMoniter.Text);

            PrintVars();
        }

        private void BtnPoint_Clicked(object sender, EventArgs e)
        {
            if (LblMoniter.Text.Contains("."))
            {
                return;
            }

            if (LblMoniter.Text == "")
            {
                LblMoniter.Text = "0.";
                return;
            }

            LblMoniter.Text = LblMoniter.Text + ".";

            PrintVars();
        }

        //حدث اخذ نوع العملية الحسابية من الزر 
        private void BtnOperation_Clicked(object sender, EventArgs e)
        {

            if (LblMoniter.Text == "")
            {
                return;
            }

            var OperationButton = sender as Button;

            if (OperationButton is null)
            {
                return;
            }

            // للتـأكيد باننا لدينا عدد في حقل المدخلات
            double.TryParse(LblMoniter.Text, out InsertedNumber);

            LblResult.Text = "";

            LblHistory.Text = LblHistory.Text + " " + LblMoniter.Text + " " + OperationButton.Text;



            if (SelectedOperation == "")
            {
                ResultNumber = Convert.ToDouble(LblMoniter.Text);

                SelectedOperation = OperationButton.Text;

                LblResult.Text = LblMoniter.Text.ToString();

                LblMoniter.Text = "";
                PrintVars();

                return;
            }


            if (SelectedOperation == "+")
            {
                ResultNumber = ResultNumber + InsertedNumber;
            }
            else if (SelectedOperation == "-")
            {
                ResultNumber = ResultNumber - InsertedNumber;
            }
            else if (SelectedOperation == "/")
            {
                ResultNumber = ResultNumber / InsertedNumber;
            }
            else if (SelectedOperation == "*")
            {
                ResultNumber = ResultNumber * InsertedNumber;
            }
            else
            {
                return;
            }

            SelectedOperation = OperationButton.Text;

            LblResult.Text = ResultNumber.ToString();

            LblMoniter.Text = "";

            InsertedNumber = 0;

            PrintVars();
        }

        private void BtnEquel_Clicked(object sender, EventArgs e)
        {
            //للتـأكد من ان اخر رقم واخر عملية تم ادراجها في النتيجة

            if (LblMoniter.Text != "")
            {

                double.TryParse(LblMoniter.Text, out InsertedNumber);

                if (SelectedOperation == "+")
                {
                    ResultNumber = ResultNumber + InsertedNumber;
                }
                else if (SelectedOperation == "-")
                {
                    ResultNumber = ResultNumber - InsertedNumber;
                }
                else if (SelectedOperation == "/")
                {
                    ResultNumber = ResultNumber / InsertedNumber;
                }
                else if (SelectedOperation == "*")
                {
                    ResultNumber = ResultNumber * InsertedNumber;
                }
                else
                {
                    return;
                }
            }

            LblResult.Text = ResultNumber.ToString();

            InsertedNumber = 0;

            ResultNumber = 0;

            LblMoniter.Text = "";

            LblHistory.Text = "";

            SelectedOperation = "";

            PrintVars();
        }

        //حدث لمسح المتغيرات والحقول
        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            InsertedNumber = 0;
            ResultNumber = 0;

            LblMoniter.Text = "";
            LblHistory.Text = "";
            LblResult.Text = "";

            SelectedOperation = "";

            PrintVars();
        }


        public void PrintVars()
        {
            //var result = (PercentNumber / 100) * FinelValue;

            LblVaribuls.Text = $"ResultNumber {ResultNumber} \r\nSelectedOperation: {SelectedOperation}\r\n InsertedNumber:{InsertedNumber}";
        }

        private void BtnBackNumber_Clicked(object sender, EventArgs e)
        {
            LblMoniter.Text = LblMoniter.Text.Substring(0, LblMoniter.Text.Length - 1);
            InsertedNumber = Convert.ToDouble(LblMoniter.Text);
            PrintVars();
        }


        private void ConvertStringToNumbers()
        {
            int IntegareNumber = 1200;
            var a0 = Convert.ToDouble(IntegareNumber);
            var a1 = Convert.ToDouble(IntegareNumber).ToString("#.0000");


            double DoubleNumber = 1200.25;
            var d0 = Convert.ToInt32(DoubleNumber);

            float floatNumber = 1200.75F;
            var floatToInt = Convert.ToInt32(floatNumber);

            decimal decimalNumber = 1200.75M;
            var decimalToInt = Convert.ToInt32(decimalNumber);

            string StringNumber = "2500.754.00";
            var s1 = Convert.ToDouble(StringNumber);

        }


    }

}
