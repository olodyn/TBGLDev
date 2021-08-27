using System;

namespace Exercise01
{
    public class ExtensionMethod
    {

        public static String ToOnes(String number)
        {
            int _number = Convert.ToInt32(number);
            String name = "";
            switch (_number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }


        public static String ConvertToDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ToOnes(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }


        public static String ConvertToWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");

                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        case 1://ones' range

                            word = ToOnes(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = ToTens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        case 13://Trillions's range
                        case 14:
                        case 15:

                            pos = (numDigits % 13) + 1;
                            place = " Trillion ";
                            break;
                        case 16://Quadrillions's range
                        case 17:
                        case 18:

                            pos = (numDigits % 16) + 1;
                            place = " Quadrillion ";
                            break;
                        case 19://Quintrillions's range
                        case 20:
                        case 21:

                            pos = (numDigits % 19) + 1;
                            place = " Quintrillion ";
                            break;
                        case 22://Sextillions's range
                        case 23:
                        case 24:

                            pos = (numDigits % 22) + 1;
                            place = " Sextillion ";
                            break;
                        //add extra case options for anything above Sextillion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        if (number.Substring(0, pos) != "0" && number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertToWholeNumber(number.Substring(0, pos)) + place + ConvertToWholeNumber(number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertToWholeNumber(number.Substring(0, pos)) + ConvertToWholeNumber(number.Substring(pos));
                        }

                        //check for trailing zeros
                        //if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        public static String ToTens(String number)
        {
            int _number = Convert.ToInt32(number);
            String name = null;
            switch (_number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_number > 0)
                    {
                        name = ToTens(number.Substring(0, 1) + "0") + " " + ToOnes(number.Substring(1));
                    }
                    break;
            }
            return name;
        }


        public static string Towards(String number)
        {
            String val = "", wholeNo = number, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = number.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = number.Substring(0, decimalPlace);
                    points = number.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents  
                        endStr = "Paisa " + endStr;//Cents  
                        pointStr = ConvertToDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertToWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
    }
}
