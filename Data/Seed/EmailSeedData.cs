using UmbrellaCorpHRSystem.Models.Entities.Email;

namespace UmbrellaCorpHRSystem.Data.Seed
{
    public static class EmailSeedData
    {
        private const string UmbrellaAutomatedSystemEmail = "automated@umbrellacorp.com";
        private const string AlbertWeskerEmail = "albertwesker@umbrellacorp.com";
        private const string ClaireRedfieldEmail = "claireredfield@umbrellacorp.com";
        private const string JamesMarcusEmail = "jamesmarcus@umbrellacorp.com";

        public static EmailThread[] Threads =>
        [
            new EmailThread
            {
                Id = 1,
                IsRead = false,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = AlbertWeskerEmail,
            },
            new EmailThread
            {
                Id = 2,
                IsRead = false,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = JamesMarcusEmail,
            },
            new EmailThread
            {
                Id = 3,
                IsRead = false,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = UmbrellaAutomatedSystemEmail,
            }
        ];

        public static EmailMessage[] Messages =>
        [
            new EmailMessage
            {
                Id = 1,
                EmailThreadId = 1,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = AlbertWeskerEmail,
                Subject = "Welcome Claire a few favors please",
                Body = """
                    Hello Claire,
                    Welcome to Umbrella corp.

                    I am aware that you are yet to have your onboarding session with Marcus, but I would like to ask you to deal with some urgent tasks in the meantime. They will take you 7 minutes, if you can spare them:

                    - Please increase Arthur Pendleton's salary to 112,000
                    - Kindly terminate Frank Hughes's contract 
                    - Inform Mei Lin that she may not make any more Amazon orders directly to the facillity
                    - Finally, throw a pizza party through the office control panel to reward our employees for their most recent discovery

                    Best regards,
                    A. Wesker
                    """,
                SentDate = new DateTime(2025, 6, 6, 14, 19, 35),
            },
            new EmailMessage
            {
                Id = 2,
                EmailThreadId = 2,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = JamesMarcusEmail,
                Subject = "Welcome to Umbrella Corp",
                Body = """
                    Hi Claire,
                    Let's have a meeting at 3 PM today to discuss your onboarding process.
                    Best regards,
                    J. Marcus
                    """,
                SentDate = new DateTime(2025, 6, 6, 11, 34, 05),
            },
            new EmailMessage
            {
                Id = 3,
                EmailThreadId = 2,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = JamesMarcusEmail,
                Subject = "Re: Welcome to Umbrella Corp",
                Body = """
                    Sorry, forgot to mention that the meeting will be held in the conference room on the 2nd floor.
                    J. Marcus
                    """,
                SentDate = new DateTime(2025, 6, 6, 11, 36, 54),
            },
            new EmailMessage
            {
                Id = 4,
                EmailThreadId = 3,
                RecipientEmail = ClaireRedfieldEmail,
                SenderEmail = UmbrellaAutomatedSystemEmail,
                Subject = "Welcome to Umbrella Corp HR System",
                Body = """
                    Dear Employee,

                    Your access to the office has been granted. Please use your employee ID to enter the building.
                    Do Not Reply to this email. This is an automated message from the Umbrella Corp HR System.

                    Have a wonderful day,
                    Umbrella Automated Email System
                    """,
                SentDate = new DateTime(2025, 6, 5, 23, 59, 59),
            },
        ];
    }
}
