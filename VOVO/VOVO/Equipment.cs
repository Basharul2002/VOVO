using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Text.RegularExpressions;

using ZXing;
using ZXing.Common;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Mail;
using MimeKit;
using System.Net;
using System.Web.Mail;
using System.Globalization;
using iTextSharp.tool.xml;

using PdfiumViewer;
using System.Diagnostics;  // For open PDF using default viewer 

using DinkToPdf;
using System.Management;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Emgu.CV.ML;
using static iText.Kernel.Pdf.Colorspace.PdfDeviceCs;

namespace VOVO
{
    internal class Equipment
    {
        public static bool IsStrongPassword(string password, out string message)
        {
            // Check minimum length
            if (password.Length < 6)
            {
                message = "Length must be more than 6";
                return false;
            }

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
            {
                message = "Use at least one upper case character";
                return false;
            }

            // Check for at least one lowercase letter
            if (!password.Any(char.IsLower))
            {
                message = "Use at least one lower case character";
                return false;
            }

            // Check for at least one digit
            if (!password.Any(char.IsDigit))
            {
                message = "Use at least one digit";
                return false;
            }

            
            // Check for at least one special character
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                message = "Use at least one special character";
                return false;
            }

            // All checks passed, password is strong
            message = null;
            return true;
        }
        private int SerialNo(string type)
        {
            string lastID = string.Empty;
            DataBase dataBase = new DataBase();
            lastID = dataBase.LastID(type);
            int returnValue = 0;


            if (lastID == null)
            {
                returnValue = 0;
            }

            else
            {
                if (lastID == string.Empty)
                {
                    returnValue = 0;
                }

                else if (!string.IsNullOrEmpty(lastID))
                {
                    // Database values
                    int year = ConvertStringToInt(lastID.Substring(4, 2));
                    int month = ConvertStringToInt(lastID.Substring(lastID.Length - 1, 1));

                    // Today value
                    DateTime dateTime = DateTime.Now;
                    int yearNow = (dateTime.Year % 100);
                    int monthNow = ((dateTime.Month) / 5) + 1;

                    // Compare today year and month with database last id year and month
                    if (year != yearNow || month != monthNow)
                    {
                        // MessageBox.Show("Year");
                        returnValue = 0;
                    }

                    else if (year == yearNow || month == monthNow)
                    {
                        if (type != "Customer")
                        {
                            string numberPart = lastID.Substring(6, 4);
                            // MessageBox.Show(numberPart);
                            returnValue = StringToInt(numberPart);
                        }
                        else if (type == "Customer")
                        {
                            string numberPart = lastID.Substring(6, 10);
                            // MessageBox.Show(numberPart);
                            returnValue = StringToInt(numberPart);
                        }

                    }
                }
            }
            // MessageBox.Show(returnValue.ToString());
            return returnValue;
        }

