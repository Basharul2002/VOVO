using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Voice;


namespace VOVO
{
    public class SMS
    {
        private bool DeliverTicketPasswordBySMS(string CustomerPhoneNumber, string password)
        {
            MessageBox.Show("accountSid, authToken, fromNumber repectfully replace  by your Twilio accountSid, authToken and number, also remove return keyword class name is SMS and function name is DeliverTicketPasswordBySMS");
            return ;
            string accountSid = "";
            string authToken = "";

            TwilioClient.Init(accountSid, authToken);

            string fromNumber = "+"; // My number (Twilio number)
            string toNumber = CustomerPhoneNumber; // Customer Phone Number
            string message = "Dear Passenger,\n" +
                             "\n" +
                             "Thank you for booking your bus ticket with us.Your e-ticket has been attached as a password-protected PDF to the email address you provided. Please find the PDF attached.\n\nTo open the PDF, you'll need the password. Here is your PDF password: " + password + ". Please keep this password confidential.\n" +
                             "\n For any assistance or inquiries, feel free to contact our customer support at support@aiub.edu.com or +88028414046. Safe travels!\n" +
                             "\n" +
                             "Best regards,\n" +
                             "VOVO";

            var smsMessage = MessageResource.Create
            (
                body: message,
                from: new Twilio.Types.PhoneNumber(fromNumber),
                to: new Twilio.Types.PhoneNumber(toNumber)
            );
            return true;

        }


        private bool DeliverResetPasswordOTPBySMS(string name, string CustomerPhoneNumber, string otp)
        {
            try
            {
               MessageBox.Show("accountSid, authToken, fromNumber repectfully replace  by your Twilio accountSid, authToken and number, also remove return keyword class name is SMS and function name is DeliverTicketPasswordBySMS");
                return ;
                string accountSid = "";
                string authToken = "";
    
                TwilioClient.Init(accountSid, authToken);
    
                string fromNumber = "+"; // My number (Twilio number)
                string toNumber = CustomerPhoneNumber; // Customer Phone Number like this format +8801813890622
                string message = "Dear " + name + ", \n" +
                                 "\n" +
                                 "We have received a password reset request for your VOVO account. Your One-Time Password (OTP) code for resetting your password is: " + otp + ". This code is valid for the next 2 minutes.\n" +
                                 "\n" +
                                 "Please do not share your OTP with others.";

                var smsMessage = MessageResource.Create
                (
                    body: message,
                    from: new Twilio.Types.PhoneNumber(fromNumber),
                    to: new Twilio.Types.PhoneNumber(toNumber)
                );

                return true;
            }

            catch(Exception ex)
            {
                CustomMessageBox.Show(ex.Message);  
                return false;
            }


            
        }

        public bool SendTicketPasswordBySMS(string CustomerPhoneNumber, string password)
        {
            return DeliverTicketPasswordBySMS(CustomerPhoneNumber, password);
        }

        public bool SendResetPasswordOTPBySMS(string name, string CustomerPhoneNumber, string otp)
        {
            return DeliverResetPasswordOTPBySMS(name, CustomerPhoneNumber, otp);
        }

    }
}
