using System;
using System.Net;
using System.Net.Mail;

namespace Hiywin.Email
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TestSend();

            Console.Read();
        }

        static void TestSend()
        {
            #region MyRegion
            //string mailFrom = "654436189@qq.com";
            //string mailTo = "270659185@qq.com";
            //string mailSubject = "C#邮件测试";
            //string mailBody = "C#邮件测试成功！！！";
            //if(SendEmail(mailFrom, mailTo, mailSubject, mailBody))
            //{
            //    Console.WriteLine("发送成功！");
            //}
            //else
            //{
            //    Console.WriteLine("发送失败！");
            //}
            #endregion

            MailModel model = new MailModel();
            model.ReceiverAddress = "654436189@qq.com";
            model.ReceiverName = "..海";
            model.Title = "C#邮件测试";
            model.Content = "C#邮件测试成功！！！";
            model.SenderAddress = @"270659185@qq.com";
            model.SenderName = "Chief乄涯";
            model.SenderPassword = "***";

            if (SendMail(model))
            {
                Console.WriteLine("发送成功！");
            }
            else
            {
                Console.WriteLine("发送失败！");
            }
        }

        public static bool SendMail(MailModel model)
        {
            try
            {
                MailAddress receiver = new MailAddress(model.ReceiverAddress, model.ReceiverName);
                MailAddress sender = new MailAddress(model.SenderAddress, model.SenderName);
                MailMessage message = new MailMessage();
                message.From = sender;//发件人
                message.To.Add(receiver);//收件人
                //message.CC.Add(sender);//抄送人
                message.Subject = model.Title;//标题
                message.Body = model.Content;//内容
                message.IsBodyHtml = true;//是否支持内容为HTML

                SmtpClient client = new SmtpClient();
                client.Host = "smtp.exmail.qq.com";
                //client.Port = 465;
                client.EnableSsl = true;//是否启用SSL
                client.Timeout = 10000;//超时
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential(model.SenderAddress, model.SenderPassword);
                client.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //static bool SendEmail(string mailFrom,string mailTo,string mailSubject,string mailBody, string host)
        //{
        //    try
        //    {
        //        System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(mailFrom);   //邮件发送人地址
        //        System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(mailTo);       //接收人地址
        //        System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage(from, to);    //邮件对象
        //        message.Subject = mailSubject;
        //        message.Body = mailBody;

        //        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();             //设置服务器
        //        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        smtp.Host = host;       //邮件服务器
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Send(message);     //发送邮件
        //        message.Dispose();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return false;
        //}
    }

    public struct MailModel
    {
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string ReceiverAddress { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string ReceiverName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 发件人地址（非必填）
        /// </summary>
        public string SenderAddress { get; set; }
        /// <summary>
        /// 发件人姓名（非必填）
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// 发件人密码（非必填）
        /// </summary>
        public string SenderPassword { get; set; }
    }
}
