using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UPPERIOC.UPPER.IOC.Center.IProvider;

namespace UPPERIOC2.UPPER.EmailErrorSender.Sender
{

	public class EmailSender
	{
		public static EmailSender instance;
		public IContainerProvider ipd;
		public EmailSender(IContainerProvider ipd) {
			this.ipd = ipd;
		}
		public  void SendEmail(Exception x)
		{
			try
			{
				var cf = ipd.GetAllInstance<IErrorConfiguation>();
				var cf1 = cf[0];
				// 创建邮件消息  
				MailMessage mail = new MailMessage();
				mail.From = new MailAddress(cf1.SenderEmail); // 替换为你的发件人邮箱  
				mail.To.Add(cf1.ReceiveEmail);
				mail.Subject = "your Application Error:"+x.GetType().Name; // 邮件主题  
				mail.Body = x.Message + ""+x.StackTrace; // 邮件正文  
				while (x.InnerException != null)
				{
					x = x.InnerException;
					mail.Body += "InnerException:" + x.Message + "" + x.StackTrace; // 邮件正文  

				}
				mail.IsBodyHtml = true; // 如果邮件正文是HTML格式，则设置为true  

				// SMTP服务器配置  
				SmtpClient smtpServer = new SmtpClient(cf1.SMPTServer); // 替换为你的SMTP服务器地址  
				smtpServer.Port = cf1.SMPTPort; // SMTP服务器端口，QQ邮箱通常使用465（SSL）或587（TLS）  
				smtpServer.UseDefaultCredentials = false;
				smtpServer.Credentials = new NetworkCredential(cf1.SenderUserName, cf1.SenderPWD); // 替换为你的发件人邮箱和密码  
			//	smtpServer.EnableSsl = false; // 如果使用SSL加密，则设置为true  
											 //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
				smtpServer.Timeout = 100000; // 设置超时时间为 10 秒
				System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
				smtpServer.EnableSsl = true; // 在实际发送邮件时启用 SSL
				smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
				// 发送邮件  
				smtpServer.Send(mail);
				Console.WriteLine("Email sent successfully!");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Failed to send email. Error: " + ex.Message);
			}
		}
	}
}
