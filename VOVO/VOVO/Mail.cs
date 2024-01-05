using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Drawing;
using ZXing.Common;
using ZXing;
using iTextSharp.tool.xml.html.head;
using iTextSharp.tool.xml.html;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Security.Principal;
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QRCoder;
using System.Windows.Controls;

namespace VOVO
{
    internal class Mail
    {

        public void Info()
        {
            string imagePath = "D:\\University\\C# Coe\\Project - Copy (3) - CopyEsdiit\\Pic\\Icon.png";
            System.Drawing.Image logo = System.Drawing.Image.FromFile(imagePath);

            string companyName = "VOVO", busNumber = "123", busTypeTime = "Dobule Decker (12:00:00)", date = "22 JANUARY 2023", passengerName = "Basharul Alam", from = "Dhaka", to = "Feni", boardingPoint = "Dhaka", seatNumber = "A1, A2";
            string ticketNumber = "23", travelDate = "22 JANUARY 2023", travelTime = "12:00:00", departureCity = "Dhaka", arrivalCity = "Chitagong",
             busType = "Double Decker", fare = "3600", email = "basharulalammicrosoft@gmail.com",
            passengerPasword = "123", destinationCity = "Dhaka", departureTime = "12:00:00";
            string passengerEmail = "basharulalammicrosoft@gmail.com";

            System.Drawing.Image Barcode = QrCodeGenerate(ticketNumber, passengerName, boardingPoint, travelDate, travelTime, departureCity,
           arrivalCity, busNumber, busType, seatNumber, fare);
          /*
            System.Drawing.Image qrcode = QrCodeGenerate(ticketNumber, passengerName, boardingPoint, travelDate, travelTime, departureCity,
          arrivalCity, busNumber, busType, seatNumber, fare);
          */
            //return qrcode;
            PDFGenerate pdf = new PDFGenerate();
          
          byte[] pdfbyte = pdf.GenerateBusTicketPDF(companyName, busNumber, busTypeTime, date, passengerName, from, to, boardingPoint, seatNumber, Barcode, "123");
            //SendBusTicketByEmail(pdfbyte, passengerEmail, passengerName, date, from, to, departureTime, busNumber, seatNumber);
         Equipment equipment = new Equipment();
            equipment.pdfDownload(pdfbyte, "Demo");
        }


        private bool DeliverBusTicketByEmail(byte[] pdf, string passengerEmail, string PassengerName, string TravelDate, string DepartureCity, string DestinationCity, string DepartureTime, string BusNumber, string SeatNumbers)
        {
            // Replace with the actual values
            string recipientEmail = passengerEmail; // Replace with the recipient's email address

            // Email settings
            string senderEmail = "basharulalamm@gmail.com"; // Replace with your sender email address
            string senderPassword = "xvoawtmtomxzuqio"; // Replace with your sender email password

            string subject = "Ticket - VOVO";

            // Create the HTML-formatted email body
            string body = $@"
                            <html>
                            <html lang='en'>
                    <body>
                        Dear " + PassengerName + @",
                          We are excited to provide you with your bus ticket for your upcoming journey on " + TravelDate + @". Your ticket details are as follows:
                          <ul>
                            <li>Departure City: " + DepartureCity + @"</li>
                            <li>Destination City: " + DestinationCity + @"</li>
                            <li>Departure Time: " + DepartureTime + @"</li>
                            <li>Bus Number: " + BusNumber + @"</li>
                            <li>Seat Number(s): " + SeatNumbers + @"</li>
                          </ul>
                            For your security and privacy, the attached PDF is password protected. 
                            The password to access this file has been sent to you separately via SMS on your registered mobile number. Please enter it exactly as it appears 
                            in the SMS when prompted, to access your ticket information.
                       
                          Here are a few important reminders for your journey:
                          <ul>
                            <li>Arrive at the departure point at least 30 minutes before the scheduled departure time.</li>
                            <li>Adhere to any safety guidelines provided by the bus operator.</li>
                          </ul>
                            Should you face any difficulty in opening the file or in case the password does not reach you, please inform us without delay, and rest assured we will provide 
                            immediate support. Additionally, should you have any questions, need to make amendments to your booking, or require any assistance, we invite you to 
                            connect freely with our customer support team at <a href='mailto:support@aiub.edu.com'> support@aiub.edu.com </a> or <a href='tel:+88028414046'>+88 02 841 4046-9</a>. Our dedicated team is always ready to help you with your 
                            queries, and ensure you have a seamless and pleasant travel experience with us.
                            Please do not hesitate to get in touch if you need further assistance.

                         Your trust in our service means a lot to us, and we're thrilled to have you on board. Here’s wishing you a happy and safe journey – may all aspects of your 
                        trip unfold smoothly for a rewarding travel experience. 
                        Best regards,<br>VOVO Bus Services
                    </body>
                    </html>";

            try
            {
                using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Set this property to true

                    // Convert the PDF byte array to a MemoryStream
                    MemoryStream pdfStream = new MemoryStream(pdf);

                    // Attach the password-protected PDF to the email
                    mail.Attachments.Add(new Attachment(pdfStream, "BusTicket.pdf", "application/pdf"));


                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }

                CustomMessageBox.Show("Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error sending email: " + ex.Message);
            }
            return false;
        }

