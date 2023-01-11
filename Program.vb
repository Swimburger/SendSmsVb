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

        TwilioClient.Init(twilioAccountSid, twilioAuthToken)
        MessageResource.Create(
            from := New PhoneNumber("[YOUR_TWILIO_PHONE_NUMBER]"),
            to := New PhoneNumber("[YOUR_PERSONAL_PHONE_NUMBER]"),
            body := "Ahoy!"
        )
    End Sub
End Module
