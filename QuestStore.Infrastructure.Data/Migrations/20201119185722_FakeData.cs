using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestStore.Infrastructure.Data.Migrations
{
    public partial class FakeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artifact",
                columns: new[] { "Id", "Cost", "Description", "Image", "Name", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, 818, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "Fantastic Steel Chair", 2, "Extra" },
                    { 9, 817, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "Generic Cotton Tuna", null, "Extra" },
                    { 8, 965, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "Ergonomic Soft Computer", 10, "Extra" },
                    { 7, 534, "The Football Is Good For Training And Recreational Purposes", null, "Rustic Frozen Ball", null, "Extra" },
                    { 6, 795, "The Football Is Good For Training And Recreational Purposes", null, "Licensed Frozen Pants", null, "Basic" },
                    { 10, 381, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "Generic Fresh Shirt", 4, "Basic" },
                    { 4, 1, "The Football Is Good For Training And Recreational Purposes", null, "Ergonomic Soft Ball", null, "Basic" },
                    { 3, 344, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "Tasty Soft Towels", 7, "Basic" },
                    { 2, 167, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "Generic Soft Towels", null, "Basic" },
                    { 5, 334, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", null, "Licensed Frozen Fish", null, "Extra" }
                });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Virtual even-keeled ability", null, "Daniel - Kuvalis" },
                    { 2, "Exclusive systemic circuit", null, "Collins and Sons" },
                    { 3, "Triple-buffered dedicated hardware", null, "Kuvalis and Sons" }
                });

            migrationBuilder.InsertData(
                table: "Quest",
                columns: new[] { "Id", "Description", "Image", "Name", "Reward", "Type" },
                values: new object[,]
                {
                    { 5, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", null, "Awesome Fresh Tuna", 637, "Basic" },
                    { 10, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, "Fantastic Concrete Gloves", 387, "Extra" },
                    { 9, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", null, "Gorgeous Plastic Gloves", 749, "Basic" },
                    { 8, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "Sleek Frozen Sausages", 542, "Extra" },
                    { 7, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", null, "Intelligent Concrete Towels", 51, "Basic" },
                    { 6, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", null, "Rustic Steel Chips", 98, "Basic" },
                    { 4, "The Football Is Good For Training And Recreational Purposes", null, "Generic Plastic Bacon", 679, "Basic" },
                    { 1, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Handmade Frozen Towels", 508, "Basic" },
                    { 2, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", null, "Intelligent Metal Towels", 271, "Extra" },
                    { 3, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", null, "Tasty Metal Bike", 687, "Extra" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AuthId", "Description", "Email", "Image", "Name", "Role", "Surname", "Coins" },
                values: new object[,]
                {
                    { 8, null, "If we reboot the system, we can get to the SQL system through the mobile SQL system!", "Corey.OConner86@yahoo.com", null, "Corey", "Student", "O'Conner", 741 },
                    { 7, null, "We need to override the optical SMTP card!", "Virginia.Connelly34@hotmail.com", null, "Virginia", "Student", "Connelly", 161 },
                    { 6, null, "The SSL bus is down, index the 1080p bus so we can index the SSL bus!", "William_Harvey70@gmail.com", null, "William", "Student", "Harvey", 215 },
                    { 5, null, "Use the 1080p USB alarm, then you can copy the 1080p alarm!", "Pauline83@gmail.com", null, "Pauline", "Student", "Sanford", 383 },
                    { 4, null, "Use the neural FTP feed, then you can calculate the neural feed!", "Sylvia15@hotmail.com", null, "Sylvia", "Student", "Ward", 18 },
                    { 3, null, "Use the mobile JBOD protocol, then you can transmit the mobile protocol!", "Alan_Thompson@yahoo.com", null, "Alan", "Student", "Thompson", 510 },
                    { 2, null, "The XSS monitor is down, override the 1080p monitor so we can override the XSS monitor!", "Bridget.Hane80@yahoo.com", null, "Bridget", "Student", "Hane", 7 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AuthId", "Description", "Email", "Image", "Name", "Role", "Surname" },
                values: new object[,]
                {
                    { 11, null, "Use the solid state ADP matrix, then you can parse the solid state matrix!", "Marcus_Hermiston@yahoo.com", null, "Marcus", "Mentor", "Hermiston" },
                    { 12, null, "The PCI program is down, transmit the multi-byte program so we can transmit the PCI program!", "Javier.Armstrong@yahoo.com", null, "Javier", "Mentor", "Armstrong" },
                    { 13, null, "backing up the panel won't do anything, we need to generate the open-source CSS panel!", "Jackie_Cruickshank@gmail.com", null, "Jackie", "Mentor", "Cruickshank" },
                    { 14, null, "I'll parse the primary USB interface, that should interface the USB interface!", "Oliver.Koss@hotmail.com", null, "Oliver", "Mentor", "Koss" },
                    { 15, null, "The PNG feed is down, input the back-end feed so we can input the PNG feed!", "Noah_Schroeder@gmail.com", null, "Noah", "Mentor", "Schroeder" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AuthId", "Description", "Email", "Image", "Name", "Role", "Surname", "Coins" },
                values: new object[,]
                {
                    { 9, null, "You can't quantify the port without copying the cross-platform GB port!", "Homer_Nikolaus@gmail.com", null, "Homer", "Student", "Nikolaus", 727 },
                    { 1, null, "The XML hard drive is down, reboot the digital hard drive so we can reboot the XML hard drive!", "Jeffrey_Kassulke@yahoo.com", null, "Jeffrey", "Student", "Kassulke", 814 },
                    { 10, null, "quantifying the driver won't do anything, we need to synthesize the neural PNG driver!", "Amy.Osinski27@gmail.com", null, "Amy", "Student", "Osinski", 705 }
                });

            migrationBuilder.InsertData(
                table: "MentorClassroom",
                columns: new[] { "MentorId", "ClassroomId" },
                values: new object[,]
                {
                    { 11, 1 },
                    { 11, 3 },
                    { 12, 2 },
                    { 12, 1 },
                    { 13, 2 },
                    { 14, 3 },
                    { 14, 1 },
                    { 14, 2 },
                    { 15, 1 },
                    { 15, 2 }
                });

            migrationBuilder.InsertData(
                table: "StudentArtifact",
                columns: new[] { "StudentId", "ArtifactId", "PurchasedQuantity" },
                values: new object[,]
                {
                    { 4, 9, 10 },
                    { 5, 1, 3 },
                    { 6, 8, 9 },
                    { 6, 9, 10 },
                    { 8, 6, 0 },
                    { 9, 10, 5 },
                    { 8, 4, 6 },
                    { 9, 9, 10 },
                    { 9, 3, 10 },
                    { 3, 3, 6 },
                    { 10, 10, 10 },
                    { 8, 5, 8 },
                    { 3, 9, 2 },
                    { 5, 8, 5 },
                    { 2, 8, 1 },
                    { 1, 6, 4 },
                    { 2, 9, 7 },
                    { 2, 2, 1 },
                    { 2, 10, 6 },
                    { 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "StudentClassroom",
                columns: new[] { "StudentId", "ClassroomId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 1 },
                    { 1, 1 },
                    { 9, 3 },
                    { 6, 1 },
                    { 6, 2 },
                    { 9, 2 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 10, 3 },
                    { 10, 1 },
                    { 4, 2 },
                    { 4, 1 },
                    { 3, 2 },
                    { 2, 1 },
                    { 10, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "StudentQuest",
                columns: new[] { "StudentId", "QuestId", "Status" },
                values: new object[,]
                {
                    { 1, 10, "Completed" },
                    { 1, 6, "Pending" },
                    { 9, 8, "Completed" },
                    { 1, 4, "Pending" },
                    { 8, 5, "Completed" },
                    { 2, 5, "Pending" },
                    { 6, 5, "Completed" },
                    { 7, 4, "Completed" },
                    { 7, 3, "Pending" },
                    { 6, 1, "Pending" },
                    { 2, 2, "Pending" },
                    { 6, 9, "Pending" },
                    { 6, 7, "Pending" },
                    { 5, 9, "Completed" },
                    { 5, 6, "Pending" },
                    { 4, 1, "Completed" },
                    { 4, 6, "Pending" },
                    { 3, 5, "Completed" },
                    { 7, 9, "Pending" },
                    { 10, 2, "Completed" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "MentorClassroom",
                keyColumns: new[] { "MentorId", "ClassroomId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "StudentArtifact",
                keyColumns: new[] { "StudentId", "ArtifactId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "StudentClassroom",
                keyColumns: new[] { "StudentId", "ClassroomId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "StudentQuest",
                keyColumns: new[] { "StudentId", "QuestId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artifact",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Quest",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
