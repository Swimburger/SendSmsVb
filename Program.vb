Imports System
Imports System.Reflection
Imports Microsoft.Extensions.Configuration
Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types

Module Program
    Sub Main(args As String())
        Dim configuration = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).Build
        Dim twilioAccountSid = configuration("Twilio:AccountSid")
        Dim twilioAuthToken = configuration("Twilio:AuthToken")

        Console.WriteLine($"Account SID: {If(String.IsNullOrEmpty(twilioAccountSid), "[NOT CONFIGURED]", twilioAccountSid)}")
        Console.WriteLine($"Twilio Auth Token: {If(String.IsNullOrEmpty(twilioAuthToken), "[NOT CONFIGURED]", "[CONFIGURED]")}")
        
        TwilioClient.Init(twilioAccountSid, twilioAuthToken)
        Dim message = MessageResource.Create(
            from := New PhoneNumber("[YOUR_TWILIO_PHONE_NUMBER]"),
            to := New PhoneNumber("[YOUR_PERSONAL_PHONE_NUMBER]"),
            body := "Ahoy!"
        )

        Console.WriteLine("Message sent")
        Console.WriteLine($"Message SID: {message.Sid}")
    End Sub
End Module