        private string IdGenarator(string type)
        {
            DateTime date = DateTime.Now; // Example date, you can replace it with your desired date

            int year = date.Year;
            int month = (date.Month / 5) + 1;
            int day = date.Day;

            int serialNo = SerialNo(type) + 1;
            string id = string.Empty;

            if (type == "Admin")
            {
                return "ADM-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Driver")
            {
                return "DRI-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Conductor")
            {
                return "CON-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Employee")
            {
                return "EMP-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Company")
            {
                return "COM-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Bus")
            {
                return "Bus-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Customer")
            {
                return "CUS-" + (year % 100) + serialNo.ToString("D10") + "-" + month;
            }

            else if (type == "Supervisor")
            {
                return "SUP-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Route")
            {
                return  "ROU-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            else if (type == "Bus Reporting")
            {
                return "BRP-" + (year % 100) + serialNo.ToString("D7") + "-" + month;
            }

            else if (type == "Ticket")
            {
                return "TIC-" + (year % 100) + serialNo.ToString("D6") + "-" + month;
            }

            else if (type == "Complain")
            {
                return "CMP-" + (year % 100) + serialNo.ToString("D7") + "-" + month;
            }

            else if(type == "Office")
            {
                return "OFF-" + (year % 100) + serialNo.ToString("D4") + "-" + month;
            }

            return string.Empty;
        }


        private bool Qualified(string inputDate, string type)
        {
            bool qualified = false;
            if (DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                DateTime today = DateTime.Today;
                if (date > today)
                {
                    MessageBox.Show("Invalid Date");
                    qualified = false;
                }

                else
                {
                    if (type == "Admin" || type == "Employee")
                    {
                        DateTime adminQualifiedAgeLowest = DateTime.Now.AddYears(-25);
                        DateTime adminQualifiedAgeHighest = DateTime.Now.AddYears(-35);

                        if (adminQualifiedAgeLowest <= date && date >= adminQualifiedAgeHighest)
                        {
                            qualified = true;
                        }

                        else
                        {
                            MessageBox.Show("You are not allowed to apply\nMinimum Age: 25 Years\nMinimum Age: 35 years", "Disqualified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            qualified = false;
                        }
                        
                    }
                    else if (type == "Driver")
                    {
                        DateTime driverQualifiedAgeLowest = DateTime.Now.AddYears(-22);
                        DateTime driverQualifiedAgeHighest = DateTime.Now.AddYears(-40);



                        if (driverQualifiedAgeLowest <= date && date  >= driverQualifiedAgeHighest)
                        {
                            qualified = true;
                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to apply\nMinimum Age: 22 Years\nMinimum Age: 40 years", "Disqualified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            qualified = false;
                        }
                    }
                    else if (type == "Conductor")
                    {
                        DateTime conductorQualifiedAgeLowest = DateTime.Now.AddYears(-20);
                        DateTime conductorQualifiedAgeHighest = DateTime.Now.AddYears(-40);


                        if (date <= conductorQualifiedAgeLowest && date >= conductorQualifiedAgeHighest)
                        {
                            qualified = true;
                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to apply\nMinimum Age: 22 Years\nMinimum Age: 40 years", "Disqualified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            qualified = false;
                        }
                    }

                    else if (type == "Supervisor")
                    {
                        DateTime conductorQualifiedAgeLowest = DateTime.Now.AddYears(-25);
                        DateTime conductorQualifiedAgeHighest = DateTime.Now.AddYears(-30);


                        if (date <= conductorQualifiedAgeLowest && date >= conductorQualifiedAgeHighest)
                        {
                            qualified = true;
                        }
                        else
                        {
                            MessageBox.Show("You are not allowed to apply\nMinimum Age: 25 Years\nMinimum Age: 30 years", "Disqualified", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            qualified = false;
                        }
                    }
                }
            }

            // Add a return statement outside the if-else block
            return qualified;
        }
        private string GenerateCustomPassword(int length, bool includeUpperCase, bool includeLowerCase, bool includeNumbers, bool includeSpecialCharacters)
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "@#$&*";

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            // Create a list of characters based on the specified criteria
            List<string> charCategories = new List<string>();

            if (includeUpperCase)
                charCategories.Add(uppercaseChars);
            if (includeLowerCase)
                charCategories.Add(lowercaseChars);
            if (includeNumbers)
                charCategories.Add(numberChars);
            if (includeSpecialCharacters)
                charCategories.Add(specialChars);

            // Generate the password
            for (int i = 0; i < length; i++)
            {
                // Choose a random character category
                int categoryIndex = random.Next(charCategories.Count);
                string charCategory = charCategories[categoryIndex];

                // Choose a random character from the selected category
                int charIndex = random.Next(charCategory.Length);
                char randomChar = charCategory[charIndex];

                // Append the random character to the password
                password.Append(randomChar);
            }

            return password.ToString();
        }
        private string MaskEmail(string email)
        {
            string[] parts = email.Split('@');
            string username = parts[0];
            string domain = parts[1];

            string maskedUsername;
            // Mask the username
            int usernameLength = username.Length;
            if (usernameLength > 3)
                maskedUsername = username.Substring(0, 2) + new string('x', usernameLength - 2);

            else if (usernameLength == 3)
                maskedUsername = username.Substring(0, 1) + new string('x', usernameLength - 1);

            else
                maskedUsername = username;

            // Mask the domain
            string[] domainPart = domain.Split('.');
            string domainFirstPart = domainPart[0];
            string domainSecondPart = domainPart[1];

            int domainFirstPartLength = domainFirstPart.Length;
            string maskedDomainFirstPart = domain.Substring(0, 1) + new string('x', domainFirstPartLength - 1);

            int domainSecondPartLength = domainSecondPart.Length;
            string maskeddomainSecondPart = new string('x', domainSecondPartLength);


            return maskedUsername + "@" + maskedDomainFirstPart + "." + maskeddomainSecondPart;
        }
        private string MaskPhoneNumber(string phoneNumber)
        {
            int phoneNumberLength = phoneNumber.Length;
            string maskedDigits = new string('*', phoneNumberLength - 2);
            string lastTwoDigits = phoneNumber.Substring(phoneNumberLength - 2);

            return maskedDigits + lastTwoDigits;
        }
        private string PhoneNumberLast(string phoneNumber)
        {
            int phoneNumberLength = phoneNumber.Length;
            string lastTwoDigits = phoneNumber.Substring(phoneNumberLength - 2);

            return lastTwoDigits;
        }
        private double StringToDouble(string value)
        {
            double result = 0;
            try
            {
                 result = double.Parse(value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input format" + ex.Message);
            }

            return result;
        }
        private List<string> GeneratePersonalInfoCombinations(string userName)
        {
            string[] nameParts = userName.Split(' ');

            List<string> personalInfoCombinations = new List<string>();

            // Generate combinations of personal info
            for (int i = 0; i < nameParts.Length; i++)
            {
                for (int j = i; j < nameParts.Length; j++)
                {
                    string combination = string.Join(" ", nameParts.Skip(i).Take(j - i + 1));
                    personalInfoCombinations.Add(combination);
                }
            }

            return personalInfoCombinations;
        }
        private bool StrongPassword(string userName, string password)
        {
            if (password.Length > 8)
            {
                MessageBox.Show("Password length should be at least 8 characters.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[a-z]") || !Regex.IsMatch(password, @"[A-Z]") || !Regex.IsMatch(password, @"\d") || !Regex.IsMatch(password, @"[!@#$%^&*()_\-+=<>?]"))
            {
                MessageBox.Show("Password should include lowercase letters, uppercase letters, digits, and special characters.");
                return false;
            }

            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] && password[i] == password[i + 2])
                {
                    MessageBox.Show("Password Repeated Characters");
                    return false;
                }
            }

            string[] commonWords = { "password", "123456", "qwerty", "abc123" }; // Common words to avoid
            if (commonWords.Any(commonWord => password.Contains(commonWord)))
            {
                MessageBox.Show("Password should not contain common words.");
                return false;
            }

            List<string> personalInfo = GeneratePersonalInfoCombinations(userName);
            if (personalInfo.Any(info => password.ToLower().Contains(info)))
            {
                MessageBox.Show("Password should not contain personal information.");
                return false;
            }

            return true;
        }
        private string GenerateOTP()
        {
            // Define the characters from which the OTP will be generated
            const string chars = "0123456789";

            // Create an instance of Random class
            Random random = new Random();

            // Generate a 6-digit OTP using random characters
            string otp = new string(Enumerable.Repeat(chars, 6)
                                    .Select(s => s[random.Next(s.Length)]).ToArray());

            return otp;
        }
        private string ConvertDataBaseDateFormat(string inputDate)
        {
            bool isValidFormat = DateTime.TryParseExact(inputDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

            if (isValidFormat)
            {
                // The input date is in the correct format, so return the formatted date
                return parsedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                // The input date is not in the correct format, handle the error as needed (e.g., show a message, throw an exception)
                MessageBox.Show("Invalid date format. The date should be in the format 'dd/MM/yyyy'.", "Error");
                return null; // or return the original inputDate, or throw an exception, or return a default value, etc.
            }
        }
        private int ConvertStringToInt(string value)
        {
            try
            {
                int result = Convert.ToInt32(value);
                // Conversion was successful, and 'result' now contains the integer value.
                // You can use the 'result' variable here as needed.
                return result;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Invalied Number Format");
                return -1;
            }
        }

        private string GetTodayDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        // 23/10/2002
        private string ConvertDataBaseFormatDate(string date)
        {
            DateTime parsedDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            return parsedDate.ToString("yyyy-MM-dd");
        }
        
        private string GetTimeNow()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        private string DataBaseFormatTIme(string time)
        {

            // Parse the time string into a DateTime object
            DateTime parsedTime = DateTime.ParseExact(time, "hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            // Format the DateTime object back into the desired format
            return  parsedTime.ToString("HH:mm:ss");
        }

        private string ImageToBase64(System.Drawing.Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        private System.Drawing.Image BarCodeGenerate(string ticketNumber, string passengerName, string boardingPoint, string travelDate, string travelTime, string departureCity, 
            string arrivalCity, string busNumber, string busType, string seatNumber, string fare)
        {
            // Format the data with newlines
            string formattedData = $"Ticket Number   : {ticketNumber}\n" +
                                   $"Passenger Name  : {passengerName}\n" +
                                   $"Boarding Point  : {boardingPoint}\n" +
                                   $"Travel Date     : {travelDate}\n" +
                                   $"Travel Time     : {travelTime}\n" +
                                   $"Departure City  : {departureCity}\n" +
                                   $"Arrival City    : {arrivalCity}\n" +
                                   $"Bus Number      : {busNumber}\n" +
                                   $"Bus Type        : {busType}\n" +
                                   $"Seat Number     : {seatNumber}\n" +
                                   $"Fare            : {fare}";

            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.CODE_128;

            // Set encoding options to handle special characters
            EncodingOptions encodingOptions = new EncodingOptions
            {
                Width = 300, // Set the width of the barcode image
                Height = 50, // Set the height of the barcode image
                Margin = 10 // Set the margin of the barcode image
            };

            barcodeWriter.Options = encodingOptions;

            // Encode the formatted data and generate the barcode bitmap
            Bitmap barcodeBitmap = barcodeWriter.Write(formattedData);

            System.Drawing.Image barcodeImage = barcodeBitmap as System.Drawing.Image;


            return barcodeImage;
        }

        private void pdfSave(byte[] pdf, string fileName)
        {

            // Show a SaveFileDialog to let the user choose where to save the PDF
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                saveFileDialog.FileName = fileName + ".pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, pdf);
                    MessageBox.Show("PDF saved successfully.");
                }
            }
        }

        private string Convert_DateTime_to_Date(string dateTime)
        {
            DateTime date_Time = DateTime.ParseExact(dateTime, "d/M/yyyy h:mm tt", null);
            return date_Time.ToString("d/M/yyyy");
        }


        private void PrintPDF(byte[] pdf)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                using (MemoryStream stream = new MemoryStream(pdf))
                {
                    PdfReader pdfReader = new PdfReader(stream);
                    int totalPages = pdfReader.NumberOfPages;

                    using (FileStream outputStream = new FileStream(printDialog.PrinterSettings.PrinterName, FileMode.Create))
                    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, outputStream))
                    {
                        for (int currentPage = 1; currentPage <= totalPages; currentPage++)
                        {
                            PdfImportedPage page = pdfStamper.GetImportedPage(pdfReader, currentPage);
                            PdfContentByte pdfContentByte = pdfStamper.GetUnderContent(currentPage);

                            iTextSharp.text.Rectangle pageSize = pdfReader.GetPageSizeWithRotation(currentPage);
                            pdfContentByte.AddTemplate(page, 0, 0);

                            if (currentPage < totalPages)
                            {
                                pdfStamper.InsertPage(currentPage + 1, pageSize);
                            }
                        }
                    }
                }
            }
        }

        private void LoadPdf(byte[] pdfData)
        {
            if (pdfData != null)
            {
                string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp.pdf");
                File.WriteAllBytes(tempPdfPath, pdfData);
                Process.Start(tempPdfPath); // Open PDF using default viewer
            }
            else
            {
                MessageBox.Show("No PDF data found in the database.");
            }
        }

        private byte[] PDFUpload()
        {
            byte[] pdfData = null;
            using (OpenFileDialog openFileDialog = new OpenFileDialog(){ Filter = "PDF Document(*.pdf) | *.pdf",ValidateNames = true})
            {
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to upload this pdf file?", "VOVO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                       string fileName = openFileDialog.FileName;
                       pdfData = File.ReadAllBytes(fileName);
                    }
                }
            }
            return pdfData;
        }

        private byte[] ImageToByteArray(System.Drawing.Image image)
        {
            if (image == null)
            {
                return null;
            }

            // Use a try-catch block to handle any potential GDI+ exceptions
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    ImageFormat imageFormat = GetImageFormat(image);
                    if (imageFormat != null)
                    {
                        image.Save(stream, imageFormat); // Save the image with the determined format
                    }
                    else
                    {
                        // If the image format is not recognized, save it as JPEG (or another default format)
                        image.Save(stream, ImageFormat.Jpeg);
                    }
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions related to GDI+ here
                MessageBox.Show("Error in ImageToByteArray: " + ex.Message);
                return null;
            }
        }

        private ImageFormat GetImageFormat(System.Drawing.Image image)
        {
            if (image.RawFormat.Equals(ImageFormat.Jpeg))
            {
                return ImageFormat.Jpeg;
            }
            else if (image.RawFormat.Equals(ImageFormat.Png))
            {
                return ImageFormat.Png;
            }
            else if (image.RawFormat.Equals(ImageFormat.Gif))
            {
                return ImageFormat.Gif;
            }
            else if (image.RawFormat.Equals(ImageFormat.Bmp))
            {
                return ImageFormat.Bmp;
            }
            else if (image.RawFormat.Equals(ImageFormat.Icon))
            {
                return ImageFormat.Icon;
            }
            else
            {
                // Handle other formats or return null if not recognized
                return null;
            }
        }

        private System.Drawing.Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }  


        private System.Drawing.Image ResizePicture(System.Drawing.Image originalImage, int newWidth, int newHeight)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                // Set the interpolation mode to HighQualityBicubic to ensure good quality.
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw the original image onto the new image with the desired size.
                graphics.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }



        public string maskEmail(string email)
        {
            return MaskEmail(email);
        }

        public string maskPhoneNumber(string phoneNumber)
        {
            return MaskPhoneNumber(phoneNumber);
        }

        public string phoneNumberLast(string phoneNumber)
        {
            return PhoneNumberLast(phoneNumber);
        }
        public bool qualified(string inputDate, string type)
        {
            return Qualified(inputDate, type);
        }

        public string idGenarator(string type)
        {
            return IdGenarator(type);
        }

        public string generateCustomPassword(int length, bool includeUpperCase, bool includeLowerCase, bool includeNumbers, bool includeSpecialCharacters)
        {
            return GenerateCustomPassword(length, includeUpperCase, includeLowerCase, includeNumbers, includeSpecialCharacters);
        }

        public double StringToDoubleConverstion(string value)
        {
            return StringToDouble(value);
        }

        public string GetOTP()
        {
            return GenerateOTP();
        }

        public string DataBaseFormatedDate(string date)
        {
            return ConvertDataBaseDateFormat(date);
        }
        
        public bool IsStrongPassword(string userName, string password)
        {
            return StrongPassword(userName, password);
        }

        public int StringToInt(string value)
        {
            return ConvertStringToInt(value);
        }
        public string TodayDate()
        {
            return GetTodayDate();
        }

        public string DataBaseFormatDate(string date)
        {
            return ConvertDataBaseFormatDate(date);
        }

        public string Time()
        {
            return GetTimeNow();  
        }

        public void TicketEmailSend(string email, string PassengerName, string TravelDate, string DepartureCity, string DestinationCity, string DepartureTime, string BusNumber, string SeatNumbers, string CompanyName, System.Drawing.Image barcode)
        {
            //MailSend(email, PassengerName, TravelDate, DepartureCity, DestinationCity, DepartureTime, BusNumber, SeatNumbers, CompanyName, barcode);
        }

        public System.Drawing.Image BarCode(string ticketNumber, string passengerName, string boardingPoint, string travelDate, string travelTime, string departureCity,
            string arrivalCity, string busNumber, string busType, string seatNumber, string fare)
        {
            return BarCodeGenerate(ticketNumber, passengerName, boardingPoint, travelDate, travelTime, departureCity, arrivalCity, busNumber, busType, seatNumber, fare);
        }

        public void pdfDownload(byte[] pdf, string fileName)
        {
            pdfSave(pdf, fileName);
        }
        public string DateTime_to_Date(string dateTime)
        {
            return Convert_DateTime_to_Date(dateTime);
        }

        public void PrintPdf(byte[] pdf)
        {
            PrintPDF(pdf);
        }

        public byte[] PdfUpload()
        {
            return PDFUpload();
        }

        public byte[] ConvertImageToByteArray(System.Drawing.Image image)
        {
            return ImageToByteArray(image);
        }

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            return ByteArrayToImage(byteArray);
        }

        public System.Drawing.Image ResizeImage(System.Drawing.Image originalImage, int newWidth, int newHeight)
        {
            return ResizePicture(originalImage, newWidth, newHeight);

        }


        public bool IsNumeric(string input)
        {
            // Define a regular expression pattern to match numeric digits
            string pattern = "^[0-9]+$";

            // Use Regex.IsMatch to check if the input matches the pattern
            return Regex.IsMatch(input, pattern);
        }


        public bool IsEmail(string input)
        {
            return input.Contains("@");
        }
    }
}