        private bool DeliverResetPasswordOTPByMail(string passengerName, string passengerEmail, string otp)
        {
            string recipientEmail = passengerEmail; // Replace with the recipient's email address

            // Email settings
            string senderEmail = "basharulalamm@gmail.com"; // Replace with your sender email address
            string senderPassword = "xvoawtmtomxzuqio"; // Replace with your sender email password

            string subject = "Password Reset OTP Code - VOVO";
            string body = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                              <meta charset='UTF-8'>
                              <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                              <title>Bus Ticket Email</title>
                               <style>
                            body 
                            {
                                font-family: Arial, sans-serif;
                            }
                            .email-content 
                            {
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 20px;
                                border: 1px solid #ccc;
                                background-color: #f4f4f4;
                            }
                            .email-heading 
                            {
                              font-size: 24px;
                              font-weight: bold;
                              margin-bottom: 20px;
                            }
                        .email-text {
                          font-size: 16px;
                          line-height: 1.5;
                          margin-bottom: 20px;
                        }
                        .email-list {
                          margin-left: 20px;
                        }
                        .email-list li {
                          list-style-type: disc;
                          margin-bottom: 10px;
                        }
                        .email-footer {
                          font-size: 14px;
                          margin-top: 20px;
                        }
                      </style>
                            </head>
                            <body>
                              <div class='email-content'>
                                <div class='email-heading'>Dear " + passengerName + @",</div>
                                <div class='email-text'>
                                    We have received a request to reset your password for your [Your Website/App Name] account. To proceed with the password reset, please use the following One-Time Password (OTP) code within the next 2 minutes:                                  <br><br>
                                  OTP Code: " + otp + @"
                                  <br><br>
                                  Please enter this OTP code on the password reset page to complete the process. If you didn't request this password reset or if you believe this is a mistake, please ignore this email and take necessary actions to secure your account.
                                  <br><br>
                                  Please note that this OTP is valid for a limited time and for a single use only. Keep this OTP confidential and do not share it with anyone.
                                </div>
                                <div class='email-footer'>
                                  If you need further assistance or have any questions, feel free to contact our support team at <a href='mailto:support@aiub.edu.com'> support@aiub.edu.com </a> or <a href='tel:+88028414046'>+88 02 841 4046-9</a>.
                                  <br><br>
                                  Thank you for using [Platform/Service Name].
                                  <br>
                                  <div class='email-footer'>Best regards,<br>VOVO Bus Services</div>
                                </div>
                              </div>
                            </body>
                            </html>";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Set this property to true

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }

