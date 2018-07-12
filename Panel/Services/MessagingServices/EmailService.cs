﻿using Panel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Panel.Services.MessagingServices
{
    public class EmailService : IEmailService
    {
        public MailAddress FromAddress { get; set; } = new MailAddress("gideonyte@hotmail.com", "Generator Surveillance Notification");
        public List<MailAddress> ToAddresses { get; set; }
        public List<MailAddress> CCAddresses { get; set; }
        public string MessageNotification { get; set; }
        public Tuple<string,string> SubjectAndBody { get; set; }

        public void SendMessage(string GeneratorName, string ReminderLevel, string NotificationTime, 
                    TimeSpan NextNotificationDuration, DateTime FinalNotificationDate, int FirstID, 
                    int LastID, int GeneratorID)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = FromAddress;
                mailMessage.To.Add(new MailAddress("gideonyte@yahoo.com"));
                mailMessage.To.Add(new MailAddress("gideon.sanni@cyphercrescent.com"));
                
                SubjectAndBody = EmailMessage.EmailSubjectAndBody(GeneratorName,
                                                    ReminderLevel, NotificationTime, NextNotificationDuration,
                                                    FinalNotificationDate, FirstID, LastID, GeneratorID);
                mailMessage.Subject = SubjectAndBody.Item1;
                mailMessage.Body = SubjectAndBody.Item2;
                mailMessage.IsBodyHtml = true;

                smtpClient.Port = 587;
                smtpClient.Host = "smtp.live.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("gideonyte@hotmail.com", "KazakhSTan#1");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error {ex.Message}");
            }
        }
    }
}