                CustomMessageBox.Show("Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error sending email: " + ex.Message);
            }

            return false;


        }

        private bool VerifyEmail(string name, string recipientEmail, string otp)
        {

            // Email settings
            string senderEmail = "basharulalamm@gmail.com"; // Replace with your sender email address
            string senderPassword = "xvoawtmtomxzuqio"; // Replace with your sender email password

            string subject = "Verify Email OTP Code - VOVO";
            string body = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                              <meta charset='UTF-8'>
                              <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                              <title>Bus Ticket Email</title>
                               <style>
                            body 
                            {
                                font-family: Arial, sans-serif;
                            }
                            .email-content 
                            {
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 20px;
                                border: 1px solid #ccc;
                                background-color: #f4f4f4;
                            }
                            .email-heading 
                            {
                              font-size: 24px;
                              font-weight: bold;
                              margin-bottom: 20px;
                            }
                        .email-text {
                          font-size: 16px;
                          line-height: 1.5;
                          margin-bottom: 20px;
                        }
                        .email-list {
                          margin-left: 20px;
                        }
                        .email-list li {
                          list-style-type: disc;
                          margin-bottom: 10px;
                        }
                        .email-footer {
                          font-size: 14px;
                          margin-top: 20px;
                        }
                      </style>
                            </head>
                            <body>
                              <div class='email-content'>
                                <div class='email-heading'>Hi " + name + @",</div>
                                <div class='email-text'>
                                    You recently added <a href='mailto:" + recipientEmail + "'>" + recipientEmail + @"</a> to your VOVO account.
                                    <br>
                                    <br>
                                    Please confirm this email address so that we can update your contact information.
                                    <br>
                                    <br>
                                    You may be asked to enter this confirmation code: " + otp +@".
                                </div>
                                <div class='email-footer'>
                                    If you need further assistance or have any questions, feel free to contact our support team at <a href='mailto:support@aiub.edu.com'> support@aiub.edu.com </a> or <a href='tel:+88028414046'>+88 02 841 4046-9</a>.
                                    <br>
                                    <br>
                                    Thank you for using [VOVO].
                                    <br>
                                    <div class='email-footer'>
                                        Best regards,
                                        <br>
                                        VOVO Bus Services
                                    </div>
                                </div>
                              </div>
                            </body>
                            </html>";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Set this property to true

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }

                CustomMessageBox.Show("Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error sending email: " + ex.Message);
            }

            return false;

        }
      
        
        public bool SendBusTicketByEmail(byte[] pdf, string passengerEmail, string PassengerName, string TravelDate, string DepartureCity, string DestinationCity, string DepartureTime, string BusNumber, string SeatNumbers)
        {
            return DeliverBusTicketByEmail(pdf, passengerEmail, PassengerName, TravelDate, DepartureCity, DestinationCity, DepartureTime, BusNumber, SeatNumbers);
        }

        public bool EmailVerify(string name, string email, string otp)
        {
            return VerifyEmail(name, email, otp);
        }

        private bool SendEmailInOldEmail(string name, string email, string otp)
        {
            // Email settings
            string senderEmail = "basharulalamm@gmail.com"; // Replace with your sender email address
            string senderPassword = "xvoawtmtomxzuqio"; // Replace with your sender email password

            string subject = "Update Email Address - VOVO";
            string body = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                              <meta charset='UTF-8'>
                              <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                              <title>Bus Ticket Email</title>
                               <style>
                            body 
                            {
                                font-family: Arial, sans-serif;
                            }
                            .email-content 
                            {
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 20px;
                                border: 1px solid #ccc;
                                background-color: #f4f4f4;
                            }
                            .email-heading 
                            {
                              font-size: 24px;
                              font-weight: bold;
                              margin-bottom: 20px;
                            }
                        .email-text {
                          font-size: 16px;
                          line-height: 1.5;
                          margin-bottom: 20px;
                        }
                        .email-list {
                          margin-left: 20px;
                        }
                        .email-list li {
                          list-style-type: disc;
                          margin-bottom: 10px;
                        }
                        .email-footer {
                          font-size: 14px;
                          margin-top: 20px;
                        }
                      </style>
                            </head>
                            <body>
                              <div class='email-content'>
                                <div class='email-heading'>Hi " + name + @",</div>
                                <div class='email-text'>
                                    We have received a request to update your email address.
                                    <br>
                                    <br>
                                    If you did not request this registration, please contact our support team at <a href='mailto:support@aiub.edu.com'> support@aiub.edu.com </a> or <a href='tel:+88028414046'>+88 02 841 4046-9</a>.
                                  </div>
                                <div class='email-footer'>
                                  If you need further assistance or have any questions, feel free to contact our support team at <a href='mailto:support@aiub.edu.com'> support@aiub.edu.com </a> or <a href='tel:+88028414046'>+88 02 841 4046-9</a>.
                                  <br><br>
                                  Thank you for using VOVO.
                                  <br>
                                  <div class='email-footer'>
                                    Best regards,
                                    <br>
                                    VOVO Bus Services
                                  </div>
                                </div>
                              </div>
                            </body>
                            </html>";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(email);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Set this property to true

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }

                CustomMessageBox.Show("Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error sending email: " + ex.Message);
            }

            return false;
        }

        private bool SendEmailInNewEmail(string name, string email, string otp)
        {
            string recipientEmail = email; // Replace with the recipient's email address

            // Email settings
            string senderEmail = "basharulalamm@gmail.com"; // Replace with your sender email address
            string senderPassword = "xvoawtmtomxzuqio"; // Replace with your sender email password

            string subject = "Update Email Address - VOVO";
            string body = @"<!DOCTYPE html>
                            <html lang='en'>
                            <head>
                              <meta charset='UTF-8'>
                              <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                              <title>Bus Ticket Email</title>
                               <style>
                            body 
                            {
                                font-family: Arial, sans-serif;
                            }
                            .email-content 
                            {
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 20px;
                                border: 1px solid #ccc;
                                background-color: #f4f4f4;
                            }
                            .email-heading 
                            {
                              font-size: 24px;
                              font-weight: bold;
                              margin-bottom: 20px;
                            }
                        .email-text {
                          font-size: 16px;
                          line-height: 1.5;
                          margin-bottom: 20px;
                        }
                        .email-list {
                          margin-left: 20px;
                        }
                        .email-list li {
                          list-style-type: disc;
                          margin-bottom: 10px;
                        }
                        .email-footer {
                          font-size: 14px;
                          margin-top: 20px;
                        }
                      </style>
                            </head>
                            <body>
                              <div class='email-content'>
                                <div class='email-heading'>Hi " + name + @",</div>
                                <div class='email-text'>
                                    We have received a request to update your email address. 
                                    Confirmation Code: " + otp + @"
                                    <br>
                                    <br>
                                    Please enter this code on our website to verify your email address. If you did not request this registration, please disregard this email.
                                </div>
                                <div class='email-footer'>
                                  If you need further assistance or have any questions, feel free to contact our support team at <a href='mailto:support@aiub.edu.com'> support@aiub.edu.com </a> or <a href='tel:+88028414046'>+88 02 841 4046-9</a>.
                                  <br><br>
                                  Thank you for using VOVO.
                                  <br>
                                  <div class='email-footer'>
                                    Best regards,
                                    <br>
                                    VOVO Bus Services
                                  </div>
                                </div>
                              </div>
                            </body>
                            </html>";
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(senderEmail);
                    mail.To.Add(recipientEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true; // Set this property to true

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.Port = 587;
                        smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                        smtp.EnableSsl = true;

                        smtp.Send(mail);
                    }
                }

                CustomMessageBox.Show("Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show("Error sending email: " + ex.Message);
            }

            return false;
        }


        private bool NewEmailVerification(string name, string oldEmail, string newEmail, string otp)
        {
            bool _return = SendEmailInOldEmail(name, oldEmail, otp);
            _return = SendEmailInNewEmail(name, newEmail, otp);

            return _return;
        }


        public bool NewEmailVerify(string name, string oldEmail, string newEmail, string otp)
        {
            return NewEmailVerification(name, oldEmail, newEmail, otp);       
        }


        public bool SendResetPasswordOTPByMail(string passengerName, string passengerEmail, string otp)
        {
            return DeliverResetPasswordOTPByMail(passengerName, passengerEmail, otp);
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
                Width = 400, // Set the width of the barcode image
                Height = 300, // Set the height of the barcode image
                Margin = 2 // Set the margin of the barcode image
            };

            barcodeWriter.Options = encodingOptions;

            // Encode the formatted data and generate the barcode bitmap
            Bitmap barcodeBitmap = barcodeWriter.Write(formattedData);

            System.Drawing.Image barcodeImage = barcodeBitmap as System.Drawing.Image;


            return barcodeImage;
        }

        private System.Drawing.Image QrCodeGenerate(string ticketNumber, string passengerName, string boardingPoint, string travelDate, string travelTime, string departureCity,
     string arrivalCity, string busNumber, string busType, string seatNumber, string fare)
        {
            // Format the data with newlines
            string formattedData =  $"Ticket Number  : {ticketNumber}\n" +
                                    $"Passenger Name : {passengerName}\n" +
                                    $"Boarding Point : {boardingPoint}\n" +
                                    $"Travel Date    : {travelDate}\n" +
                                    $"Travel Time    : {travelTime}\n" +
                                    $"Departure City : {departureCity}\n" +
                                    $"Arrival City   : {arrivalCity}\n" +
                                    $"Bus Number     : {busNumber}\n" +
                                    $"Bus Type       : {busType}\n" +
                                    $"Seat Number    : {seatNumber}\n" +
                                    $"Fare           : {fare}";

            // Create a QR Code writer
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;

            // Set QR Code encoding options
            ZXing.QrCode.QrCodeEncodingOptions options = new ZXing.QrCode.QrCodeEncodingOptions
            {
                Width = 200,
                Height = 200,
                Margin = 0,
                DisableECI = true // Disable extended channel interpretation (ECI)
            };

            barcodeWriter.Options = options;

            // Encode the formatted data and generate the QR Code bitmap
            Bitmap qrCodeBitmap = barcodeWriter.Write(formattedData);

            // You can customize the colors here, e.g., make the background white and the QR code data black.
            // Here's an example:
            for (int x = 0; x < qrCodeBitmap.Width; x++)
            {
                for (int y = 0; y < qrCodeBitmap.Height; y++)
                {
                    if (qrCodeBitmap.GetPixel(x, y).R < 128)
                    {
                        qrCodeBitmap.SetPixel(x, y, Color.Coral);
                    }
                    else
                    {
                        qrCodeBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }

            return qrCodeBitmap;
        }


    }
}
